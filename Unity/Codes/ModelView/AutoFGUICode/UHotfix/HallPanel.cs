/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET
{
    public class HallPanel : Entity,IAwake,IAwake<GObject>,IDestroy
    {
        public const string UIPackageName = "UHotfix";
        public const string UIResName = "HallPanel";
        public const string URL = "ui://fnfxb0ke8zrnb";
        public GObject GObject = null;

        public GComponent UITransform = null;
        public GButton EnterBtn = null;

        public GButton EnterBtn_EnterBtn
        {
            get
            {
                if (this.UITransform == null)
                {
                    Log.Error("UITransform is null.");
                    return null;
                }
                if( this.EnterBtn == null )
                {
                    this.EnterBtn = (GButton)UITransform.GetChildAt(0);
                }
                return this.EnterBtn;
            }
        }
    }
}