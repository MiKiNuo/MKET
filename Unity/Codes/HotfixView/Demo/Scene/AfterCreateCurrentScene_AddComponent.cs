namespace ET
{
    public class AfterCreateCurrentScene_AddComponent: AEvent<EventType.AfterCreateCurrentScene>
    {
        protected override async void Run(EventType.AfterCreateCurrentScene args)
        {
            Scene currentScene = args.CurrentScene;
            currentScene.AddComponent<FGUIComponent>();
            currentScene.AddComponent<FGUIEventComponent>();
            await ETTask.CompletedTask;
        }
    }
}