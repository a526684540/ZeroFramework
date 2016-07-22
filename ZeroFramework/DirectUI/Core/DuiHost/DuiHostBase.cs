/**************************************************
* CLR版本 ：    4.0.30319.42000
* 类 名 称：    DuiHostBase
* 机器名称：    ZX-PC
* 命名空间：    ZeroFramework.DirectUI.Core
* 文件名  ：    DuiHostBase
* 创建时间：    2016/7/18 14:32:43
* 作    者：   
* 说    明：
* 修改时间：
* 修 改 人：
**************************************************/

using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ZeroFramework.DirectUI
{
    using Utils;

    public class DuiHostBase : NativeWindow, IDisposable
    {
        protected Control m_HostControl;
        protected DuiUIManager m_PatientUIMagager = null;

        protected bool m_IsFilterHostMessage = false;

        #region 构造函数

        public DuiHostBase(Control host)
        {
            m_HostControl = host;
            m_PatientUIMagager = new DuiUIManager();
            m_PatientUIMagager.Init(this);
            AssignHandle(host.Handle);
        }


        #endregion

        #region 内部函数

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WindowMessages.WM_NCCREATE)
            {

            }
            else
            {
                if (m.Msg == WindowMessages.WM_NCDESTROY)
                {
                    base.WndProc(ref m);
                    this.m_HostControl = null;
                    this.OnFinalMessage(m.HWnd);
                    return;
                }
            }

            this.HandleMessage(m);
        }

        internal bool CheckHostHandle(IntPtr handle)
        {
            return m_HostControl.Handle == handle;
        }

        #endregion

        public IntPtr GetHwnd()
        {
            return m_HostControl.Handle;
        }

        public virtual void Initialize()
        {

        }

        public virtual void OnFinalMessage(IntPtr hWnd)
        {

        }

        public virtual int HandleMessage(Message m)
        {
            int nRes = 0;
            //if (!m_PatientUIMagager.MessageHandler(m.Msg, m.WParam, m.LParam, ref nRes))

            switch (m.Msg)
            {
                case WindowMessages.WM_CREATE:
                    break;
                default:
                    break;
            }

            base.DefWndProc(ref m);
            nRes = m.Result.ToInt32();
            return nRes;
        }

        public void Dispose()
        {
            m_HostControl = null;
            ReleaseHandle();
        }
    }
}
