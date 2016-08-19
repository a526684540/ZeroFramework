/**************************************************
* CLR版本 ：    4.0.30319.42000
* 类 名 称：    DuiHostFormBase
* 机器名称：    ZX-PC
* 命名空间：    ZeroFramework.DirectUI.Core.DuiHost
* 文件名  ：    DuiHostFormBase
* 创建时间：    2016/7/19 16:58:05
* 作    者：    Zero
* 说    明：    自定义Class窗体基类   
* 修改时间：
* 修 改 人：
**************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ZeroFramework.DirectUI
{
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

    #endregion

    using Utils;

    public class DuiHostFormBase
    {
        #region 变量声明、定义

        protected const LPPOINT ERROR_CLASS_ALREADY_EXISTS = 1410;

        protected HWND m_hWnd;
        protected IntPtr m_defWindowProc;
        bool m_bSubclassed;

        protected IntPtr m_pointer;

        #endregion

        public DuiHostFormBase()
        {
            //生成对象句柄
            GCHandle gc = GCHandle.Alloc(this, GCHandleType.WeakTrackResurrection);
            var pointer = GCHandle.ToIntPtr(gc);
            m_pointer = pointer;
            //获得默认消息处理委托句柄
            m_defWindowProc = GetDefWindowPorc();
        }

        protected virtual UINT GetClassStyle()
        {
            return 0;
        }

        protected virtual LPCTSTR GetSuperClassName()
        {
            return null;
        }

        protected virtual LPCTSTR GetWindowClassName() { return null; }

        public HWND CreateDuiWindow(HWND hwndParent, LPCTSTR pstrWindowName, DWORD dwStyle /*=0*/, DWORD dwExStyle /*=0*/)
        {
            return Create(hwndParent, pstrWindowName, dwStyle, dwExStyle, 0, 0, 0, 0, IntPtr.Zero);
        }

        public HWND Create(HWND hwndParent, LPCTSTR strName, DWORD dwStyle, DWORD dwExStyle, int x, int y, int cx, int cy, HMENU hMenu)
        {
            if (GetSuperClassName() != null && !RegisterSuperclass()) return IntPtr.Zero;
            if (GetSuperClassName() == null && !RegisterWindowClass()) return IntPtr.Zero;
            m_hWnd = NativeMethods.CreateWindowEx(dwExStyle, GetWindowClassName(), strName, dwStyle, x, y, cx, cy, hwndParent, hMenu, DuiUIManager.GetInstance(), m_pointer);
            Debug.Assert(m_hWnd != IntPtr.Zero);
            return m_hWnd;
        }

        public HWND Subclass(HWND hWnd)
        {
            Debug.Assert(NativeMethods.IsWindow(hWnd));
            Debug.Assert(m_hWnd == IntPtr.Zero);
            NativeMethods.WNDPROC wndProc = __WndProc;
            m_defWindowProc = NativeMethods.SetWindowLong(hWnd, (int)SetWindowLongOffsets.GWL_WNDPROC,
                Marshal.GetFunctionPointerForDelegate(wndProc));
            if (m_defWindowProc == IntPtr.Zero) return IntPtr.Zero;
            m_bSubclassed = true;
            m_hWnd = hWnd;

            NativeMethods.SetWindowLong(hWnd, (int)SetWindowLongOffsets.GWL_USERDATA, m_pointer);

            return m_hWnd;
        }

        public void Unsubclass()
        {
            Debug.Assert(NativeMethods.IsWindow(m_hWnd));
            if (!NativeMethods.IsWindow(m_hWnd)) return;
            if (!m_bSubclassed) return;
            NativeMethods.SetWindowLong(m_hWnd, (int)SetWindowLongOffsets.GWL_WNDPROC, m_defWindowProc);
            m_defWindowProc = GetDefWindowPorc();
            m_bSubclassed = false;
        }

        public void ShowWindow(bool bShow = true, bool bTakeFocus = true)
        {
            Debug.Assert(NativeMethods.IsWindow(m_hWnd));
            if (!NativeMethods.IsWindow(m_hWnd)) return;
            short state = (short)(bShow ? (bTakeFocus ? ShowWindowStyles.SW_SHOWNORMAL : ShowWindowStyles.SW_SHOWNOACTIVATE) : ShowWindowStyles.SW_HIDE);
            NativeMethods.ShowWindow(m_hWnd, state);
        }

        public UINT ShowModal()
        {
            Debug.Assert(NativeMethods.IsWindow(m_hWnd));
            UINT nRet = 0;
            //GetWindowOwner
            HWND hWndParent = NativeMethods.GetWindow(m_hWnd, GetWindowFlags.GW_OWNER);
            NativeMethods.ShowWindow(m_hWnd, ShowWindowStyles.SW_SHOWNORMAL);
            NativeMethods.EnableWindow(hWndParent, false);
            MSG msg = new MSG();
            while (NativeMethods.IsWindow(m_hWnd) && NativeMethods.GetMessage(ref msg, IntPtr.Zero, 0, 0))
            {
                if (msg.message == WindowMessages.WM_CLOSE && msg.hwnd == m_hWnd)
                {
                    nRet = (UINT)msg.wParam;
                    NativeMethods.EnableWindow(hWndParent, true);
                    NativeMethods.SetFocus(hWndParent);
                }
                if (!DuiUIManager.TranslateMessage(ref msg))
                {
                    NativeMethods.TranslateMessage(ref msg);
                    NativeMethods.DispatchMessage(ref msg);
                }
                if (msg.message == WindowMessages.WM_QUIT) break;
            }

            NativeMethods.EnableWindow(hWndParent, true);
            NativeMethods.SetFocus(hWndParent);

            if (msg.message == WindowMessages.WM_QUIT)
                NativeMethods.PostQuitMessage((int)msg.wParam);

            return nRet;
        }

        public void Close(int nRet = 1)
        {
            Debug.Assert(NativeMethods.IsWindow(m_hWnd));
            if (!NativeMethods.IsWindow(m_hWnd)) return;
            NativeMethods.PostMessage(m_hWnd, WindowMessages.WM_CLOSE, (int)nRet, 0);
        }

        public void CenterWindow()
        {
            Debug.Assert(NativeMethods.IsWindow(m_hWnd));
            Debug.Assert((NativeMethods.GetWindowStyle(m_hWnd) & WindowStyles.WS_CHILD) == 0);
            RECT rcDlg = new RECT();
            NativeMethods.GetWindowRect(m_hWnd, ref rcDlg);
            RECT rcArea = new RECT();
            RECT rcCenter = new RECT();
            HWND hWndParent = NativeMethods.GetParent(m_hWnd);
            HWND hWndCenter = NativeMethods.GetWindow(m_hWnd, GetWindowFlags.GW_OWNER);
            int SPI_GETWORKAREA = 0x0030;
            //NativeMethods.SystemParametersInfo(SPI_GETWORKAREA,IntPtr.z)
        }

        public void SetIcon(UINT nRes)
        {

        }

        public bool RegisterWindowClass()
        {//此处错误，不是注册ClassEx
            WNDCLASSEX wc = new WNDCLASSEX();
            wc.style = GetClassStyle();
            wc.cbClsExtra = 0;
            wc.cbWndExtra = 0;
            wc.hIcon = IntPtr.Zero;
            wc.lpfnWndProc = __WndProc;
            wc.hInstance = DuiUIManager.GetInstance();
            wc.hCursor = NativeMethods.LoadCursor(IntPtr.Zero, (UINT)CursorType.IDC_ARROW);
            int COLOR_WINDOW = 5;
            wc.hbrBackground = new IntPtr(COLOR_WINDOW + 1);
            wc.lpszMenuName = null;
            wc.lpszClassName = GetWindowClassName();
            ATOM ret = NativeMethods.RegisterClassEx(ref wc);
            Debug.Assert(Marshal.GetLastWin32Error() == ERROR_CLASS_ALREADY_EXISTS);
            return Marshal.GetLastWin32Error() == ERROR_CLASS_ALREADY_EXISTS;
        }

        public bool RegisterSuperclass()
        {//此处注册ClassEx
            return true;
        }

        protected static Int32 __WndProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam)
        {
            DuiHostFormBase hostForm = null;

            if (msg == WindowMessages.WM_NCCREATE)
            {
                var lpcs = (LPCREATESTRUCT)Marshal.PtrToStructure((IntPtr)lParam, typeof(LPCREATESTRUCT));
                IntPtr pHostForm = new IntPtr(lpcs.lpCreateParams);
                var gch = GCHandle.FromIntPtr(pHostForm);
                hostForm = gch.Target as DuiHostFormBase;
                if (hostForm != null)
                {
                    hostForm.m_hWnd = hWnd;
                    NativeMethods.SetWindowLong(hWnd, (int)SetWindowLongOffsets.GWL_USERDATA, pHostForm);
                }
            }
            else
            {
                IntPtr pHostForm = NativeMethods.GetWindowLong(hWnd, SetWindowLongOffsets.GWL_USERDATA);
                try
                {
                    var gch = GCHandle.FromIntPtr(pHostForm);
                    hostForm = gch.Target as DuiHostFormBase;
                }
                catch { }

                if (msg == WindowMessages.WM_NCDESTROY && hostForm != null)
                {
                    LRESULT lRes = NativeMethods.CallWindowProc(hostForm.m_defWindowProc, hWnd, (int)msg, (IntPtr)wParam, (IntPtr)lParam).ToInt32();
                    NativeMethods.SetWindowLong(hWnd, (int)SetWindowLongOffsets.GWL_USERDATA, IntPtr.Zero);
                    if (hostForm.m_bSubclassed)
                        hostForm.Unsubclass();
                    hostForm.m_hWnd = IntPtr.Zero;
                    hostForm.OnFinalMessage(hWnd);
                    return lRes;
                }
            }

            if (hostForm != null)
            {
                return hostForm.HandleMessage(msg, wParam, lParam);
            }
            else
            {
                return NativeMethods.DefWindowProc(hWnd, (int)msg, new IntPtr(wParam), new IntPtr(lParam)).ToInt32();
            }
        }

        //protected static Int32 __ControlProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam)
        //{
        //    //return DefWindowProcW(hWnd, msg, wParam, lParam);
        //}

        public LRESULT SendMessage(UINT uMsg, WPARAM wParam, LPARAM lParam)
        {
            Debug.Assert(NativeMethods.IsWindow(m_hWnd));
            return NativeMethods.SendMessage(m_hWnd, (int)uMsg, (IntPtr)wParam, (IntPtr)lParam);
        }

        public LRESULT PostMessage(UINT uMsg, WPARAM wParam, LPARAM lParam)
        {
            Debug.Assert(NativeMethods.IsWindow(m_hWnd));
            return NativeMethods.PostMessage(m_hWnd, (int)uMsg, (int)wParam, (int)lParam).ToInt32();
        }

        public void ResizeClient(int cx,int cy)
        {
            Debug.Assert(NativeMethods.IsWindow(m_hWnd));
            RECT rc = new RECT();
            if (!NativeMethods.GetClientRect(m_hWnd, ref rc)) return;
            if (cx != -1) rc.right = cx;
            if (cy != -1) rc.bottom = cy;

            //NativeMethods.AdjustWindowRectEx(
            //    ref rc,
            //    NativeMethods.GetWindowStyle(m_hWnd),
            //     (!(NativeMethods.GetWindowStyle(m_hWnd) & WS_CHILD) && (NativeMethods.GetMenu(m_hWnd) != NULL)),
            //     GetWindowExStyle(m_hWnd)
        }

        protected virtual LRESULT HandleMessage(UINT uMsg, WPARAM wParam, LPARAM lParam)
        {
            LRESULT lRes = NativeMethods.CallWindowProc(m_defWindowProc, m_hWnd, (int)uMsg, (IntPtr)wParam, (IntPtr)lParam).ToInt32();

            return lRes;
        }

        protected virtual void OnFinalMessage(HWND hWnd)
        {

        }

        protected IntPtr GetDefWindowPorc()
        {
            string defproc = Marshal.SystemDefaultCharSize == 1 ? "DefWindowProcA" : "DefWindowProcW";

            return NativeMethods.GetProcAddress(new HandleRef(null, NativeMethods.GetModuleHandle("user32.dll")), defproc);
        }
    }
}
