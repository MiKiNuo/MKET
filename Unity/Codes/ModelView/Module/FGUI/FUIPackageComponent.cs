using System;
using System.Collections.Generic;
using FairyGUI;
using YooAsset;
namespace ET
{
    public class FUIPackageComponent : Entity,IAwake,IDestroy
    {
        public static FUIPackageComponent Instance = null;
        public const string FUI_PACKAGE_DIR = "Assets/Res/FGUI";
        public Dictionary<string, UIPackage> Packages = new Dictionary<string, UIPackage>();
        public List<string> LoadingPkg = new List<string>();
        public Dictionary<string,List<AssetOperationHandle>> HandlesDic = new Dictionary<string,List<AssetOperationHandle>>();

       
    }
}