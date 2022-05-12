using System;
using System.Collections;
using System.Threading;
using UnityEditor;
using UnityEngine;
using YooAsset;

namespace ET
{
    // 1 mono模式 2 ILRuntime模式 3 mono热重载模式
    public enum CodeMode
    {
        Mono = 1,
        ILRuntime = 2,
        Reload = 3,
    }

    public class Init: MonoBehaviour
    {
        public CodeMode CodeMode = CodeMode.Mono;
        public YooAssets.EPlayMode PlayMode = YooAssets.EPlayMode.EditorSimulateMode;

        private bool isYooAssetInitFinish = false;
        private WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);

        private void Awake()
        {
#if ENABLE_IL2CPP
			this.CodeMode = CodeMode.ILRuntime;
#endif

            AppDomain.CurrentDomain.UnhandledException += (sender, e) => { Log.Error(e.ExceptionObject.ToString()); };

            SynchronizationContext.SetSynchronizationContext(ThreadSynchronizationContext.Instance);

            DontDestroyOnLoad(gameObject);

            ETTask.ExceptionHandler += Log.Error;

            Log.ILog = new UnityLogger();

            Options.Instance = new Options();

            CodeLoader.Instance.CodeMode = this.CodeMode;
            Options.Instance.Develop = 1;
            Options.Instance.LogLevel = 0;
        }

        IEnumerator Start()
        {
            Debug.Log($"资源系统运行模式：{PlayMode}");
            // 编辑器下的模拟模式
            if (PlayMode == YooAssets.EPlayMode.EditorSimulateMode)
            {
                var createParameters = new YooAssets.EditorSimulateModeParameters();
                createParameters.LocationServices = new DefaultLocationServices("Assets/Res");
                yield return YooAssets.InitializeAsync(createParameters);
            }

            // 单机运行模式
            if (PlayMode == YooAssets.EPlayMode.OfflinePlayMode)
            {
                var createParameters = new YooAssets.OfflinePlayModeParameters();
                createParameters.LocationServices = new DefaultLocationServices("Assets/Res");
                yield return YooAssets.InitializeAsync(createParameters);
            }

            // 联机运行模式
            if (PlayMode == YooAssets.EPlayMode.HostPlayMode)
            {
                var createParameters = new YooAssets.HostPlayModeParameters();
                createParameters.LocationServices = new DefaultLocationServices("Assets/Res");
                createParameters.DecryptionServices = null;
                createParameters.ClearCacheWhenDirty = false;
                createParameters.DefaultHostServer = GetHostServerURL();
                createParameters.FallbackHostServer = GetHostServerURL();
                yield return YooAssets.InitializeAsync(createParameters);
            }
            yield return waitForSeconds;
            CodeLoader.Instance.Start();
            yield return waitForSeconds;
            isYooAssetInitFinish = true;
        }

        private string GetHostServerURL()
        {
            string hostServerIP = "http://127.0.0.1";
            string gameVersion = "v1.0";

#if UNITY_EDITOR
            if (UnityEditor.EditorUserBuildSettings.activeBuildTarget == UnityEditor.BuildTarget.Android)
                return $"{hostServerIP}/CDN/Android/{gameVersion}";
            else if (UnityEditor.EditorUserBuildSettings.activeBuildTarget == UnityEditor.BuildTarget.iOS)
                return $"{hostServerIP}/CDN/IPhone/{gameVersion}";
            else if (UnityEditor.EditorUserBuildSettings.activeBuildTarget == UnityEditor.BuildTarget.WebGL)
                return $"{hostServerIP}/CDN/WebGL/{gameVersion}";
            else
                return $"{hostServerIP}/CDN/PC/{gameVersion}";
#else
		    if (Application.platform == RuntimePlatform.Android)
			    return $"{hostServerIP}/CDN/Android/{gameVersion}";
		    else if (Application.platform == RuntimePlatform.IPhonePlayer)
			    return $"{hostServerIP}/CDN/IPhone/{gameVersion}";
		    else if (Application.platform == RuntimePlatform.WebGLPlayer)
			    return $"{hostServerIP}/CDN/WebGL/{gameVersion}";
		    else
			    return $"{hostServerIP}/CDN/PC/{gameVersion}";
#endif
        }

        private void Update()
        {
            if (isYooAssetInitFinish)
            {
                CodeLoader.Instance.Update();
            }
        }

        private void LateUpdate()
        {
            if (isYooAssetInitFinish)
            {
                CodeLoader.Instance.LateUpdate();
            }
        }

        private void OnApplicationQuit()
        {
            CodeLoader.Instance.OnApplicationQuit();
            CodeLoader.Instance.Dispose();
        }
    }
}