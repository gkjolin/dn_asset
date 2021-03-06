namespace UnityEditor.XBuild
{
    public sealed class InitTencentAttribute : SDKAttribute
    {
        public InitTencentAttribute(
            int qqAppId
            , string qqAppKey
            , string weixinAppId
            , string midasId
            , string msdkKey
            , string notifyObjName
            , string url4cb
            , bool isOriPortrait
            , bool isOriLandscapeLeft
            , bool isOriLandscapeRight
            , bool isOriPortraitUpsideDown
            , bool logEnable
            )
            : base(0, qqAppId + "_" + qqAppKey + "_" + weixinAppId + "_" + msdkKey + "_" + midasId,
                  notifyObjName,
                  true,
                  true,
                  0,
                  url4cb,
                  isOriPortrait,
                  isOriLandscapeLeft,
                  isOriLandscapeRight,
                  isOriPortraitUpsideDown,
                  logEnable)
        {
            this.qqAppId = qqAppId;
            this.qqAppKey = qqAppKey;
            this.weixinAppId = weixinAppId;
            this.midasId = midasId;
            this.msdkKey = msdkKey;
        }

        public int qqAppId { get; set; }
        public string qqAppKey { get; set; }
        public string weixinAppId { get; set; }
        public string midasId { get; set; }
        public string msdkKey { get; set; }

        public string NAME
        {
            get { return JoyYouSDKPlatformFilterAttribute.PLATFORM_NAME_TENCENT; }
        }
    }

    public sealed partial class JoyYouSDKPlatformFilterAttribute
    {
        public const string PLATFORM_NAME_TENCENT = "__Tencent__";
    }
    
    [InitTencentAttribute(1105309683, "xa0seqAScOhSsgrm", "wxfdab5af74990787a", "1450007239", "02a8d5ed226237996eb3f448dfac0b1c", "XGamePoint", null, false, true, true, false, false)]
    public partial class XSDK { }

}