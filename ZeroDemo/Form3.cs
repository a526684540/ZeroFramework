/**************************************************
* CLR版本 ：    4.0.30319.42000
* 类 名 称：    Form3
* 机器名称：    ZX-PC
* 命名空间：    ZeroDemo
* 文件名  ：    Form3
* 创建时间：    2016/7/18 9:47:42
* 作    者：   
* 说    明：
* 修改时间：
* 修 改 人：
**************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZeroFramework.DirectUI;

namespace ZeroDemo
{
    using ZeroFramework.Utils;

    public partial class Form3 : Form
    {
        DuiHostBase t = null;

        public Form3()
        {
            t = new DuiHostBase(this);            
            InitializeComponent();
            //this.HandleCreated += userControl11_HandleCreated;
            //this.HandleDestroyed += userControl11_HandleDestroyed;
        }

        void userControl11_HandleDestroyed(object sender, EventArgs e)
        {
            t.Dispose();
        }

        void userControl11_HandleCreated(object sender, EventArgs e)
        {
            //t = new DuiHostBase();
            //t.Init(this);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            NativeMethods.SendMessage(userControl11.Handle, WindowMessages.WM_SETFOCUS, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WindowMessages.WM_CREATE:
                    break;
                default:
                    break;
            }

            base.WndProc(ref m);
        }

        protected override void OnClosed(EventArgs e)
        {
            t.Dispose();
            base.OnClosed(e);

        }
    }
}
