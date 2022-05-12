using System;
using FairyGUI;
using UnityEngine;
using YooAsset;
using System.Collections.Generic;

namespace ET
{
    [ObjectSystem]
    public class FUIPackageComponentAwakeSystem: AwakeSystem<FUIPackageComponent>
    {
        public override void Awake(FUIPackageComponent self)
        {
            FUIPackageComponent.Instance = self;
        }
    }

    [ObjectSystem]
    public class FUIPackageComponentDestroySystem: DestroySystem<FUIPackageComponent>
    {
        public override void Destroy(FUIPackageComponent self)
        {
            self.HandlesDic.Clear();
            self.Packages.Clear();
            self.LoadingPkg.Clear();
            FUIPackageComponent.Instance = null;
        }
    }

    [FriendClass(typeof (FUIPackageComponent))]
    public static class FUIPackageComponentSystem
    {
        public static void Awake(this FUIPackageComponent self)
        {
            self.HandlesDic.Clear();
            self.Packages.Clear();
            self.LoadingPkg.Clear();
        }

        public static async ETTask AddPackageAsync(this FUIPackageComponent self, string packageName)
        {
            if (self.LoadingPkg.IndexOf(packageName) != -1 || self.Packages.ContainsKey(packageName))
            {
                Log.Debug($"{packageName}包已经加载");
                return;
            }

            Log.Debug($"<color=green>AddPackageAsync {packageName}包</color>");
            await ETTask.CompletedTask;
            UIPackage uiPackage = UIPackage.AddPackage(packageName, (string name, string extension, Type type, out DestroyMethod method) =>
            {
                method = DestroyMethod.None;
                var location = $"FGUI/{packageName}/{name}{extension}";
                var handle = YooAssets.LoadAssetSync(location, type);
                if (self.HandlesDic.ContainsKey(packageName))
                {
                    var handlesList = self.HandlesDic[packageName];
                    handlesList.Add(handle);
                }
                else
                {
                    List<AssetOperationHandle> handlesList = new List<AssetOperationHandle>();
                    handlesList.Add(handle);
                    self.HandlesDic.Add(packageName, handlesList);
                }

                return handle.AssetObject;
            });
            self.LoadingPkg.Add(packageName);
            self.Packages.Add(packageName, uiPackage);
            self.LoadingPkg.Remove(packageName);
        }

        public static void RemovePackage(this FUIPackageComponent self, string packageName)
        {
            if (!self.Packages.ContainsKey(packageName))
            {
                Log.Debug($"{packageName}包已经卸载");
                return;
            }

            UIPackage package;

            if (self.Packages.TryGetValue(packageName, out package))
            {
                var p = UIPackage.GetByName(package.name);

                if (p != null)
                {
                    UIPackage.RemovePackage(package.name);
                }

                self.Packages.Remove(package.name);
                var ret = ReleaseHandles(self, packageName);
                if (ret)
                {
                    Debug.Log($"移出handle成功 = {packageName}");
                }
            }
        }

        public static async ETTask<GObject> CreateGo(this FUIPackageComponent self, string packageName, string res)
        {
            ETTask<GObject> tcs = ETTask<GObject>.Create(true);
            UIPackage.CreateObjectAsync(packageName, res, (go) => { tcs.SetResult(go); });
            return await tcs;
        }

        private static bool ReleaseHandles(this FUIPackageComponent self, string assetPath)
        {
            if (!self.HandlesDic.TryGetValue(assetPath, out List<AssetOperationHandle> handlesList))
            {
                return false;
            }

            for (int i = 0; i < handlesList.Count; i++)
            {
                var handle = handlesList[i];
                handle.Release();
            }

            return true;
        }
    }
}