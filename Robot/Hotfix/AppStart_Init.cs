namespace ET
{
    public class AppStart_Init: AEvent<EventType.AppStart>
    {
        protected override void Run(EventType.AppStart args)
        {
            RunAsync(args).Coroutine();
        }
        
        private async ETTask RunAsync(EventType.AppStart args)
        {
            Game.Scene.AddComponent<TimerComponent>();
            Game.Scene.AddComponent<CoroutineLockComponent>();

            // 加载配置
            await TablesHelp.Instance.LoadAllConfigAsync();
            
            Game.Scene.AddComponent<OpcodeTypeComponent>();
            Game.Scene.AddComponent<MessageDispatcherComponent>();
            Game.Scene.AddComponent<SessionStreamDispatcher>();
            Game.Scene.AddComponent<NetThreadComponent>();
            Game.Scene.AddComponent<ZoneSceneManagerComponent>();
            Game.Scene.AddComponent<AIDispatcherComponent>();
            Game.Scene.AddComponent<RobotCaseDispatcherComponent>();
            Game.Scene.AddComponent<RobotCaseComponent>();
            Game.Scene.AddComponent<NumericWatcherComponent>();
            
            var processScenes = TablesHelp.Instance.Tables.StartSceneConfigCategory.GetByProcess(Game.Options.Process);
            foreach (StartSceneConfig startConfig in processScenes)
            {
                await RobotSceneFactory.Create(Game.Scene, startConfig.Id, startConfig.InstanceId, startConfig.Zone, startConfig.Name, startConfig.Type, startConfig);
            }
            
            if (Game.Options.Console == 1)
            {
                Game.Scene.AddComponent<ConsoleComponent>();
            }
        }
    }
}
