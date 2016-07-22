/**************************************************
* CLR版本：      4.0.30319.42000
* 类 名 称：       Enums
* 机器名称：      ZX-PC
* 命名空间：      ZeroFramework.Utils.Win32
* 文件名：         Enums
* 创建时间：      2016/7/15 14:52:45
* 作    者：       
* 说    明：
* 修改时间：
* 修 改 人：
**************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeroFramework.Utils
{
    public class WindowMessages
    {
        #region WindowStyle

        public const int WS_CHILD = 0x40000000;
        public const int WS_VISIBLE = 0x10000000;
        public const int WS_CLIPCHILDREN = 0x2000000;
        public const int WS_CLIPSIBLINGS = 0x4000000;
        public const int WS_BORDER = 0x800000;

        #endregion

        #region WindowMessage

        public const int WM_APP = 0x8000;

        /// <summary>
        /// WM_KEYDOWN 按下一个键
        /// </summary>
        public const int WM_KEYDOWN = 0x0100;

        /// <summary>
        /// 释放一个键
        /// </summary>
        public const int WM_KEYUP = 0x0101;

        /// <summary>
        /// 按下某键，并已发出WM_KEYDOWN， WM_KEYUP消息
        /// </summary>
        public const int WM_CHAR = 0x102;

        /// <summary>
        /// 当用translatemessage函数翻译WM_KEYUP消息时发送此消息给拥有焦点的窗口
        /// </summary>
        public const int WM_DEADCHAR = 0x103;

        /// <summary>
        /// 当用户按住ALT键同时按下其它键时提交此消息给拥有焦点的窗口
        /// </summary>
        public const int WM_SYSKEYDOWN = 0x104;

        /// <summary>
        /// 当用户释放一个键同时ALT 键还按着时提交此消息给拥有焦点的窗口
        /// </summary>
        public const int WM_SYSKEYUP = 0x105;

        /// <summary>
        /// 当WM_SYSKEYDOWN消息被TRANSLATEMESSAGE函数翻译后提交此消息给拥有焦点的窗口
        /// </summary>
        public const int WM_SYSCHAR = 0x106;

        /// <summary>
        /// 当WM_SYSKEYDOWN消息被TRANSLATEMESSAGE函数翻译后发送此消息给拥有焦点的窗口
        /// </summary>
        public const int WM_SYSDEADCHAR = 0x107;

        /// <summary>
        /// 在一个对话框程序被显示前发送此消息给它，通常用此消息初始化控件和执行其它任务
        /// </summary>
        public const int WM_INITDIALOG = 0x110;

        /// <summary>
        /// 当用户选择一条菜单命令项或当某个控件发送一条消息给它的父窗口，一个快捷键被翻译
        /// </summary>
        public const int WM_COMMAND = 0x111;

        /// <summary>
        /// 当用户选择窗口菜单的一条命令或//当用户选择最大化或最小化时那个窗口会收到此消息
        /// </summary>
        public const int WM_SYSCOMMAND = 0x112;

        /// <summary>
        /// 发生了定时器事件
        /// </summary>
        public const int WM_TIMER = 0x113;

        /// <summary>
        /// 当一个窗口标准水平滚动条产生一个滚动事件时发送此消息给那个窗口，也发送给拥有它的控件
        /// </summary>
        public const int WM_HSCROLL = 0x114;

        /// <summary>
        /// 当一个窗口标准垂直滚动条产生一个滚动事件时发送此消息给那个窗口也，发送给拥有它的控件
        /// </summary>
        public const int WM_VSCROLL = 0x115;
        /// <summary>
        /// 当一个菜单将要被激活时发送此消息，它发生在用户菜单条中的某项或按下某个菜单键，它允许程序在显示前更改菜单
        /// </summary>
        public const int WM_INITMENU = 0x116;

        /// <summary>
        /// 当一个下拉菜单或子菜单将要被激活时发送此消息，它允许程序在它显示前更改菜单，而不要改变全部
        /// </summary>
        public const int WM_INITMENUPOPUP = 0x117;

        /// <summary>
        /// 当用户选择一条菜单项时发送此消息给菜单的所有者（一般是窗口）
        /// </summary>
        public const int WM_MENUSELECT = 0x11F;

        /// <summary>
        /// 当菜单已被激活用户按下了某个键（不同于加速键），发送此消息给菜单的所有者
        /// </summary>
        public const int WM_MENUCHAR = 0x120;

        /// <summary>
        /// 当一个模态对话框或菜单进入空载状态时发送此消息给它的所有者，一个模态对话框或菜单进入空载状态就是在处理完一条或几条先前的消息后没有消息它的列队中等待
        /// </summary>
        public const int WM_ENTERIDLE = 0x121;

        /// <summary>
        /// 在windows绘制消息框前发送此消息给消息框的所有者窗口，通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置消息框的文本和背景颜色
        /// </summary>
        public const int WM_CTLCOLORMSGBOX = 0x132;

        /// <summary>
        /// 当一个编辑型控件将要被绘制时发送此消息给它的父窗口通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置编辑框的文本和背景颜色
        /// </summary>
        public const int WM_CTLCOLOREDIT = 0x133;

        /// <summary>
        /// 当一个列表框控件将要被绘制前发送此消息给它的父窗口通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置列表框的文本和背景颜色
        /// </summary>
        public const int WM_CTLCOLORLISTBOX = 0x134;

        /// <summary>
        /// 当一个按钮控件将要被绘制时发送此消息给它的父窗口通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置按纽的文本和背景颜色
        /// </summary>
        public const int WM_CTLCOLORBTN = 0x135;

        /// <summary>
        /// 当一个对话框控件将要被绘制前发送此消息给它的父窗口通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置对话框的文本背景颜色
        /// </summary>
        public const int WM_CTLCOLORDLG = 0x136;

        /// <summary>
        /// 当一个滚动条控件将要被绘制时发送此消息给它的父窗口通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置滚动条的背景颜色
        /// </summary>
        public const int WM_CTLCOLORSCROLLBAR = 0x137;

        /// <summary>
        /// 当一个静态控件将要被绘制时发送此消息给它的父窗口通过响应这条消息，所有者窗口可以 通过使用给定的相关显示设备的句柄来设置静态控件的文本和背景颜色
        /// </summary>
        public const int WM_CTLCOLORSTATIC = 0x138;

        /// <summary>
        /// 当鼠标轮子转动时发送此消息个当前有焦点的控件
        /// </summary>
        public const int WM_MOUSEWHEEL = 0x20A;

        /// <summary>
        /// 双击鼠标中键
        /// </summary>
        public const int WM_MBUTTONDBLCLK = 0x209;

        /// <summary>
        /// 释放鼠标中键
        /// </summary>
        public const int WM_MBUTTONUP = 0x208;

        /// <summary>
        /// 移动鼠标时发生，同WM_MOUSEFIRST
        /// </summary>
        public const int WM_MOUSEMOVE = 0x200;

        /// <summary>
        /// 鼠标悬停
        /// </summary>
        public const int WM_MOUSEHOVER = 0x02A1;

        /// <summary>
        /// 鼠标离开
        /// </summary>
        public const int WM_MOUSELEAVE = 0x02A3;

        /// <summary>
        /// 按下鼠标左键
        /// </summary>
        public const int WM_LBUTTONDOWN = 0x201;

        /// <summary>
        /// 释放鼠标左键
        /// </summary>
        public const int WM_LBUTTONUP = 0x202;

        /// <summary>
        /// 双击鼠标左键
        /// </summary>
        public const int WM_LBUTTONDBLCLK = 0x203;

        /// <summary>
        /// 按下鼠标右键
        /// </summary>
        public const int WM_RBUTTONDOWN = 0x204;

        /// <summary>
        /// 释放鼠标右键
        /// </summary>
        public const int WM_RBUTTONUP = 0x205;

        /// <summary>
        /// 双击鼠标右键
        /// </summary>
        public const int WM_RBUTTONDBLCLK = 0x206;

        /// <summary>
        /// 按下鼠标中键
        /// </summary>
        public const int WM_MBUTTONDOWN = 0x207;

        /// <summary>
        /// 用户定义的消息ID
        /// </summary>
        public const int WM_USER = 0x0400;

        /// <summary>
        /// 创建一个窗口
        /// </summary>
        public const int WM_CREATE = 0x01;

        /// <summary>
        /// 当一个窗口被破坏时发送
        /// </summary>
        public const int WM_DESTROY = 0x02;

        /// <summary>
        /// 移动一个窗口
        /// </summary>
        public const int WM_MOVE = 0x03;

        /// <summary>
        /// 改变一个窗口的大小
        /// </summary>
        public const int WM_SIZE = 0x05;

        /// <summary>
        /// 一个窗口被激活或失去激活状态
        /// </summary>
        public const int WM_ACTIVATE = 0x06;

        /// <summary>
        /// 一个窗口获得焦点
        /// </summary>
        public const int WM_SETFOCUS = 0x07;

        /// <summary>
        /// 一个窗口失去焦点
        /// </summary>
        public const int WM_KILLFOCUS = 0x08;

        /// <summary>
        /// 一个窗口改变成Enable状态
        /// </summary>
        public const int WM_ENABLE = 0x0A;

        /// <summary>
        /// 设置窗口是否能重画
        /// </summary>
        public const int WM_SETREDRAW = 0x0B;

        /// <summary>
        /// 应用程序发送此消息来设置一个窗口的文本
        /// </summary>
        public const int WM_SETTEXT = 0x0C;

        /// <summary>
        /// 应用程序发送此消息来复制对应窗口的文本到缓冲区
        /// </summary>
        public const int WM_GETTEXT = 0x0D;

        /// <summary>
        /// 得到与一个窗口有关的文本的长度（不包含空字符）
        /// </summary>
        public const int WM_GETTEXTLENGTH = 0x0E;

        /// <summary>
        /// 要求一个窗口重画自己
        /// </summary>
        public const int WM_PAINT = 0x000F;

        /// <summary>
        /// 
        /// </summary>
        public const int WM_PRINT = 0x0317;

        /// <summary>
        /// 
        /// </summary>
        public const int WM_PRINTCLIENT = 0x0318;

        /// <summary>
        /// 当一个窗口或应用程序要关闭时发送一个信号
        /// </summary>
        public const int WM_CLOSE = 0x0010;

        /// <summary>
        /// 当用户选择结束对话框或程序自己调用ExitWindows函数
        /// </summary>
        public const int WM_QUERYENDSESSION = 0x0011;

        /// <summary>
        /// 用来结束程序运行
        /// </summary>
        public const int WM_QUIT = 0x0012;

        /// <summary>
        /// 当用户窗口恢复以前的大小位置时，把此消息发送给某个图标
        /// </summary>
        public const int WM_QUERYOPEN = 0x13;

        /// <summary>
        /// 当窗口背景必须被擦除时（例在窗口改变大小时）
        /// </summary>
        public const int WM_ERASEBKGND = 0x14;

        /// <summary>
        /// 当系统颜色改变时，发送此消息给所有顶级窗口
        /// </summary>
        public const int WM_SYSCOLORCHANGE = 0x15;

        /// <summary>
        /// 当系统进程发出WM_QUERYENDSESSION消息后，此消息发送给应用程序，通知它对话是否结束
        /// </summary>
        public const int WM_ENDSESSION = 0x16;

        /// <summary>
        /// 当隐藏或显示窗口是发送此消息给这个窗口
        /// </summary>
        public const int WM_SHOWWINDOW = 0x18;

        /// <summary>
        /// 发此消息给应用程序哪个窗口是激活的，哪个是非激活的
        /// </summary>
        public const int WM_ACTIVATEAPP = 0x1C;

        /// <summary>
        /// 当系统的字体资源库变化时发送此消息给所有顶级窗口
        /// </summary>
        public const int WM_FONTCHANGE = 0x1D;

        /// <summary>
        /// 当系统的时间变化时发送此消息给所有顶级窗口
        /// </summary>
        public const int WM_TIMECHANGE = 0x1E;

        /// <summary>
        /// 发送此消息来取消某种正在进行的摸态（操作）
        /// </summary>
        public const int WM_CANCELMODE = 0x1F;

        /// <summary>
        /// 如果鼠标引起光标在某个窗口中移动且鼠标输入没有被捕获时，就发消息给某个窗口
        /// </summary>
        public const int WM_SETCURSOR = 0x20;

        /// <summary>
        /// 当光标在某个非激活的窗口中而用户正按着鼠标的某个键发送此消息给//当前窗口
        /// </summary>
        public const int WM_MOUSEACTIVATE = 0x21;

        /// <summary>
        /// 发送此消息给MDI子窗口//当用户点击此窗口的标题栏，或//当窗口被激活，移动，改变大小
        /// </summary>
        public const int WM_CHILDACTIVATE = 0x22;

        /// <summary>
        /// 此消息由基于计算机的训练程序发送，通过WH_JOURNALPALYBACK的hook程序分离出用户输入消息
        /// </summary>
        public const int WM_QUEUESYNC = 0x23;

        /// <summary>
        /// 此消息发送给窗口当它将要改变大小或位置
        /// </summary>
        public const int WM_GETMINMAXINFO = 0x24;

        /// <summary>
        /// 发送给最小化窗口当它图标将要被重画
        /// </summary>
        public const int WM_PAINTICON = 0x26;

        /// <summary>
        /// 此消息发送给某个最小化窗口，仅//当它在画图标前它的背景必须被重画
        /// </summary>
        public const int WM_ICONERASEBKGND = 0x27;

        /// <summary>
        /// 发送此消息给一个对话框程序去更改焦点位置
        /// </summary>
        public const int WM_NEXTDLGCTL = 0x28;

        /// <summary>
        /// 每当打印管理列队增加或减少一条作业时发出此消息
        /// </summary>
        public const int WM_SPOOLERSTATUS = 0x2A;

        /// <summary>
        /// 当button，combobox，listbox，menu的可视外观改变时发送
        /// </summary>
        public const int WM_DRAWITEM = 0x2B;

        /// <summary>
        /// 当button, combo box, list box, list view control, or menu item 被创建时
        /// </summary>
        public const int WM_MEASUREITEM = 0x2C;

        /// <summary>
        /// 此消息有一个LBS_WANTKEYBOARDINPUT风格的发出给它的所有者来响应WM_KEYDOWN消息
        /// </summary>
        public const int WM_VKEYTOITEM = 0x2E;

        /// <summary>
        /// 此消息由一个LBS_WANTKEYBOARDINPUT风格的列表框发送给他的所有者来响应WM_CHAR消息
        /// </summary>
        public const int WM_CHARTOITEM = 0x2F;

        /// <summary>
        /// 当绘制文本时程序发送此消息得到控件要用的颜色
        /// </summary>
        public const int WM_SETFONT = 0x30;

        /// <summary>
        /// 应用程序发送此消息得到当前控件绘制文本的字体
        /// </summary>
        public const int WM_GETFONT = 0x31;

        /// <summary>
        /// 应用程序发送此消息让一个窗口与一个热键相关连
        /// </summary>
        public const int WM_SETHOTKEY = 0x32;

        /// <summary>
        /// 应用程序发送此消息来判断热键与某个窗口是否有关联
        /// </summary>
        public const int WM_GETHOTKEY = 0x33;

        /// <summary>
        /// 此消息发送给最小化窗口，当此窗口将要被拖放而它的类中没有定义图标，应用程序能返回一个图标或光标的句柄，当用户拖放图标时系统显示这个图标或光标
        /// </summary>
        public const int WM_QUERYDRAGICON = 0x37;

        /// <summary>
        /// 发送此消息来判定combobox或listbox新增加的项的相对位置
        /// </summary>
        public const int WM_COMPAREITEM = 0x39;

        /// <summary>
        /// 显示内存已经很少了
        /// </summary>
        public const int WM_COMPACTING = 0x41;

        /// <summary>
        /// 发送此消息给那个窗口的大小和位置将要被改变时，来调用setwindowpos函数或其它窗口管理函数
        /// </summary>
        public const int WM_WINDOWPOSCHANGING = 0x46;

        /// <summary>
        /// 发送此消息给那个窗口的大小和位置已经被改变时，来调用setwindowpos函数或其它窗口管理函数
        /// </summary>
        public const int WM_WINDOWPOSCHANGED = 0x47;

        /// <summary>
        /// 当系统将要进入暂停状态时发送此消息
        /// </summary>
        public const int WM_POWER = 0x48;

        /// <summary>
        /// 当一个应用程序传递数据给另一个应用程序时发送此消息
        /// </summary>
        public const int WM_COPYDATA = 0x4A;

        /// <summary>
        /// 当某个用户取消程序日志激活状态，提交此消息给程序
        /// </summary>
        public const int WM_CANCELJOURNA = 0x4B;

        /// <summary>
        /// 当某个控件的某个事件已经发生或这个控件需要得到一些信息时，发送此消息给它的父窗口
        /// </summary>
        public const int WM_NOTIFY = 0x4E;

        /// <summary>
        /// 当用户选择某种输入语言，或输入语言的热键改变
        /// </summary>
        public const int WM_INPUTLANGCHANGEREQUEST = 0x50;

        /// <summary>
        /// 当平台现场已经被改变后发送此消息给受影响的最顶级窗口
        /// </summary>
        public const int WM_INPUTLANGCHANGE = 0x51;

        /// <summary>
        /// 当程序已经初始化windows帮助例程时发送此消息给应用程序
        /// </summary>
        public const int WM_TCARD = 0x52;

        /// <summary>
        /// 此消息显示用户按下了F1，如果某个菜单是激活的，就发送此消息个此窗口关联的菜单，否则就发送给有焦点的窗口，如果//当前都没有焦点，就把此消息发送给//当前激活的窗口
        /// </summary>
        public const int WM_HELP = 0x53;

        /// <summary>
        /// 当用户已经登入或退出后发送此消息给所有的窗口，//当用户登入或退出时系统更新用户的具体设置信息，在用户更新设置时系统马上发送此消息
        /// </summary>
        public const int WM_USERCHANGED = 0x54;

        /// <summary>
        /// 公用控件，自定义控件和他们的父窗口通过此消息来判断控件是使用ANSI还是UNICODE结构
        /// </summary>
        public const int WM_NOTIFYFORMAT = 0x55;

        /// <summary>
        /// 当用户某个窗口中点击了一下右键就发送此消息给这个窗口
        /// </summary>
        public const int WM_CONTEXTMENU = 0x007B;

        /// <summary>
        /// 当调用SETWINDOWLONG函数将要改变一个或多个 窗口的风格时发送此消息给那个窗口
        /// </summary>
        public const int WM_STYLECHANGING = 0x7C;

        /// <summary>
        /// 当调用SETWINDOWLONG函数一个或多个 窗口的风格后发送此消息给那个窗口
        /// </summary>
        public const int WM_STYLECHANGED = 0x7D;

        /// <summary>
        /// 当显示器的分辨率改变后发送此消息给所有的窗口
        /// </summary>
        public const int WM_DISPLAYCHANGE = 0x7E;

        /// <summary>
        /// 此消息发送给某个窗口来返回与某个窗口有关连的大图标或小图标的句柄
        /// </summary>
        public const int WM_GETICON = 0x7F;

        /// <summary>
        /// 程序发送此消息让一个新的大图标或小图标与某个窗口关联
        /// </summary>
        public const int WM_SETICON = 0x80;

        /// <summary>
        /// 当某个窗口第一次被创建时，此消息在WM_CREATE消息发送前发送
        /// </summary>
        public const int WM_NCCREATE = 0x81;

        /// <summary>
        /// 此消息通知某个窗口，非客户区正在销毁
        /// </summary>
        public const int WM_NCDESTROY = 0x82;

        /// <summary>
        /// 当某个窗口的客户区域必须被核算时发送此消息
        /// </summary>
        public const int WM_NCCALCSIZE = 0x83;

        /// <summary>
        /// 移动鼠标，按住或释放鼠标时发生
        /// </summary>
        public const int WM_NCHITTEST = 0x84;

        /// <summary>
        /// 程序发送此消息给某个窗口当它（窗口）的框架必须被绘制时
        /// </summary>
        public const int WM_NCPAINT = 0x85;

        /// <summary>
        /// 此消息发送给某个窗口仅当它的非客户区需要被改变来显示是激活还是非激活状态
        /// </summary>
        public const int WM_NCACTIVATE = 0x86;

        /// <summary>
        /// 发送此消息给某个与对话框程序关联的控件，widdows控制方位键和TAB键使输入进入此控件通过应
        /// </summary>
        public const int WM_GETDLGCODE = 0x87;

        /// <summary>
        /// 当光标在一个窗口的非客户区内移动时发送此消息给这个窗口 非客户区为：窗体的标题栏及窗 的边框体
        /// </summary>
        public const int WM_NCMOUSEMOVE = 0xA0;

        /// <summary>
        /// 当光标在一个窗口的非客户区同时按下鼠标左键时提交此消息
        /// </summary>
        public const int WM_NCLBUTTONDOWN = 0xA1;

        /// <summary>
        /// 当用户释放鼠标左键同时光标某个窗口在非客户区十发送此消息
        /// </summary>
        public const int WM_NCLBUTTONUP = 0xA2;

        /// <summary>
        /// 当用户双击鼠标左键同时光标某个窗口在非客户区十发送此消息
        /// </summary>
        public const int WM_NCLBUTTONDBLCLK = 0xA3;

        /// <summary>
        /// 当用户按下鼠标右键同时光标又在窗口的非客户区时发送此消息
        /// </summary>
        public const int WM_NCRBUTTONDOWN = 0xA4;

        /// <summary>
        /// 当用户释放鼠标右键同时光标又在窗口的非客户区时发送此消息
        /// </summary>
        public const int WM_NCRBUTTONUP = 0xA5;

        /// <summary>
        /// 当用户双击鼠标右键同时光标某个窗口在非客户区十发送此消息
        /// </summary>
        public const int WM_NCRBUTTONDBLCLK = 0xA6;

        /// <summary>
        /// 当用户按下鼠标中键同时光标又在窗口的非客户区时发送此消息
        /// </summary>
        public const int WM_NCMBUTTONDOWN = 0xA7;

        /// <summary>
        /// 当用户释放鼠标中键同时光标又在窗口的非客户区时发送此消息
        /// </summary>
        public const int WM_NCMBUTTONUP = 0xA8;

        /// <summary>
        /// 当用户双击鼠标中键同时光标又在窗口的非客户区时发送此消息
        /// </summary>
        public const int WM_NCMBUTTONDBLCLK = 0xA9;

        #endregion

        #region 鼠标按键

        public const int MK_LBUTTON = 0x0001;
        public const int MK_RBUTTON = 0x0002;
        public const int MK_SHIFT = 0x0004;
        public const int MK_CONTROL = 0x0008;
        public const int MK_MBUTTON = 0x0010;
        public const int MK_XBUTTON1 = 0x0020;
        public const int MK_XBUTTON2 = 0x0040;

        #endregion

        public const int Mouse_Move = 0x0001;
        public const int Mouse_LeftDown = 0x0002;
        public const int Mouse_LeftUp = 0x0004;
        public const int Mouse_RightDown = 0x0008;
        public const int Mouse_RightUp = 0x0010;
        public const int Mouse_MiddleDown = 0x0020;
        public const int Mouse_MiddleUp = 0x0040;
        public const int Mouse_Wheel = 0x0800;
        public const int Mouse_Absolute = 0x8000;

        public const int KEYEVENTF_EXTENDEDKEY = 0x1;
        public const int KEYEVENTF_KEYUP = 0x2;
        public const int KEYEVENTF_KEYDOWN = 0x00;

        /// <summary>
        /// 获取系统宽度
        /// </summary>
        public const int SM_CXSCREEN = 0;
        /// <summary>
        /// 获取系统高度
        /// </summary>
        public const int SM_CYSCREEN = 1;
    }

    #region ShowWindowStyles

    /// <summary>
    /// 窗口显示状态
    /// </summary>
    public class ShowWindowStyles
    {
        public const int SW_HIDE = 0;
        public const int SW_SHOWNORMAL = 1;
        public const int SW_SHOWMINIMIZED = 2;
        public const int SW_SHOWMAXIMIZED = 3;
        public const int SW_MAXIMIZE = 3;
        public const int SW_SHOWNOACTIVATE = 4;
        public const int SW_SHOW = 5;
        public const int SW_MINIMIZE = 6;
        public const int SW_SHOWMINNOACTIVE = 7;
        public const int SW_SHOWNA = 8;
        public const int SW_RESTORE = 9;
    }

    #endregion

    #region SetWindowPosFlags

    public class SetWindowPosFlags
    {
        public const int SWP_NOSIZE = 0x0001;
        public const int SWP_NOMOVE = 0x0002;
        public const int SWP_NOZORDER = 0x0004;
        public const int SWP_NOREDRAW = 0x0008;
        public const int SWP_NOACTIVATE = 0x0010;
        public const int SWP_FRAMECHANGED = 0x0020;
        public const int SWP_SHOWWINDOW = 0x0040;
        public const int SWP_HIDEWINDOW = 0x0080;
        public const int SWP_NOCOPYBITS = 0x0100;
        public const int SWP_NOOWNERZORDER = 0x0200;
        public const int SWP_NOSENDCHANGING = 0x0400;
        public const int SWP_DRAWFRAME = 0x0020;
        public const int SWP_NOREPOSITION = 0x0200;
        public const int SWP_DEFERERASE = 0x2000;
        public const int SWP_ASYNCWINDOWPOS = 0x4000;
    }

    #endregion

    #region Virtual Keys

    public enum VirtualKeys
    {
        VK_LBUTTON = 0x01,
        VK_CANCEL = 0x03,
        VK_BACK = 0x08,
        VK_TAB = 0x09,
        VK_CLEAR = 0x0C,
        VK_RETURN = 0x0D,
        VK_SHIFT = 0x10,
        VK_CONTROL = 0x11,
        VK_MENU = 0x12,
        VK_CAPITAL = 0x14,
        VK_ESCAPE = 0x1B,
        VK_SPACE = 0x20,
        VK_PRIOR = 0x21,
        VK_NEXT = 0x22,
        VK_END = 0x23,
        VK_HOME = 0x24,
        VK_LEFT = 0x25,
        VK_UP = 0x26,
        VK_RIGHT = 0x27,
        VK_DOWN = 0x28,
        VK_SELECT = 0x29,
        VK_EXECUTE = 0x2B,
        VK_SNAPSHOT = 0x2C,
        VK_HELP = 0x2F,
        VK_0 = 0x30,
        VK_1 = 0x31,
        VK_2 = 0x32,
        VK_3 = 0x33,
        VK_4 = 0x34,
        VK_5 = 0x35,
        VK_6 = 0x36,
        VK_7 = 0x37,
        VK_8 = 0x38,
        VK_9 = 0x39,
        VK_A = 0x41,
        VK_B = 0x42,
        VK_C = 0x43,
        VK_D = 0x44,
        VK_E = 0x45,
        VK_F = 0x46,
        VK_G = 0x47,
        VK_H = 0x48,
        VK_I = 0x49,
        VK_J = 0x4A,
        VK_K = 0x4B,
        VK_L = 0x4C,
        VK_M = 0x4D,
        VK_N = 0x4E,
        VK_O = 0x4F,
        VK_P = 0x50,
        VK_Q = 0x51,
        VK_R = 0x52,
        VK_S = 0x53,
        VK_T = 0x54,
        VK_U = 0x55,
        VK_V = 0x56,
        VK_W = 0x57,
        VK_X = 0x58,
        VK_Y = 0x59,
        VK_Z = 0x5A,
        VK_NUMPAD0 = 0x60,
        VK_NUMPAD1 = 0x61,
        VK_NUMPAD2 = 0x62,
        VK_NUMPAD3 = 0x63,
        VK_NUMPAD4 = 0x64,
        VK_NUMPAD5 = 0x65,
        VK_NUMPAD6 = 0x66,
        VK_NUMPAD7 = 0x67,
        VK_NUMPAD8 = 0x68,
        VK_NUMPAD9 = 0x69,
        VK_MULTIPLY = 0x6A,
        VK_ADD = 0x6B,
        VK_SEPARATOR = 0x6C,
        VK_SUBTRACT = 0x6D,
        VK_DECIMAL = 0x6E,
        VK_DIVIDE = 0x6F,
        VK_ATTN = 0xF6,
        VK_CRSEL = 0xF7,
        VK_EXSEL = 0xF8,
        VK_EREOF = 0xF9,
        VK_PLAY = 0xFA,
        VK_ZOOM = 0xFB,
        VK_NONAME = 0xFC,
        VK_PA1 = 0xFD,
        VK_OEM_CLEAR = 0xFE,
        VK_LWIN = 0x5B,
        VK_RWIN = 0x5C,
        VK_APPS = 0x5D,
        VK_LSHIFT = 0xA0,
        VK_RSHIFT = 0xA1,
        VK_LCONTROL = 0xA2,
        VK_RCONTROL = 0xA3,
        VK_LMENU = 0xA4,
        VK_RMENU = 0xA5
    }

    #endregion

    #region Update Layered Windows Flags

    public enum UpdateLayeredWindowsFlags
    {
        ULW_COLORKEY = 0x00000001,
        ULW_ALPHA = 0x00000002,
        ULW_OPAQUE = 0x00000004
    }

    #endregion

    #region Alpha Flags
    public enum AlphaFlags : byte
    {
        AC_SRC_OVER = 0x00,
        AC_SRC_ALPHA = 0x01
    }
    #endregion

    #region SetWindowLong indexes
    public enum SetWindowLongOffsets : int
    {
        GWL_WNDPROC = (-4),
        GWL_HINSTANCE = (-6),
        GWL_HWNDPARENT = (-8),
        GWL_STYLE = (-16),
        GWL_EXSTYLE = (-20),
        GWL_USERDATA = (-21),
        GWL_ID = (-12)
    }
    #endregion

    #region HitTest
    public enum HitTest
    {
        HTERROR = (-2),
        HTTRANSPARENT = (-1),
        HTNOWHERE = 0,
        HTCLIENT = 1,
        HTCAPTION = 2,
        HTSYSMENU = 3,
        HTGROWBOX = 4,
        HTSIZE = HTGROWBOX,
        HTMENU = 5,
        HTHSCROLL = 6,
        HTVSCROLL = 7,
        HTMINBUTTON = 8,
        HTMAXBUTTON = 9,
        HTLEFT = 10,
        HTRIGHT = 11,
        HTTOP = 12,
        HTTOPLEFT = 13,
        HTTOPRIGHT = 14,
        HTBOTTOM = 15,
        HTBOTTOMLEFT = 16,
        HTBOTTOMRIGHT = 17,
        HTBORDER = 18,
        HTREDUCE = HTMINBUTTON,
        HTZOOM = HTMAXBUTTON,
        HTSIZEFIRST = HTLEFT,
        HTSIZELAST = HTBOTTOMRIGHT,
        HTOBJECT = 19,
        HTCLOSE = 20,
        HTHELP = 21
    }
    #endregion

    #region Background Mode
    public enum BackgroundMode
    {
        TRANSPARENT = 1,
        OPAQUE = 2
    }
    #endregion

    #region WindowStyle

    public class WindowStyles
    {
        public const int WS_EX_LAYERED = 0x00080000;
    }

    #endregion

    public class TernaryRasterOperations
    {
        public const int SRCCOPY = 0x00CC0020; /* dest = source*/
        public const int SRCPAINT = 0x00EE0086; /* dest = source OR dest*/
        public const int SRCAND = 0x008800C6; /* dest = source AND dest*/
        public const int SRCINVERT = 0x00660046; /* dest = source XOR dest*/
        public const int SRCERASE = 0x00440328; /* dest = source AND (NOT dest )*/
        public const int NOTSRCCOPY = 0x00330008; /* dest = (NOT source)*/
        public const int NOTSRCERASE = 0x001100A6; /* dest = (NOT src) AND (NOT dest) */
        public const int MERGECOPY = 0x00C000CA; /* dest = (source AND pattern)*/
        public const int MERGEPAINT = 0x00BB0226; /* dest = (NOT source) OR dest*/
        public const int PATCOPY = 0x00F00021; /* dest = pattern*/
        public const int PATPAINT = 0x00FB0A09; /* dest = DPSnoo*/
        public const int PATINVERT = 0x005A0049; /* dest = pattern XOR dest*/
        public const int DSTINVERT = 0x00550009; /* dest = (NOT dest)*/
        public const int BLACKNESS = 0x00000042; /* dest = BLACK*/
        public const int WHITENESS = 0x00FF0062; /* dest = WHITE*/
    }

    public class WM_PRINT_Flags
    {
        public const long PRF_CHECKVISIBLE = 0x00000001L;
        public const long PRF_NONCLIENT = 0x00000002L;
        public const long PRF_CLIENT = 0x00000004L;
        public const long PRF_ERASEBKGND = 0x00000008L;
        public const long PRF_CHILDREN = 0x00000010L;
        public const long PRF_OWNED = 0x00000020L;
    }

    public class GetWindowFlags
    {
        public const int GW_HWNDFIRST = 0;
        public const int GW_HWNDLAST = 1;
        public const int GW_HWNDNEXT = 2;
        public const int GW_HWNDPREV = 3;
        public const int GW_OWNER = 4;
        public const int GW_CHILD = 5;
        public const int GW_ENABLEDPOPUP = 6;
        public const int GW_MAX = 6;
    }
}
