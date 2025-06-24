using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

using KakaoBrandTalkButton = Infobank.Vo.Request.KakaoFriendTalkButton;

namespace Infobank.Vo.Request
{
    public enum SendType
    {
        Basic,
        Free
    }

    public class SendTypeConverter : StringEnumConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value is SendType sendType)
            {
                writer.WriteValue(sendType.ToString().ToLower());
            }
        }
    }

    public class BrandMessageRequest : MessageRequest
    {
        [JsonProperty("senderKey")]
        public string? SenderKey { get; set; }

        [JsonProperty("sendType")]
        [JsonConverter(typeof(SendTypeConverter))]
        public SendType SendType { get; set; }

        [JsonProperty("msgType")]
        public string? MsgType { get; set; }

        [JsonProperty("to")]
        public string? To { get; set; }

        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonProperty("imgUrl")]
        public string? ImgUrl { get; set; }

        [JsonProperty("targeting")]
        public string? Targeting { get; set; }

        [JsonProperty("templateCode")]
        public string? TemplateCode { get; set; }

        [JsonProperty("button")]
        public List<KakaoBrandTalkButton>? Button { get; set; }

        [JsonProperty("fallback")]
        public KakaoBizMsgFallback? Fallback { get; set; }

        [JsonProperty("groupTagKey")]
        public string? GroupTagKey { get; set; }

        [JsonProperty("adults")]
        public string? Adult { get; set; }

        [JsonProperty("pushAlarm")]
        public string? PushAlarm { get; set; }

        [JsonProperty("messageVariable")]
        public Dictionary<string, object>? MessageVariable { get; set; }

        [JsonProperty("buttonVariable")]
        public Dictionary<string, object>? ButtonVariable { get; set; }

        [JsonProperty("couponVariable")]
        public Dictionary<string, object>? CouponVariable { get; set; }

        [JsonProperty("imageVariable")]
        public List<BrandMessageImageVariableObject>? ImageVariable { get; set; }

        [JsonProperty("videoVariable")]
        public Dictionary<string, object>? VideoVariable { get; set; }

        [JsonProperty("commerceVariable")]
        public Dictionary<string, object>? CommerceVariable { get; set; }

        [JsonProperty("carouselVariable")]
        public List<BrandMessageCarouselVariableObject>? CarouselVariable { get; set; }

        [JsonProperty("originCID")]
        public string? OriginCID { get; set; }

        [JsonProperty("unsubscribePhoneNumber")]
        public string? UnsubscribePhoneNumber { get; set; }

        [JsonProperty("unsubscribeAuthNumber")]
        public string? UnsubscribeAuthNumber { get; set; }

        [JsonProperty("ref")]
        public string? Ref { get; set; }

        private BrandMessageRequest(SendType sendType)
        {
            SendType = sendType;
        }

        public static BrandMessageRequestBuilder Builder(SendType sendType)
        {
            return new BrandMessageRequestBuilder(sendType);
        }

        public class BrandMessageRequestBuilder
        {
            private readonly BrandMessageRequest _request;

            public BrandMessageRequestBuilder(SendType sendType)
            {
                _request = new BrandMessageRequest(sendType);
            }

            public BrandMessageRequestBuilder WithSenderKey(string senderKey)
            {
                _request.SenderKey = senderKey;
                return this;
            }

            public BrandMessageRequestBuilder WithSendType(SendType sendType)
            {
                _request.SendType = sendType;
                return this;
            }

            public BrandMessageRequestBuilder WithMsgType(string msgType)
            {
                _request.MsgType = msgType;
                return this;
            }

            public BrandMessageRequestBuilder WithTo(string to)
            {
                _request.To = to;
                return this;
            }

            public BrandMessageRequestBuilder WithText(string text)
            {
                _request.Text = text;
                return this;
            }

            public BrandMessageRequestBuilder WithImgUrl(string imgUrl)
            {
                _request.ImgUrl = imgUrl;
                return this;
            }

            public BrandMessageRequestBuilder WithTargeting(string targeting)
            {
                _request.Targeting = targeting;
                return this;
            }

            public BrandMessageRequestBuilder WithTemplateCode(string templateCode)
            {
                _request.TemplateCode = templateCode;
                return this;
            }

            public BrandMessageRequestBuilder AddButton(KakaoBrandTalkButton button)
            {
                _request.Button ??= [];
                _request.Button.Add(button);
                return this;
            }

            public BrandMessageRequestBuilder WithFallback(KakaoBizMsgFallback fallback)
            {
                _request.Fallback = fallback;
                return this;
            }

            public BrandMessageRequestBuilder WithGroupTagKey(string groupTagKey)
            {
                _request.GroupTagKey = groupTagKey;
                return this;
            }

            public BrandMessageRequestBuilder WithAdult(string adult)
            {
                _request.Adult = adult;
                return this;
            }

            public BrandMessageRequestBuilder WithPushAlarm(string pushAlarm)
            {
                _request.PushAlarm = pushAlarm;
                return this;
            }

            public BrandMessageRequestBuilder WithMessageVariable(Dictionary<string, object> messageVariable)
            {
                _request.MessageVariable = messageVariable;
                return this;
            }

            public BrandMessageRequestBuilder WithButtonVariable(Dictionary<string, object> buttonVariable)
            {
                _request.ButtonVariable = buttonVariable;
                return this;
            }

            public BrandMessageRequestBuilder WithCouponVariable(Dictionary<string, object> couponVariable)
            {
                _request.CouponVariable = couponVariable;
                return this;
            }

            public BrandMessageRequestBuilder WithImageVariable(List<BrandMessageImageVariableObject> imageVariable)
            {
                _request.ImageVariable = imageVariable;
                return this;
            }

            public BrandMessageRequestBuilder WithVideoVariable(Dictionary<string, object> videoVariable)
            {
                _request.VideoVariable = videoVariable;
                return this;
            }

            public BrandMessageRequestBuilder WithCommerceVariable(Dictionary<string, object> commerceVariable)
            {
                _request.CommerceVariable = commerceVariable;
                return this;
            }

            public BrandMessageRequestBuilder WithCarouselVariable(List<BrandMessageCarouselVariableObject> carouselVariable)
            {
                _request.CarouselVariable ??= [];
                _request.CarouselVariable = carouselVariable;
                return this;
            }

            public BrandMessageRequestBuilder AddCarouselVariable(BrandMessageCarouselVariableObject carouselVariable)
            {
                _request.CarouselVariable ??= [];
                _request.CarouselVariable.Add(carouselVariable);
                return this;
            }

            public BrandMessageRequestBuilder WithOriginCID(string originCID)
            {
                _request.OriginCID = originCID;
                return this;
            }

            public BrandMessageRequestBuilder WithUnsubscribePhoneNumber(string unsubscribePhoneNumber)
            {
                _request.UnsubscribePhoneNumber = unsubscribePhoneNumber;
                return this;
            }

            public BrandMessageRequestBuilder WithUnsubscribeAuthNumber(string unsubscribeAuthNumber)
            {
                _request.UnsubscribeAuthNumber = unsubscribeAuthNumber;
                return this;
            }

            public BrandMessageRequestBuilder WithRef(string refValue)
            {
                _request.Ref = refValue;
                return this;
            }

            public BrandMessageRequest Build()
            {
                return _request;
            }
        }
    }

   
} 