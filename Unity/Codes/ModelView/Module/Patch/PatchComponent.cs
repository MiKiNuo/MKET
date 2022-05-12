using YooAsset;

namespace ET
{
    public class PatchComponent: Entity, IAwake, IDestroy
    {
        public static PatchComponent Instance = null;
        public int ResourceVersion { set; get; }
        public PatchDownloaderOperation Downloader { set; get; }
        public LoadingPanel LoadingPanel { set; get; }
    }
}