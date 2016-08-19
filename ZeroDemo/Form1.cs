using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ZeroDemo
{
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
    using System.Reflection;

    public partial class Form1 : Form
    {
        private static HINSTANCE hInst;
        private static WNDPROC WndMainProc;

        public Form1()
        {
            InitializeComponent();

            hInst = Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]);

            WindowRegister(hInst);
        }

        private ATOM WindowRegister(HINSTANCE hInstance)
        {
            WndMainProc = new WNDPROC(WndProc);

            WNDCLASSEX wnd;

            wnd.cbClsExtra = 0;
            wnd.cbSize = (UInt32)Marshal.SizeOf(typeof(WNDCLASSEX));
            wnd.cbWndExtra = 0;
            wnd.hbrBackground = IntPtr.Zero;
            wnd.hCursor = Cursors.Arrow.Handle;
            wnd.hIcon = IntPtr.Zero;
            wnd.hIconSm = IntPtr.Zero;
            wnd.hInstance = hInstance;
            wnd.lpfnWndProc = WndMainProc;
            wnd.lpszClassName = "Form2";
            wnd.lpszMenuName = null;
            wnd.style = 0x0008;

            return RegisterClassEx(ref wnd);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Int32 xScreen = (GetSystemMetrics(SM_CXSCREEN) - 300) >> 1;
            Int32 yScreen = (GetSystemMetrics(SM_CYSCREEN) - 300) >> 1;

            HWND hWndMain = CreateWindowEx(0x00080000, "Form2", "Form2",
                         WS_VISIBLE | WS_POPUPWINDOW | WS_CAPTION | WS_DLGFRAME | WS_CLIPSIBLINGS | WS_CLIPCHILDREN,
                          xScreen, yScreen, 300, 300, this.Handle, HWND.Zero, hInst, 0);

            ShowWindow(hWndMain, 1);
            UpdateWindow(hWndMain);
        }

        [DllImport("user32.dll")]
        private static extern BOOL ShowWindow(HWND hWnd, UInt32 nCmdShow);

        [DllImport("user32.dll")]
        private static extern BOOL UpdateWindow(HWND hWnd);

        [DllImport("user32.dll")]
        private static extern Int32 GetSystemMetrics(Int32 nIndex);

        private const Int32 SM_CXSCREEN = 0, SM_CYSCREEN = 1;
        private const UINT CS_VREDRAW = 0x0001, CS_HREDRAW = 0x0002;
        private const UINT WS_EX_TOPMOST = 0x00000008;
        private const UINT WS_VISIBLE = 0x10000000;

        private const UINT WS_EX_TOOLWINDOW = 0x00000080;

        private const UINT
           WS_OVERLAPPED = 0x00000000, WS_BORDER = 0x00800000, WS_DLGFRAME = 0x00400000,
           WS_SYSMENU = 0x00080000, WS_THICKFRAME = 0x00040000, WS_MINIMIZEBOX = 0x00020000,
           WS_MAXIMIZEBOX = 0x00010000, WS_CAPTION = WS_BORDER | WS_DLGFRAME,
           WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,
           WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW;

        private const UINT WS_CLIPSIBLINGS = 0x04000000;

        private const UINT WS_CLIPCHILDREN = 0x02000000;

        private const UINT WS_POPUP = 0x80000000;

        private const UINT WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU;

        [DllImport("user32.dll")]
        private static extern HWND CreateWindowEx(
            DWORD dwExStyle, LPCTSTR lpClassName, LPCTSTR lpWindowName,
            DWORD dwStyle, Int32 x, Int32 y, Int32 nWidth, Int32 nHeight,
            HWND hWndParent, HMENU hMenu, HINSTANCE hInstance, LPVOID lpParam);

        [DllImport("user32.dll")]
        private static extern ATOM RegisterClassEx(ref WNDCLASSEX lpwcx);

        [StructLayout(LayoutKind.Sequential)]
        private struct WNDCLASSEX
        {
            public UInt32 cbSize;
            public UInt32 style;
            public WNDPROC lpfnWndProc;
            public Int32 cbClsExtra;
            public Int32 cbWndExtra;
            public HINSTANCE hInstance;
            public HICON hIcon;
            public HCURSOR hCursor;
            public HBRUSH hbrBackground;
            public String lpszMenuName;
            public String lpszClassName;
            public HICON hIconSm;
        }

        [DllImport("user32.dll")]
        private static extern LRESULT DefWindowProc(HWND hWnd, UInt32 Msg, WPARAM wParam, LPARAM lParam);

        //使用WINDOWS API函数代替获取当前实例的函数,防止钩子失效
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);

        private delegate Int32 WNDPROC(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam);

        [DllImport("user32.dll")]
        private static extern HDC GetDC(HWND hWnd);

        [DllImport("user32.dll")]
        private static extern HRESULT ReleaseDC(HWND hWnd, HDC hDC);

        [StructLayout(LayoutKind.Sequential)]
        private struct PAINTSTRUCT
        {
            public HDC hdc;
            public BOOL fErase;
            public RECT rcPaint;
            public BOOL fRestore;
            public BOOL fIncUpdate;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public BYTE[] rgbReserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public Int32 left;
            public Int32 top;
            public Int32 right;
            public Int32 bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public Int32 x;
            public Int32 y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SIZE
        {
            public Int32 cx;
            public Int32 cy;
        }

        [DllImport("user32.dll")]
        private static extern HDC BeginPaint(HWND hwnd, out PAINTSTRUCT lpPaint);

        [DllImport("user32.dll")]
        private static extern BOOL EndPaint(HWND hwnd, out PAINTSTRUCT lpPaint);

        [DllImport("gdi32.dll")]
        private static extern HGDIOBJ SelectObject(HDC hdc, HGDIOBJ hgdiobj);

        [DllImport("gdi32.dll")]
        private static extern BOOL Ellipse(
            HDC hdc, Int32 nLeftRect, Int32 nTopRect, Int32 nRightRect, Int32 nBottomRect);

        [DllImport("gdi32.dll")]
        private static extern HGDIOBJ GetStockObject(Int32 fnObject);

        private LRESULT WndProc(HWND hWnd, UInt32 uMsg, WPARAM wParam, LPARAM lParam)
        {
            BOOL fChange;
            HDC hdc;
            PAINTSTRUCT ps;

            //if (uMsg == 0x0085 || uMsg == 0x0086)
            //    return 0;
            ////if (uMsg == 0x0084)
            ////    return 1;

            //if (uMsg == 0x0014)//WM_ERASEBKGND
            //    return 1;

            if (uMsg == 0x000F)
            {
                Console.WriteLine("WM_PAINT");
            }

            //return CallWindowProc(IntPtr.Zero, hWnd, uMsg, wParam, lParam);

            return DefWindowProc(hWnd, uMsg, wParam, lParam);
        }

        private const Int32 WHITE_BRUSH = 0, BLACK_BRUSH = 4, WHITE_PEN = 6, BLACK_PEN = 7;

        private static HBRUSH hbrBlack = GetStockObject(BLACK_BRUSH);

        private static void DrawClock(HDC hdc)
        {
            Int32 iAngle;
            POINT[] pt = new POINT[3];

            for (iAngle = 0; iAngle < 360; iAngle += 6)
            {
                pt[0].x = 0; pt[0].y = 900;

                RotatePoint(pt, 1, iAngle);

                pt[2].x = 0 < iAngle % 5 ? 33 : 100; pt[2].y = pt[2].x;

                pt[0].x -= pt[2].x >> 1; pt[0].y -= pt[2].y >> 1;

                pt[1].x = pt[0].x + pt[2].x; pt[1].y = pt[0].y + pt[2].y;

                SelectObject(hdc, hbrBlack);
                Ellipse(hdc, pt[0].x, pt[0].y, pt[1].x, pt[1].y);
            }
        }

        private static void RotatePoint(POINT[] pt, Int32 iNum, Int32 iAngle)
        {
            Int32 i;
            POINT ptTemp;

            for (i = 0; i < iNum; i++)
            {
                ptTemp.x = (Int32)(pt[i].x * Math.Cos(TWOPI * iAngle / 360.0) +
                    pt[i].y * Math.Sin(TWOPI * iAngle / 360.0));

                ptTemp.y = (Int32)(pt[i].y * Math.Cos(TWOPI * iAngle / 360.0) -
                    pt[i].x * Math.Sin(TWOPI * iAngle / 360.0));

                pt[i].x = ptTemp.x; pt[i].y = ptTemp.y;
            }
        }

        private const Double TWOPI = 2 * Math.PI;

        [DllImport("user32.dll")]
        public static extern LRESULT CallWindowProc(HWND lpPrevWndFunc, HWND hWnd, UInt32 msg, WPARAM wParam, LPARAM lParam);

        private void button2_Click(object sender, EventArgs e)
        {
            CustomWindow wind = new CustomWindow("test");
            ShowWindow(wind.m_hwnd, 1);
            UpdateWindow(wind.m_hwnd); 
        }
    }
}
