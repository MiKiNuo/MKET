namespace ET
{
    public class AfterCreateZoneScene_AddComponent: AEvent<EventType.AfterCreateZoneScene>
    {
        protected override async void Run(EventType.AfterCreateZoneScene args)
        {
            Scene zoneScene = args.ZoneScene;
            zoneScene.AddComponent<FGUIComponent>();
            zoneScene.AddComponent<FGUIEventComponent>();
            await ETTask.CompletedTask;
        }
    }
}