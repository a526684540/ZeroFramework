/**************************************************
* CLR版本：      4.0.30319.42000
* 类 名 称：       Form2
* 机器名称：      ZX-PC
* 命名空间：      ZeroDemo
* 文件名：         Form2
* 创建时间：      2016/7/13 16:39:12
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

namespace ZeroDemo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00080000;  //  WS_EX_LAYERED 扩展样式
                return cp;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.Invalidate(new Rectangle(e.Location, new Size(20, 20)));
        }


        protected override void OnPaint(PaintEventArgs e)
        {            
            Console.WriteLine("OnPaint:" + e.ClipRectangle.ToString());
            base.OnPaint(e);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x000F)
            {
                Console.WriteLine("WM_PAINT");
            }

            base.WndProc(ref m);
        }
    }
}
