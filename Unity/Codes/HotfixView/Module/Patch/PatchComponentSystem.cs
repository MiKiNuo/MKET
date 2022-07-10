
using YooAsset;
using UnityEngine;
using FairyGUI;

namespace ET
{
    
    public class PatchComponentAwakeSystem :AwakeSystem<PatchComponent>
    {
        public override void Awake(PatchComponent self)
        {
            PatchComponent.Instance = self;
        }
    }
    
    public class PatchComponentDestroySystem :DestroySystem<PatchComponent>
    {
        public override void Destroy(PatchComponent self)
        {
            PatchComponent.Instance = null;
        }
    }

    public static class PatchComponentSystem
    {
        public static async ETTask PatchInit(this PatchComponent self,Scene zoneScene)
        {
            UIPackage.AddPackage("FGUI/UModel");
            UModelBinder.BindAll();
            self.LoadingPanel = LoadingPanel.CreateInstance();
            self.LoadingPanel.MakeFullScreen();
            GRoot.inst.AddChild( self.LoadingPanel);
            UpdateStaticVersion(self, zoneScene).Coroutine();
            await ETTask.CompletedTask;
        }
        
        private static async ETTask  UpdateStaticVersion(this PatchComponent self ,Scene zoneScene)
        {
            // 更新资源版本号
            var operation = YooAssets.UpdateStaticVersionAsync(30);
            await operation.Task;
            if (operation.Status == EOperationStatus.Succeed)
            {
                self.ResourceVersion = operation.ResourceVersion;
                Log.Debug($"Found static version : {operation.ResourceVersion}");
                UpdateManifest(self,zoneScene).Coroutine();
            }
            else
            {
                //TODO　顯示錯誤信息
                Log.Error(operation.Error);
            }
        }
        

        private static async ETTask UpdateManifest(this PatchComponent self,Scene zoneScene)
        {
            // 更新补丁清单
            var operation = YooAssets.UpdateManifestAsync(self.ResourceVersion, 30);
            await operation.Task;

            if(operation.Status == EOperationStatus.Succeed)
            {
                CreateDownloader(self,zoneScene).Coroutine();
            }
            else
            {
                //顯示錯誤信息(或者以弹窗的形式显示)
                self.LoadingPanel.Tips.text = operation.Error;
            }
        }

        private static async ETTask CreateDownloader(this PatchComponent self,Scene zoneScene)
        {
            int downloadingMaxNum = 10;
            int failedTryAgain = 3;
            self.Downloader = YooAssets.CreatePatchDownloader(downloadingMaxNum, failedTryAgain);
            
            if (self.Downloader.TotalDownloadCount == 0)
            {
                Log.Debug("没有发现需要下载的资源");
                //跳轉到登陸界面
                UIPackage.RemovePackage("UModel");
                self.LoadingPanel.Dispose(); 
                self.LoadingPanel = null;
                var fgui = zoneScene.GetComponent<FGUIComponent>();
                fgui.ShowWindowAsync(LoginPanel.UIPackageName,LoginPanel.UIResName).Coroutine();
            }
            else
            {
                Log.Debug($"一共发现了{self.Downloader.TotalDownloadCount}个资源需要更新下载。");

                // 发现新更新文件后，挂起流程系统
                // 注意：开发者需要在下载前检测磁盘空间不足
                int totalDownloadCount = self.Downloader.TotalDownloadCount;
                long totalDownloadBytes = self.Downloader.TotalDownloadBytes;
                
                //更新界面顯示需要進行更新的文件信息(应该显示一个弹窗界面询问是否要进行更新)
                float sizeMB = totalDownloadBytes / 1048576f;
                sizeMB = Mathf.Clamp(sizeMB, 0.1f, float.MaxValue);
                string totalSizeMB = sizeMB.ToString("f1");
                self.LoadingPanel.Tips.text = $"Found update patch files, Total count {totalDownloadCount} Total szie {totalSizeMB}MB";
                
                //开始下载文件
                BeginDownload(self, zoneScene).Coroutine();
            }

            await ETTask.CompletedTask;
        }

        private static async ETTask BeginDownload(this PatchComponent self,Scene zoneScene)
        {
            var downloader = self.Downloader;

            // 注册下载回调
            downloader.OnDownloadErrorCallback = OnDownloadFileFailed;
            downloader.OnDownloadProgressCallback = OnDownloadProgress;
            downloader.BeginDownload();
            await downloader.Task;

            // 检测下载结果
            if (downloader.Status != EOperationStatus.Succeed)
            {
                Log.Debug($"下载状态为={downloader.Error}");
                return;
            }
               

            //切換到登陸的路界面
            UIPackage.RemovePackage("UModel");
            self.LoadingPanel.Dispose();
            self.LoadingPanel = null;
            var fgui = zoneScene.GetComponent<FGUIComponent>();
            fgui.ShowWindowAsync(LoginPanel.UIPackageName,LoginPanel.UIResName).Coroutine();
        }


        private static void OnDownloadFileFailed(string fileName, string error)
        {
            Log.Debug($"下载文件失败，错误信息={error}");
        }
        
        
        private static void OnDownloadProgress(int totalDownloadCount, int currentDownloadCount, long totalDownloadBytes,
        long currentDownloadBytes)
        {
            PatchComponent.Instance.LoadingPanel.UpdateProgressBar.value = (float)currentDownloadCount / totalDownloadCount;
            string currentSizeMB = (currentDownloadBytes / 1048576f).ToString("f1");
            string totalSizeMB = (totalDownloadBytes/ 1048576f).ToString("f1");
            PatchComponent.Instance.LoadingPanel.Tips.text = $"{currentDownloadCount}/{totalDownloadCount} {currentSizeMB}MB/{totalSizeMB}MB";
        }
    }
}