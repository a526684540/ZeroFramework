/**************************************************
* CLR版本：      4.0.30319.42000
* 类 名 称：       DuiControlBase
* 机器名称：      ZX-PC
* 命名空间：      ZeroFramework.DirectUI
* 文件名：         DuiControlBase
* 创建时间：      2016/7/15 13:30:25
* 作    者：       
* 说    明：
* 修改时间：
* 修 改 人：
**************************************************/

using System.Drawing;

namespace ZeroFramework.DirectUI
{
    public abstract class DuiControlBase
    {
        #region 变量声明、定义

        private bool m_bEnabledEffect;
        private string m_strEffectStyle;

        private TEffectAge m_tCurEffects;
        private TEffectAge m_tMouseInEffects;
        private TEffectAge m_tMouseOutEffects;
        private TEffectAge m_tMouseClickEffects;


        protected DuiUIManager m_oUIManager;
        protected DuiControlBase m_oParent;
        protected string m_strVirtualWnd;           //Duilib未知字段
        protected string m_strName = string.Empty;
        protected bool m_bUpdateNeeded;
        protected bool m_bMenuUsed;

        protected Rectangle m_rcBound;
        protected Rectangle m_rcPadding;
        protected Point m_pLocation;
        protected Point m_pLocationFixed;
        protected Size m_sMinSize;
        protected Size m_sMaxSize;
        protected bool m_bVisible;
        protected bool m_bInternVisible;
        protected bool m_bEnabled;
        protected bool m_bRandom;                   //未知属性
        protected bool m_bMouseEnabled;
        protected bool m_bKeyboardEnabled;
        protected bool m_bFocused;
        protected bool m_bFloat;                    //是否浮动

        protected string m_strStyleName;
        protected string m_strText;
        protected string m_strToolTip;
        protected char m_chShortcut;
        protected string m_strUserData;
        protected object m_objTag;

        protected bool m_bSetPos;                   //防止SetPos循环调用        

        //样式相关
        protected Color m_clrBkColor;
        protected Color m_clrBkColor2;
        protected Color m_clrBkColor3;
        protected Color m_clrDisabledBkColor;
        protected string m_strBkImage = string.Empty;
        protected string m_strForeImage = string.Empty;
        protected Color m_clrBorderColor;
        protected Color m_clrFocusBorderColor;
        protected bool m_bColorHSL;
        protected int m_nBorderSize;
        protected int m_nBorderStyle;
        protected Size m_sBorderRound;              //边框圆角大小
        protected Rectangle m_rcPaint;              //刷新绘制区域
        protected Rectangle m_rcBorderSize;         //边框区域

        #endregion
    }
}
