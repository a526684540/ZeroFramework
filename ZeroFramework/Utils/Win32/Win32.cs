/**************************************************
* CLR版本：      4.0.30319.42000
* 类 名 称：       NativeMethods
* 机器名称：      ZX-PC
* 命名空间：      ZeroFramework.Utils
* 文件名：         NativeMethods
* 创建时间：      2016/7/15 13:49:30
* 作    者：       
* 说    明：
* 修改时间：
* 修 改 人：
**************************************************/

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ZeroFramework.Utils
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

    public class NativeMethods
    {
        public static IntPtr NULL = IntPtr.Zero;
        public static IntPtr HWND_DESKTOP = new IntPtr(0);

        #region Constans values
        public const string TOOLBARCLASSNAME = "ToolbarWindow32";
        public const string REBARCLASSNAME = "ReBarWindow32";
        public const string PROGRESSBARCLASSNAME = "msctls_progress32";
        public const string SCROLLBAR = "SCROLLBAR";
        #endregion

        #region CallBacks
        public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        public delegate Int32 WNDPROC(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam);
        #endregion

        #region Kernel32.dll functions

        [DllImport("kernel32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetCurrentThreadId();

        [DllImport("kernel32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string name);

        #endregion

        #region User32.dll functions
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool ShowWindow(IntPtr hWnd, short State);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool UpdateWindow(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int Width, int Height, uint flags);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool OpenClipboard(IntPtr hWndNewOwner);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool CloseClipboard();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool EmptyClipboard();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern IntPtr SetClipboardData(uint Format, IntPtr hData);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool GetMenuItemRect(IntPtr hWnd, IntPtr hMenu, uint Item, ref RECT rc);
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref RECT lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref POINT lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref TBBUTTON lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref TBBUTTONINFO lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref REBARBANDINFO lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref TVITEM lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref LVITEM lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref HDITEM lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref HD_HITTESTINFO hti);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowsHookEx(int hookid, HookProc pfnhook, IntPtr hinst, int threadid);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhook);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr CallNextHookEx(IntPtr hhook, int code, IntPtr wparam, IntPtr lparam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetFocus(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static int DrawText(IntPtr hdc, string lpString, int nCount, ref RECT lpRect, int uFormat);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static IntPtr SetParent(IntPtr hChild, IntPtr hParent);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static IntPtr GetDlgItem(IntPtr hDlg, int nControlID);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static int GetClientRect(IntPtr hWnd, ref RECT rc);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static int InvalidateRect(IntPtr hWnd, IntPtr rect, int bErase);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool WaitMessage();
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool PeekMessage(ref MSG msg, IntPtr hWnd, uint wFilterMin, uint wFilterMax, uint wFlag);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool GetMessage(ref MSG msg, IntPtr hWnd, uint wFilterMin, uint wFilterMax);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool TranslateMessage(ref MSG msg);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool DispatchMessage(ref MSG msg);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr LoadCursor(IntPtr hInstance, uint cursor);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetCursor(IntPtr hCursor);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetFocus();
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT ps);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT ps);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref POINT pptDst, ref SIZE psize, IntPtr hdcSrc, ref POINT pprSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);

        /// <summary>
        /// GetWindowLong won't work correctly for 64-bit: we should use GetWindowLongPtr instead.  On
        /// 32-bit, GetWindowLongPtr is just #defined as GetWindowLong.  GetWindowLong really should 
        /// take/return int instead of IntPtr/HandleRef, but since we're running this only for 32-bit
        /// it'll be OK.
        /// </summary>        
        public static IntPtr GetWindowLong(IntPtr hWnd, SetWindowLongOffsets nIndex)
        {
            if (IntPtr.Size == 4)
            {
                return GetWindowLong32(hWnd, (int)nIndex);
            }
            return GetWindowLongPtr64(hWnd, (int)nIndex);
        }

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, EntryPoint = "GetWindowLong")]
        private static extern IntPtr GetWindowLong32(IntPtr hWnd, int nIndex);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, EntryPoint = "GetWindowLongPtr")]
        private static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT pt);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool TrackMouseEvent(ref TRACKMOUSEEVENTS tme);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool redraw);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern ushort GetKeyState(int virtKey);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, out STRINGBUFFER ClassName, int nMaxCount);

        /// <summary>
        /// SetWindowLong won't work correctly for 64-bit: we should use SetWindowLongPtr instead.  On
        /// 32-bit, SetWindowLongPtr is just #defined as SetWindowLong.  SetWindowLong really should 
        /// take/return int instead of IntPtr/HandleRef, but since we're running this only for 32-bit
        /// it'll be OK.
        /// </summary>
        public static IntPtr SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong)
        {
            if (IntPtr.Size == 4)
            {
                return SetWindowLongPtr32(hWnd, nIndex, dwNewLong);
            }
            return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
        }

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, EntryPoint = "SetWindowLong")]
        private static extern IntPtr SetWindowLongPtr32(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, EntryPoint = "SetWindowLongPtr")]
        private static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hRegion, uint flags);

        /// <summary>        
        /// wCmd指定结果窗口与源窗口的关系，它们建立在下述常数基础上：
        /// GW_CHILD
        /// 寻找源窗口的第一个子窗口
        /// GW_HWNDFIRST
        /// 为一个源子窗口寻找第一个兄弟（同级）窗口，或寻找第一个顶级窗口
        /// GW_HWNDLAST
        /// 为一个源子窗口寻找最后一个兄弟（同级）窗口，或寻找最后一个顶级窗口
        /// GW_HWNDNEXT
        /// 为源窗口寻找下一个兄弟窗口
        /// GW_HWNDPREV
        /// 为源窗口寻找前一个兄弟窗口
        /// GW_OWNER
        /// 寻找窗口的所有者        
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="wCmd"></param>
        /// <returns></returns>
        [DllImport(ExternDll.User32, EntryPoint = "GetWindow")]
        public static extern IntPtr GetWindow(
            IntPtr hwnd,
            int wCmd
        );

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int FillRect(IntPtr hDC, ref RECT rect, IntPtr hBrush);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT wp);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SetWindowText(IntPtr hWnd, string text);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, out STRINGBUFFER text, int maxCount);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern int ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern int GetSystemMetrics(int nIndex);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern int SetScrollInfo(IntPtr hwnd, int bar, ref SCROLLINFO si, int fRedraw);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int ShowScrollBar(IntPtr hWnd, int bar, int show);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int EnableScrollBar(IntPtr hWnd, uint flags, uint arrows);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int BringWindowToTop(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetScrollInfo(IntPtr hwnd, int bar, ref SCROLLINFO si);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern int ScrollWindowEx(IntPtr hWnd, int dx, int dy,
            ref RECT rcScroll, ref RECT rcClip, IntPtr UpdateRegion, ref RECT rcInvalidated, uint flags);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int IsWindow(IntPtr hWnd);
        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern int GetKeyboardState(byte[] pbKeyState);
        [DllImport("user32")]
        public static extern int ToAscii(int uVirtKey, //[in] Specifies the virtual-key code to be translated. 
            int uScanCode, // [in] Specifies the hardware scan code of the key to be translated. The high-order bit of this value is set if the key is up (not pressed). 
            byte[] lpbKeyState, // [in] Pointer to a 256-byte array that contains the current keyboard state. Each element (byte) in the array contains the state of one key. If the high-order bit of a byte is set, the key is down (pressed). The low bit, if set, indicates that the key is toggled on. In this function, only the toggle bit of the CAPS LOCK key is relevant. The toggle state of the NUM LOCK and SCROLL LOCK keys is ignored.
            byte[] lpwTransKey, // [out] Pointer to the buffer that receives the translated character or characters. 
            int fuState); // [in] Specifies whether a menu is active. This parameter must be 1 if a menu is active, or 0 otherwise.

        [DllImport("user32.dll")]
        public static extern HWND CreateWindowEx(
            DWORD dwExStyle, LPCTSTR lpClassName, LPCTSTR lpWindowName,
            DWORD dwStyle, Int32 x, Int32 y, Int32 nWidth, Int32 nHeight,
            HWND hWndParent, HMENU hMenu, HINSTANCE hInstance, LPVOID lpParam);

        [DllImport("user32.dll")]
        public static extern ATOM RegisterClassEx(ref WNDCLASSEX lpwcx);

        [DllImport("user32.dll")]
        public static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool GetUpdateRect(IntPtr hWnd, ref RECT rect, bool bErase);

        [DllImport(ExternDll.User32, EntryPoint = "IsRectEmpty")]
        public static extern int IsRectEmpty(ref RECT lpRect);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int MapWindowPoints(HWND hWndFrom, HWND hWndTo, [In, Out] POINT pt, int cPoints);

        #endregion

        #region Gdi32.dll functions

        [DllImport(ExternDll.Gdi32)]
        static public extern bool StretchBlt(IntPtr hDCDest, int XOriginDest, int YOriginDest, int WidthDest, int HeightDest,
        IntPtr hDCSrc, int XOriginScr, int YOriginSrc, int WidthScr, int HeightScr, uint Rop);
        [DllImport(ExternDll.Gdi32)]
        static public extern IntPtr CreateCompatibleDC(IntPtr hDC);
        [DllImport(ExternDll.Gdi32)]
        static public extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int Width, int Heigth);
        [DllImport(ExternDll.Gdi32)]
        static public extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        [DllImport(ExternDll.Gdi32)]
        static public extern bool BitBlt(IntPtr hDCDest, int XOriginDest, int YOriginDest, int WidthDest, int HeightDest,
        IntPtr hDCSrc, int XOriginScr, int YOriginSrc, uint Rop);
        [DllImport(ExternDll.Gdi32)]
        static public extern IntPtr DeleteDC(IntPtr hDC);
        [DllImport(ExternDll.Gdi32)]
        static public extern bool PatBlt(IntPtr hDC, int XLeft, int YLeft, int Width, int Height, uint Rop);

        [DllImport(ExternDll.Gdi32, ExactSpelling = true, SetLastError = true)]
        static public extern bool DeleteObject(IntPtr hObject);
        [DllImport(ExternDll.Gdi32)]
        static public extern uint GetPixel(IntPtr hDC, int XPos, int YPos);
        [DllImport(ExternDll.Gdi32)]
        static public extern int SetMapMode(IntPtr hDC, int fnMapMode);
        [DllImport(ExternDll.Gdi32)]
        static public extern int GetObjectType(IntPtr handle);
        [DllImport(ExternDll.Gdi32)]
        public static extern IntPtr CreateDIBSection(IntPtr hdc, ref BITMAPINFO_FLAT bmi,
        int iUsage, ref int ppvBits, IntPtr hSection, int dwOffset);
        [DllImport(ExternDll.Gdi32)]
        public static extern int GetDIBits(IntPtr hDC, IntPtr hbm, int StartScan, int ScanLines, int lpBits, BITMAPINFOHEADER bmi, int usage);
        [DllImport(ExternDll.Gdi32)]
        public static extern int GetDIBits(IntPtr hdc, IntPtr hbm, int StartScan, int ScanLines, int lpBits, ref BITMAPINFO_FLAT bmi, int usage);
        [DllImport(ExternDll.Gdi32)]
        public static extern IntPtr GetPaletteEntries(IntPtr hpal, int iStartIndex, int nEntries, byte[] lppe);
        [DllImport(ExternDll.Gdi32)]
        public static extern IntPtr GetSystemPaletteEntries(IntPtr hdc, int iStartIndex, int nEntries, byte[] lppe);
        [DllImport(ExternDll.Gdi32)]
        public static extern uint SetDCBrushColor(IntPtr hdc, uint crColor);
        [DllImport(ExternDll.Gdi32)]
        public static extern IntPtr CreateSolidBrush(uint crColor);
        [DllImport(ExternDll.Gdi32)]
        public static extern int SetBkMode(IntPtr hDC, BackgroundMode mode);
        [DllImport(ExternDll.Gdi32)]
        public static extern int SetViewportOrgEx(IntPtr hdc, int x, int y, int param);
        [DllImport(ExternDll.Gdi32)]
        public static extern uint SetTextColor(IntPtr hDC, uint colorRef);
        [DllImport(ExternDll.Gdi32)]
        public static extern int SetStretchBltMode(IntPtr hDC, int StrechMode);

        [DllImport(ExternDll.Gdi32)]
        public static extern IntPtr GetStockObject(int fnobject);

        /// <summary>
        /// Displays a bitmap with transparent or semitransparent pixels. 
        /// </summary>
        /// <param name="hdcDest">handle to destination DC</param>
        /// <param name="nXOriginDest">x-coord of upper-left corner</param>
        /// <param name="nYOriginDest">y-coord of upper-left corner</param>
        /// <param name="nWidthDest">destination width</param>
        /// <param name="nHeightDest">destination height</param>
        /// <param name="hdcSrc">handle to source DC</param>
        /// <param name="nXOriginSrc">x-coord of upper-left corner</param>
        /// <param name="nYOriginSrc">y-coord of upper-left corner</param>
        /// <param name="nWidthSrc">source width</param>
        /// <param name="nHeightSrc">source height</param>
        /// <param name="blendFunction">alpha-blending function</param>
        /// <returns></returns>
        /// <remarks>System.Drawing.Graphics.DrawImage</remarks>
        [DllImport(ExternDll.Gdi32, CharSet = CharSet.Auto)]
        public static extern bool AlphaBlend(
            IntPtr hdcDest,
            int nXOriginDest,
            int nYOriginDest,
            int nWidthDest,
            int nHeightDest,
            IntPtr hdcSrc,
            int nXOriginSrc,
            int nYOriginSrc,
            int nWidthSrc,
            int nHeightSrc,
            BLENDFUNCTION blendFunction);

        [DllImport(ExternDll.Gdi32, CharSet = CharSet.Auto)]
        public static extern int SaveDC(IntPtr hdc);

        [DllImport(ExternDll.Gdi32, CharSet = CharSet.Auto)]
        public static extern bool RestoreDC(IntPtr hdc, int nSavedDC);


        [DllImport(ExternDll.Gdi32, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int Rectangle(IntPtr hDC, int left, int top, int right, int bottom);

        [DllImport(ExternDll.Gdi32)]
        public extern static bool SetWindowOrgEx(IntPtr hdc, int X, int Y, out POINT lpPoint);

        #endregion

        #region Win32 Macro-Like helpers

        public static int GET_X_LPARAM(int lParam)
        {
            return (lParam & 0xffff);
        }

        public static int GET_Y_LPARAM(int lParam)
        {
            return (lParam >> 16);
        }

        public static Point GetPointFromLPARAM(int lParam)
        {
            return new Point(GET_X_LPARAM(lParam), GET_Y_LPARAM(lParam));
        }

        public static int LOW_ORDER(int param)
        {
            return (param & 0xffff);
        }

        public static int HIGH_ORDER(int param)
        {
            return (param >> 16);
        }

        #endregion
    }
}
