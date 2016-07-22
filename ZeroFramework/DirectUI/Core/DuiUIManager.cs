/**************************************************
* CLR版本 ：    4.0.30319.42000
* 类 名 称：    DuiManager
* 机器名称：    ZX-PC
* 命名空间：    ZeroFramework.DirectUI.Core
* 文件名  ：    DuiManager
* 创建时间：    2016/7/15 15:33:21
* 作    者：    Zero  
* 说    明：    DirectUI所有消息、状态调度管理类。
* 修改时间：
* 修 改 人：
**************************************************/

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

namespace ZeroFramework.DirectUI
{
    using Utils;

    #region 命名控件转译

    using LPCTSTR = System.String;
    using ATOM = System.UInt16;
    using WORD = System.UInt16;
    using BYTE = System.UInt16;
    using DWORD = System.UInt32;
    using WPARAM = System.UInt32;
    using UINT = System.UInt32;
    using LRESULT = System.Int32;
    using LPARAM = System.Int32;
    using LPVOID = System.Int32;
    using HRESULT = System.Int32;
    using BOOL = System.Int32;
    using LPSIZE = System.Int32;
    using LPPOINT = System.Int32;
    using HWND = System.IntPtr;
    using HINSTANCE = System.IntPtr;
    using HICON = System.IntPtr;
    using HCURSOR = System.IntPtr;
    using HBRUSH = System.IntPtr;
    using HMENU = System.IntPtr;
    using HDC = System.IntPtr;
    using HGDIOBJ = System.IntPtr;
    using HBITMAP = System.IntPtr;
    using HDC = System.IntPtr;
    using HPEN = System.IntPtr;

    #endregion

    public class DuiUIManager
    {
        #region 私有变量

        const int HOLLOW_BRUSH = 5;

        private DuiHostBase m_PaintHost = null;

        private DuiControlBase m_RootControl = null;
        private DuiControlBase m_FocusControl = null;

        private HWND m_hWndPaint;
        private HDC m_hDcPaint;
        private HDC m_hDcOffscreen;
        private HDC m_hDcBackground;
        private HPEN m_hUpdateRectPen;

        private bool m_bAlphaBackground = false;
        private bool m_bFirstLayout = true;
        private bool m_bFocusNeeded = false;
        private bool m_bUpdateNeeded = false;
        private bool m_bMouseTracking = false;
        private bool m_bMouseCapture = false;
        private bool m_bOffscreenPaint = true;
        private bool m_bUsedVirtualWnd = false;
        private bool m_bShowUpdateRect = false;

        private HBITMAP m_hbmpOffscreen;
        private HBITMAP m_hbmpBackground;

        private List<IMessageFilterUI> m_aPreMessageFilters = null;
        private List<IMessageFilterUI> m_aMessageFilters = null;
        public List<ITranslateAccelerator> m_aTranslateAccelerator = null;

        static HINSTANCE m_hInstance;

        /// <summary>
        /// 自定义消息
        /// </summary>
        public const int WM_EFFECTS = WindowMessages.WM_USER + 1680;
        public const int WM_RELOADSTYLE = WindowMessages.WM_USER + 1681;

        #endregion

        #region 构造函数

        public DuiUIManager()
        {
            m_aPreMessageFilters = new List<IMessageFilterUI>();
            m_aMessageFilters = new List<IMessageFilterUI>();
            m_aTranslateAccelerator = new List<ITranslateAccelerator>();
        }

        ~DuiUIManager()
        {
            if (m_hDcPaint != NativeMethods.Handle_NULL)
                NativeMethods.ReleaseDC(m_hWndPaint, m_hDcPaint);
            m_aPreMessages.Remove(this);
        }

        #endregion

        #region 公有函数

        public IntPtr GetPaintWindow()
        {
            if (m_hWndPaint == null)
                return IntPtr.Zero;

            return m_hWndPaint;
        }

        public void Init(DuiHostBase host)
        {
            m_PaintHost = host;
            m_hWndPaint = host.GetHwnd();
            m_hDcPaint = NativeMethods.GetDC(m_hWndPaint);
            m_aPreMessages.Add(this);
        }

        #endregion

        public bool PreMessageHandler(int nMsg, IntPtr wParam, IntPtr lParam, ref int nRes)
        {
            for (int i = 0; i < m_aPreMessageFilters.Count; i++)
            {
                bool bHandled = false;
                var nResult = m_aPreMessageFilters[i].MessageHandler(nMsg, wParam, lParam, ref bHandled);
                if (bHandled)
                    return true;
            }

            switch (nMsg)
            {
                case WindowMessages.WM_KEYDOWN:
                    break;
                case WindowMessages.WM_SYSCHAR:
                    break;
                case WindowMessages.WM_SYSKEYDOWN:
                    break;
                default:
                    break;
            }

            return false;
        }

        internal bool MessageHandler(int nMsg, IntPtr wParam, IntPtr lParam, ref int nRes)
        {
            if (m_hWndPaint == IntPtr.Zero) return false;

            //TODO::消息队列处理

            #region 处理监听

            for (int i = 0; i < m_aMessageFilters.Count; i++)
            {
                bool bHandled = false;
                var nResult = m_aMessageFilters[i].MessageHandler(nMsg, wParam, lParam, ref bHandled);
                if (bHandled)
                {
                    nRes = nResult;
                    return true;
                }
            }

            #endregion

            switch (nMsg)
            {
                case WindowMessages.WM_APP:
                    break;
                case WindowMessages.WM_CLOSE:
                    break;
                case WindowMessages.WM_ERASEBKGND:
                    {
                        nRes = 1;
                        return true;
                    }
                case WindowMessages.WM_PAINT:
                    #region 处理WM_PAINT

                    RECT rcPaint = new RECT();
                    if (!NativeMethods.GetUpdateRect(m_hWndPaint, ref rcPaint, false))
                        return true;

                    if (m_RootControl == null)
                    {
                        PAINTSTRUCT ps = new PAINTSTRUCT();
                        NativeMethods.BeginPaint(m_hWndPaint, ref ps);
                        NativeMethods.EndPaint(m_hWndPaint, ref ps);
                        return true;
                    }

                    if (m_bAlphaBackground)
                    {
                        var dwExStyle = NativeMethods.GetWindowLong(m_hWndPaint, SetWindowLongOffsets.GWL_EXSTYLE);
                        if ((dwExStyle.ToInt32() & WindowStyles.WS_EX_LAYERED) != 0x80000)
                        {
                            NativeMethods.SetWindowLong(m_hWndPaint, (int)SetWindowLongOffsets.GWL_EXSTYLE, dwExStyle.ToInt32() ^ WindowStyles.WS_EX_LAYERED);
                        }

                        RECT rcClient = new RECT();
                        NativeMethods.GetClientRect(m_hWndPaint, ref rcClient);

                        PAINTSTRUCT ps = new PAINTSTRUCT();
                        NativeMethods.BeginPaint(m_hWndPaint, ref ps);

                        if (m_bUpdateNeeded)
                        {
                            m_bUpdateNeeded = false;

                            if (NativeMethods.IsRectEmpty(ref rcClient) == 0)
                            {

                            }
                        }
                    }

                    if (m_bUpdateNeeded)
                    {
                        m_bUpdateNeeded = false;
                        RECT rcClient = new RECT();
                        NativeMethods.GetClientRect(m_hWndPaint, ref rcClient);

                        if (NativeMethods.IsRectEmpty(ref rcClient) == 0)
                        {

                        }
                    }

                    if (m_bFocusNeeded)
                    {

                    }

                    //TODO::Animating

                    #region Render screen

                    if (m_bOffscreenPaint && m_hbmpOffscreen == IntPtr.Zero)
                    {
                        RECT rcClient = new RECT();
                        NativeMethods.GetClientRect(m_hWndPaint, ref rcClient);
                        m_hDcOffscreen = NativeMethods.CreateCompatibleDC(m_hDcPaint);
                        m_hbmpOffscreen = NativeMethods.CreateCompatibleBitmap(m_hDcPaint, rcClient.right - rcClient.left, rcClient.bottom - rcClient.top);

                        Debug.Assert(m_hDcOffscreen != IntPtr.Zero);
                        Debug.Assert(m_hbmpOffscreen != IntPtr.Zero);
                    }
                    {
                        PAINTSTRUCT ps = new PAINTSTRUCT();
                        NativeMethods.BeginPaint(m_hWndPaint, ref ps);

                        if (m_bOffscreenPaint)
                        {
                            HBITMAP hOldBitmap = NativeMethods.SelectObject(m_hDcOffscreen, m_hbmpOffscreen);
                            int nSaveDC = NativeMethods.SaveDC(hOldBitmap);
                            //TODO::Paint
                            NativeMethods.RestoreDC(m_hDcOffscreen, nSaveDC);
                            NativeMethods.BitBlt(ps.hdc, ps.rcPaint.Left, ps.rcPaint.Top, ps.rcPaint.Width, ps.rcPaint.Height,
                                m_hDcOffscreen, ps.rcPaint.Left, ps.rcPaint.Top, TernaryRasterOperations.SRCCOPY);
                            NativeMethods.SelectObject(m_hDcOffscreen, hOldBitmap);

                            if (m_bShowUpdateRect)
                            {
                                HPEN hOldPen = NativeMethods.SelectObject(ps.hdc, m_hUpdateRectPen);
                                NativeMethods.SelectObject(ps.hdc, NativeMethods.GetStockObject(HOLLOW_BRUSH));
                                NativeMethods.Rectangle(ps.hdc, rcPaint.left, rcPaint.top, rcPaint.right, rcPaint.bottom);
                                NativeMethods.SelectObject(ps.hdc, hOldPen);
                            }
                        }
                        else
                        {
                            int nSaveDC = NativeMethods.SaveDC(ps.hdc);
                            //TODO::Paint
                            NativeMethods.RestoreDC(ps.hdc, nSaveDC);
                        }

                        NativeMethods.EndPaint(m_hWndPaint, ref ps);
                    }


                    #endregion

                    // If any of the painting requested a resize again, we'll need
                    // to invalidate the entire window once more.
                    if (m_bUpdateNeeded)
                    {
                        NativeMethods.InvalidateRect(m_hWndPaint, IntPtr.Zero, 0);
                    }

                    #endregion
                    return true;
                case WindowMessages.WM_PRINTCLIENT:
                    {
                        #region 处理WM_PRINTCLIENT

                        RECT rcClient = new RECT();
                        NativeMethods.GetClientRect(m_hWndPaint, ref rcClient);
                        HDC hDC = (HDC)wParam;
                        int save = NativeMethods.SaveDC(hDC);
                        //TODO::Paint

                        // Check for traversing children. The crux is that WM_PRINT will assume
                        // that the DC is positioned at frame coordinates and will paint the child
                        // control at the wrong position. We'll simulate the entire thing instead.
                        if ((lParam.ToInt64() & WM_PRINT_Flags.PRF_NONCLIENT) != 0)
                        {
                            HWND hWndChild = NativeMethods.GetWindow(m_hWndPaint, GetWindowFlags.GW_CHILD);
                            while (hWndChild != NativeMethods.NULL)
                            {
                                RECT rcPos = new RECT();
                                NativeMethods.GetWindowRect(hWndChild, ref rcPos);
                                POINT pt = new POINT() { x = rcPos.left, y = rcPos.top };
                                NativeMethods.MapWindowPoints(NativeMethods.HWND_DESKTOP, m_hWndPaint, pt, 2);
                                POINT tmpPt = new POINT();
                                NativeMethods.SetWindowOrgEx(hDC, -rcPos.left, -rcPos.top, out tmpPt);
                                // NOTE: We use WM_PRINT here rather than the expected WM_PRINTCLIENT
                                //       since the latter will not print the nonclient correctly for
                                //       EDIT controls.
                                var newlParam = new IntPtr(lParam.ToInt64() | WM_PRINT_Flags.PRF_NONCLIENT);
                                NativeMethods.SendMessage(hWndChild, WindowMessages.WM_PRINT, wParam, newlParam);
                                hWndChild = NativeMethods.GetWindow(hWndChild, GetWindowFlags.GW_HWNDNEXT);
                            }
                        }
                        NativeMethods.RestoreDC(hDC, save);

                        #endregion
                    }
                    break;
                case WindowMessages.WM_GETMINMAXINFO:
                    break;
                case WindowMessages.WM_SIZE:
                    break;
                case WindowMessages.WM_TIMER:
                    break;
                case WindowMessages.WM_MOUSEHOVER:
                    break;
                case WindowMessages.WM_MOUSELEAVE:
                    break;
                case WindowMessages.WM_MOUSEMOVE:
                    break;
                case WindowMessages.WM_LBUTTONDOWN:
                    break;
                case WindowMessages.WM_LBUTTONDBLCLK:
                    break;
                case WindowMessages.WM_LBUTTONUP:
                    break;
                case WindowMessages.WM_RBUTTONDOWN:
                    break;
                case WindowMessages.WM_CONTEXTMENU:
                    break;
                case WindowMessages.WM_MOUSEWHEEL:
                    break;
                case WindowMessages.WM_CHAR:
                    break;
                case WindowMessages.WM_KEYDOWN:
                    break;
                case WindowMessages.WM_KEYUP:
                    break;
                case WindowMessages.WM_SETCURSOR:
                    break;
                case WindowMessages.WM_NOTIFY:
                    break;
                case WindowMessages.WM_COMMAND:
                    break;
                case WindowMessages.WM_CTLCOLOREDIT:
                case WindowMessages.WM_CTLCOLORSTATIC:
                    break;
                case WM_EFFECTS:
                    break;
                case WM_RELOADSTYLE:
                    break;
                default:
                    break;
            }

            //TODO::处理消息队列

            return false;
        }

        public bool TranslateAccelerator(MSG msg)
        {
            for (int i = 0; i < m_aTranslateAccelerator.Count; i++)
            {
                int lResult = m_aTranslateAccelerator[i].TranslateAccelerator(msg);
                if (lResult == 0)
                    return true;
            }
            return false;
        }

        #region 静态函数、变量

        private static List<DuiUIManager> m_aPreMessages = new List<DuiUIManager>();

        public static void MessageLoop()
        {
            MSG msg = new MSG();
            while (NativeMethods.GetMessage(ref msg, IntPtr.Zero, 0, 0))
            {
                if (!DuiUIManager.TranslateMessage(msg))
                {
                    NativeMethods.TranslateMessage(ref msg);
                    try
                    {
                        NativeMethods.DispatchMessage(ref msg);
                    }
                    catch
                    {
                        Debug.WriteLine("MessageLoop Error");
                        #region 调试输出信息

#if DEBUG
                        throw new Exception("MessageLoop Error");
#endif

                        #endregion
                    }
                }
            }
        }

        public static bool TranslateMessage(MSG msg)
        {
            IntPtr uStyle = NativeMethods.GetWindowLong(msg.hwnd, SetWindowLongOffsets.GWL_STYLE);
            int uChildRes = uStyle.ToInt32() & WindowMessages.WS_CHILD;
            int nRes = 0;
            if (uChildRes != 0)
            {
                IntPtr hWndParent = NativeMethods.GetParent(msg.hwnd);
                for (int i = 0; i < m_aPreMessages.Count; i++)
                {
                    var uiManager = m_aPreMessages[i];
                    IntPtr hTempParent = hWndParent;

                    while (hTempParent != IntPtr.Zero)
                    {
                        var paintHwnd = uiManager.GetPaintWindow();
                        if (msg.hwnd == paintHwnd || hTempParent == paintHwnd)
                        {
                            if (uiManager.TranslateAccelerator(msg))
                                return true;

                            if (uiManager.PreMessageHandler(msg.message, msg.wParam, msg.lParam, ref nRes))
                                return true;

                            return false;
                        }
                        hTempParent = NativeMethods.GetParent(msg.hwnd);
                    }
                }
            }
            else
            {
                for (int i = 0; i < m_aPreMessages.Count; i++)
                {
                    var uiManager = m_aPreMessages[i];

                    var paintHwnd = uiManager.GetPaintWindow();
                    if (msg.hwnd == paintHwnd)
                    {
                        if (uiManager.TranslateAccelerator(msg))
                            return true;

                        if (uiManager.PreMessageHandler(msg.message, msg.wParam, msg.lParam, ref nRes))
                            return true;

                        return false;
                    }
                }
            }

            return false;
        }

        #endregion

    }

    public interface IMessageFilterUI
    {
        int MessageHandler(int nMsg, IntPtr wParam, IntPtr lParam, ref bool bHandled);
    }

    public interface ITranslateAccelerator
    {
        int TranslateAccelerator(MSG m);
    }
}
