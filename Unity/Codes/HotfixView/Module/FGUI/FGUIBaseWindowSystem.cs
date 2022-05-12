using FairyGUI;

namespace ET
{

    [ObjectSystem]
    public class FGUIBaseWindowAwakeSystem : AwakeSystem<FGUIBaseWindow>
    {
        public override void Awake(FGUIBaseWindow self)
        {
            self.WindowData = self.AddChild<WindowCoreData>();
        }
    }
    
    public  static class FGUIBaseWindowSystem  
    {
        public static void SetRoot(this FGUIBaseWindow self, GComponent rootTransform)
        {
            if(self.UITransform == null)
            {
                Log.Error($"fguibaseWindows {self.WindowID} fguiTransform is null!!!");
                return;
            }
            if(rootTransform == null)
            {
                Log.Error($"fguibaseWindows {self.WindowID} rootTransform is null!!!");
                return;
            }
            self.UITransform.MakeFullScreen();
            self.UITransform.container.fairyBatching = true;
            
            rootTransform.AddChild(self.UITransform);
        }
    }
}