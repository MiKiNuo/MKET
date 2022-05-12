namespace ET
{
    public static class HallPanelComponentSystem
    {
        public static void RegisterUIEvent(this HallPanelComponent self)
        {
            self.View.EnterBtn_EnterBtn.AddListener(() =>
            {
                self.OnEnter().Coroutine();
            });
        }
        public static async ETTask  OnEnter(this HallPanelComponent self)
        {
            await EnterMapHelper.EnterMapAsync(self.ZoneScene());
            var fgui = self.DomainScene().GetComponent<FGUIComponent>();
            fgui.CloseWindow(HallPanel.UIResName);
            
        }
        

    }
}