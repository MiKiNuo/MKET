/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;
namespace ET
{
    [ObjectSystem]
    [FriendClass(typeof(FGUIBaseWindow))]
	public class LoginPanelAwakeSystem : AwakeSystem<LoginPanel>
	{
		public override void Awake(LoginPanel self)
		{
			self.GObject = self.GetParent<FGUIBaseWindow>().UIPrefabGameObject;
			self.UITransform = (GComponent)self.GObject;
		}
	}

    [ObjectSystem]
    public class LoginPanelAwakeSystem1 : AwakeSystem<LoginPanel,GObject>
    {
        public override void Awake(LoginPanel self,GObject transform)
        {
            self.GObject = transform;
            self.UITransform = (GComponent)transform;
        }
    }

    [ObjectSystem]
    public class LoginPanelDestroySystem : DestroySystem<LoginPanel>
    {
        public override void Destroy(LoginPanel self)
        {
            self.GObject?.Dispose();
            self.GObject = null;
            self.UITransform = null;
			self.NameInput = null;
			self.NameText = null;
			self.NameGroup = null;
			self.PasswordInput = null;
			self.PasswordText = null;
			self.PasswordGroup = null;
			self.LoginBtn = null;
			self.RegisterBtn = null;
        }
    }
        
    [FriendClass(typeof(LoginPanel))]
    public static class LoginPanelSystem
    {
        private static GObject CreateGObject(this LoginPanel self)
        {
            return UIPackage.CreateObject(LoginPanel.UIPackageName, LoginPanel.UIResName);
        }

        private static void CreateGObjectAsync(this LoginPanel self,UIPackage.CreateObjectCallback result)
        {
            UIPackage.CreateObjectAsync(LoginPanel.UIPackageName, LoginPanel.UIResName, result);
        }

        public static LoginPanel CreateInstance(this LoginPanel self,Entity domain)
        {
            return domain.AddChild<LoginPanel, GObject>(CreateGObject(self));
        }

        public static async ETTask<LoginPanel> CreateInstanceAsync(this LoginPanel self,Entity domain)
        {
            ETTask<LoginPanel> tcs = ETTask<LoginPanel>.Create(true);
            CreateGObjectAsync(self,(go) =>
            {
                tcs.SetResult(domain.AddChild<LoginPanel, GObject>(go));
            });
            return await tcs;
        }
    }
    
}