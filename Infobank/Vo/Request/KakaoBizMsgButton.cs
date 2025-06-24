using Newtonsoft.Json;

namespace Infobank.Vo.Request
{

   public class KakaoAlimTalkButton
   {
      [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
      public string? Type { get; set; }

      [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
      public string? Name { get; set; }

      [JsonProperty("urlPc", NullValueHandling = NullValueHandling.Ignore)]
      public string? UrlPc { get; set; }

      [JsonProperty("urlMobile", NullValueHandling = NullValueHandling.Ignore)]
      public string? UrlMobile { get; set; }

      [JsonProperty("schemeIos", NullValueHandling = NullValueHandling.Ignore)]
      public string? SchemeIos { get; set; }

      [JsonProperty("schemeAndroid", NullValueHandling = NullValueHandling.Ignore)]
      public string? SchemeAndroid { get; set; }

      [JsonProperty("target", NullValueHandling = NullValueHandling.Ignore)]
      public string? Target { get; set; }

      [JsonProperty("chatExtra", NullValueHandling = NullValueHandling.Ignore)]
      public string? ChatExtra { get; set; }

      [JsonProperty("chatEvent", NullValueHandling = NullValueHandling.Ignore)]
      public string? ChatEvent { get; set; }

      [JsonProperty("pluginId", NullValueHandling = NullValueHandling.Ignore)]
      public string? PluginId { get; set; }

      [JsonProperty("relayId", NullValueHandling = NullValueHandling.Ignore)]
      public string? RelayId { get; set; }

      [JsonProperty("oneclickId", NullValueHandling = NullValueHandling.Ignore)]
      public string? OneclickId { get; set; }

      [JsonProperty("productId", NullValueHandling = NullValueHandling.Ignore)]
      public string? ProductId { get; set; }

      [JsonProperty("bizFormKey", NullValueHandling = NullValueHandling.Ignore)]
      public string? BizFormKey { get; set; }

      [JsonProperty("bizFormId", NullValueHandling = NullValueHandling.Ignore)]
      public string? BizFormId { get; set; }

      private KakaoAlimTalkButton() { }
      public static KakaoAlimTalkButtonBuilder Builder()
      {
         return new KakaoAlimTalkButtonBuilder();
      }

      public class KakaoAlimTalkButtonBuilder
      {
         private readonly KakaoAlimTalkButton kakaoAlimTalkButton;

         public KakaoAlimTalkButtonBuilder()
         {
            kakaoAlimTalkButton = new KakaoAlimTalkButton();
         }

         public KakaoAlimTalkButtonBuilder WithType(string type)
         {
            if (KakaoBizMsgCheckField.KAKAO_BIZ_MSG_BUTTON_TYPE.IsValid(type) == false)
            {
               throw new InvalidDataException("Not Supported Button Type");
            }
            kakaoAlimTalkButton.Type = type;
            return this;
         }

         public KakaoAlimTalkButtonBuilder WithName(string name)
         {
            kakaoAlimTalkButton.Name = name;
            return this;
         }

         public KakaoAlimTalkButtonBuilder WithUrlPc(string urlPc)
         {
            kakaoAlimTalkButton.UrlPc = urlPc;
            return this;
         }

         public KakaoAlimTalkButtonBuilder WithUrlMobile(string urlMobile)
         {
            kakaoAlimTalkButton.UrlMobile = urlMobile;
            return this;
         }

         public KakaoAlimTalkButtonBuilder WithSchemeIos(string schemeIos)
         {
            kakaoAlimTalkButton.SchemeIos = schemeIos;
            return this;
         }

         public KakaoAlimTalkButtonBuilder WithSchemeAndroid(string schemeAndroid)
         {
            kakaoAlimTalkButton.SchemeAndroid = schemeAndroid;
            return this;
         }

         public KakaoAlimTalkButtonBuilder WithTarget(string target)
         {
            kakaoAlimTalkButton.Target = target;
            return this;
         }

         public KakaoAlimTalkButtonBuilder WithChatExtra(string chatExtra)
         {
            kakaoAlimTalkButton.ChatExtra = chatExtra;
            return this;
         }

         public KakaoAlimTalkButtonBuilder WithChatEvent(string chatEvent)
         {
            kakaoAlimTalkButton.ChatEvent = chatEvent;
            return this;
         }

         public KakaoAlimTalkButtonBuilder WithPluginId(string pluginId)
         {
            kakaoAlimTalkButton.PluginId = pluginId;
            return this;
         }

         public KakaoAlimTalkButtonBuilder WithRelayId(string relayId)
         {
            kakaoAlimTalkButton.RelayId = relayId;
            return this;
         }

         public KakaoAlimTalkButtonBuilder WithOneclickId(string oneclickId)
         {
            kakaoAlimTalkButton.OneclickId = oneclickId;
            return this;
         }

         public KakaoAlimTalkButtonBuilder WithProductId(string productId)
         {
            kakaoAlimTalkButton.ProductId = productId;
            return this;
         }

         public KakaoAlimTalkButtonBuilder WithBizFormKey(string bizFormKey)
         {
            kakaoAlimTalkButton.BizFormKey = bizFormKey;
            return this;
         }

         public KakaoAlimTalkButtonBuilder WithBizFormId(string bizFormId)
         {
            kakaoAlimTalkButton.BizFormId = bizFormId;
            return this;
         }

         public KakaoAlimTalkButton Build()
         {
            return kakaoAlimTalkButton;
         }

      }


   }

   public class KakaoFriendTalkButton
   {
      [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
      public string? Type { get; set; }

      [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
      public string? Name { get; set; }

      [JsonProperty("urlPc", NullValueHandling = NullValueHandling.Ignore)]
      public string? UrlPc { get; set; }

      [JsonProperty("urlMobile", NullValueHandling = NullValueHandling.Ignore)]
      public string? UrlMobile { get; set; }

      [JsonProperty("schemeIos", NullValueHandling = NullValueHandling.Ignore)]
      public string? SchemeIos { get; set; }

      [JsonProperty("schemeAndroid", NullValueHandling = NullValueHandling.Ignore)]
      public string? SchemeAndroid { get; set; }

      [JsonProperty("target", NullValueHandling = NullValueHandling.Ignore)]
      public string? Target { get; set; }

      [JsonProperty("chatExtra", NullValueHandling = NullValueHandling.Ignore)]
      public string? ChatExtra { get; set; }

      [JsonProperty("chatEvent", NullValueHandling = NullValueHandling.Ignore)]
      public string? ChatEvent { get; set; }

      [JsonProperty("bizFormKey", NullValueHandling = NullValueHandling.Ignore)]
      public string? BizFormKey { get; set; }

      [JsonProperty("bizFormId", NullValueHandling = NullValueHandling.Ignore)]
      public string? BizFormId { get; set; }

      protected KakaoFriendTalkButton() { }
      public static KakaoFrientTalkButtonBuilder Builder()
      {
         return new KakaoFrientTalkButtonBuilder();
      }

      public class KakaoFrientTalkButtonBuilder
      {
         protected readonly KakaoFriendTalkButton kakaoFriendTalkButton;

         public KakaoFrientTalkButtonBuilder()
         {
            kakaoFriendTalkButton = new KakaoFriendTalkButton();
         }

         public KakaoFrientTalkButtonBuilder WithType(string type)
         {
            if (KakaoBizMsgCheckField.KAKAO_BIZ_MSG_BUTTON_TYPE.IsValid(type) == false)
            {
               throw new InvalidDataException("Not Supported Button Type");
            }
            kakaoFriendTalkButton.Type = type;
            return this;
         }

         public KakaoFrientTalkButtonBuilder WithName(string name)
         {
            kakaoFriendTalkButton.Name = name;
            return this;
         }

         public KakaoFrientTalkButtonBuilder WithUrlPc(string urlPc)
         {
            kakaoFriendTalkButton.UrlPc = urlPc;
            return this;
         }

         public KakaoFrientTalkButtonBuilder WithUrlMobile(string urlMobile)
         {
            kakaoFriendTalkButton.UrlMobile = urlMobile;
            return this;
         }

         public KakaoFrientTalkButtonBuilder WithSchemeIos(string schemeIos)
         {
            kakaoFriendTalkButton.SchemeIos = schemeIos;
            return this;
         }

         public KakaoFrientTalkButtonBuilder WithSchemeAndroid(string schemeAndroid)
         {
            kakaoFriendTalkButton.SchemeAndroid = schemeAndroid;
            return this;
         }

         public KakaoFrientTalkButtonBuilder WithTarget(string target)
         {
            kakaoFriendTalkButton.Target = target;
            return this;
         }

         public KakaoFrientTalkButtonBuilder WithChatExtra(string chatExtra)
         {
            kakaoFriendTalkButton.ChatExtra = chatExtra;
            return this;
         }

         public KakaoFrientTalkButtonBuilder WithChatEvent(string chatEvent)
         {
            kakaoFriendTalkButton.ChatEvent = chatEvent;
            return this;
         }

         public KakaoFrientTalkButtonBuilder WithBizFormKey(string bizFormKey)
         {
            kakaoFriendTalkButton.BizFormKey = bizFormKey;
            return this;
         }

         public KakaoFrientTalkButtonBuilder WithBizFormId(string bizFormId)
         {
            kakaoFriendTalkButton.BizFormId = bizFormId;
            return this;
         }

         public KakaoFriendTalkButton Build()
         {
            return kakaoFriendTalkButton;
         }

      }


   }

}