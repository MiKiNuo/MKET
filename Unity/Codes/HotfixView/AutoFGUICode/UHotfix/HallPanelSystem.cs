/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;
namespace ET
{
    [ObjectSystem]
    [FriendClass(typeof(FGUIBaseWindow))]
	public class HallPanelAwakeSystem : AwakeSystem<HallPanel>
	{
		public override void Awake(HallPanel self)
		{
			self.GObject = self.GetParent<FGUIBaseWindow>().UIPrefabGameObject;
			self.UITransform = (GComponent)self.GObject;
		}
	}

    [ObjectSystem]
    public class HallPanelAwakeSystem1 : AwakeSystem<HallPanel,GObject>
    {
        public override void Awake(HallPanel self,GObject transform)
        {
            self.GObject = transform;
            self.UITransform = (GComponent)transform;
        }
    }

    [ObjectSystem]
    public class HallPanelDestroySystem : DestroySystem<HallPanel>
    {
        public override void Destroy(HallPanel self)
        {
            self.GObject?.Dispose();
            self.GObject = null;
            self.UITransform = null;
			self.EnterBtn = null;
        }
    }
        
    [FriendClass(typeof(HallPanel))]
    public static class HallPanelSystem
    {
        private static GObject CreateGObject(this HallPanel self)
        {
            return UIPackage.CreateObject(HallPanel.UIPackageName, HallPanel.UIResName);
        }

        private static void CreateGObjectAsync(this HallPanel self,UIPackage.CreateObjectCallback result)
        {
            UIPackage.CreateObjectAsync(HallPanel.UIPackageName, HallPanel.UIResName, result);
        }

        public static HallPanel CreateInstance(this HallPanel self,Entity domain)
        {
            return domain.AddChild<HallPanel, GObject>(CreateGObject(self));
        }

        public static async ETTask<HallPanel> CreateInstanceAsync(this HallPanel self,Entity domain)
        {
            ETTask<HallPanel> tcs = ETTask<HallPanel>.Create(true);
            CreateGObjectAsync(self,(go) =>
            {
                tcs.SetResult(domain.AddChild<HallPanel, GObject>(go));
            });
            return await tcs;
        }
    }
    
}