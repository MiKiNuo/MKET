/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET
{
    public class LoginPanel : Entity,IAwake,IAwake<GObject>,IDestroy
    {
        public const string UIPackageName = "UHotfix";
        public const string UIResName = "LoginPanel";
        public const string URL = "ui://fnfxb0kezkmd6";
        public GObject GObject = null;

        public GComponent UITransform = null;
        public GTextInput NameInput = null;
        public GTextField NameText = null;
        public GGroup NameGroup = null;
        public GTextInput PasswordInput = null;
        public GTextField PasswordText = null;
        public GGroup PasswordGroup = null;
        public GButton LoginBtn = null;
        public GButton RegisterBtn = null;

        public GTextInput NameInput_NameInput
        {
            get
            {
                if (this.UITransform == null)
                {
                    Log.Error("UITransform is null.");
                    return null;
                }
                if( this.NameInput == null )
                {
                    this.NameInput = (GTextInput)UITransform.GetChildAt(0);
                }
                return this.NameInput;
            }
        }
        public GTextField NameText_NameText
        {
            get
            {
                if (this.UITransform == null)
                {
                    Log.Error("UITransform is null.");
                    return null;
                }
                if( this.NameText == null )
                {
                    this.NameText = (GTextField)UITransform.GetChildAt(1);
                }
                return this.NameText;
            }
        }
        public GGroup NameGroup_NameGroup
        {
            get
            {
                if (this.UITransform == null)
                {
                    Log.Error("UITransform is null.");
                    return null;
                }
                if( this.NameGroup == null )
                {
                    this.NameGroup = (GGroup)UITransform.GetChildAt(2);
                }
                return this.NameGroup;
            }
        }
        public GTextInput PasswordInput_PasswordInput
        {
            get
            {
                if (this.UITransform == null)
                {
                    Log.Error("UITransform is null.");
                    return null;
                }
                if( this.PasswordInput == null )
                {
                    this.PasswordInput = (GTextInput)UITransform.GetChildAt(3);
                }
                return this.PasswordInput;
            }
        }
        public GTextField PasswordText_PasswordText
        {
            get
            {
                if (this.UITransform == null)
                {
                    Log.Error("UITransform is null.");
                    return null;
                }
                if( this.PasswordText == null )
                {
                    this.PasswordText = (GTextField)UITransform.GetChildAt(4);
                }
                return this.PasswordText;
            }
        }
        public GGroup PasswordGroup_PasswordGroup
        {
            get
            {
                if (this.UITransform == null)
                {
                    Log.Error("UITransform is null.");
                    return null;
                }
                if( this.PasswordGroup == null )
                {
                    this.PasswordGroup = (GGroup)UITransform.GetChildAt(5);
                }
                return this.PasswordGroup;
            }
        }
        public GButton LoginBtn_LoginBtn
        {
            get
            {
                if (this.UITransform == null)
                {
                    Log.Error("UITransform is null.");
                    return null;
                }
                if( this.LoginBtn == null )
                {
                    this.LoginBtn = (GButton)UITransform.GetChildAt(6);
                }
                return this.LoginBtn;
            }
        }
        public GButton RegisterBtn_RegisterBtn
        {
            get
            {
                if (this.UITransform == null)
                {
                    Log.Error("UITransform is null.");
                    return null;
                }
                if( this.RegisterBtn == null )
                {
                    this.RegisterBtn = (GButton)UITransform.GetChildAt(7);
                }
                return this.RegisterBtn;
            }
        }
    }
}