/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET
{
    public partial class LoadingPanel : GComponent
    {
        public GProgressBar UpdateProgressBar;
        public GTextField Tips;
        public const string URL = "ui://fv3hjfnrzkmd2";

        public static LoadingPanel CreateInstance()
        {
            return (LoadingPanel)UIPackage.CreateObject("UModel", "LoadingPanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            UpdateProgressBar = (GProgressBar)GetChildAt(0);
            Tips = (GTextField)GetChildAt(1);
        }
    }
}