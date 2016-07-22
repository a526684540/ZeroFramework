using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZeroFramework.Utils;

namespace ZeroDemo
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.Selectable, true);
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

    }
}
