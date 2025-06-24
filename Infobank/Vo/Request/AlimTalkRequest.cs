using Newtonsoft.Json;

namespace Infobank.Vo.Request
{
    public class AlimTalkRequest : MessageRequest
    {
        [JsonProperty("senderKey")]
        public string? SenderKey { get; set; }

        [JsonProperty("msgType")]
        public string? MsgType { get; set; }

        [JsonProperty("to")]
        public string? To { get; set; }

        [JsonProperty("templateCode")]
        public string? TemplateCode { get; set; }

        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonProperty("title")]
        public  string? Title { get; set; }

        [JsonProperty("header")]
        public  string? Header { get; set; }

        [JsonProperty("link")]
        public AlimTalkLink? Link { get; set; }

        [JsonProperty(PropertyName = "button", NullValueHandling = NullValueHandling.Ignore)]
        public List<KakaoAlimTalkButton>? Buttions { get; set; }


        [JsonProperty(PropertyName = "ref", NullValueHandling = NullValueHandling.Ignore)]
        public string? Ref { get; set; }

        [JsonProperty(PropertyName = "fallback", NullValueHandling = NullValueHandling.Ignore)]
        public KakaoBizMsgFallback? Fallback { get; set; }


        private AlimTalkRequest()
        {
            this.SenderKey = "";
            this.To = "";
            this.Text = "";
            this.MsgType = "";
            this.TemplateCode = "";
            this.Title = "";
            this.Header = "";
            this.Ref = null;
            this.Buttions = null;
            this.Fallback = null;
            this.Link = null;

        }


        public static AlimTalkRequestBuilder Builder()
        {
            return new AlimTalkRequestBuilder();
        }

        public class AlimTalkRequestBuilder
        {

            private readonly AlimTalkRequest request;

            public AlimTalkRequestBuilder()
            {
                this.request = new AlimTalkRequest();
            }

            public AlimTalkRequestBuilder WithSenderKey(string senderKey)
            {
                request.SenderKey = senderKey;
                return this;
            }

            public AlimTalkRequestBuilder WithTo(string to)
            {
                request.To = to;
                return this;
            }

            public AlimTalkRequestBuilder WithText(string text)
            {
                request.Text = text;
                return this;
            }

            public AlimTalkRequestBuilder WithTitle(string title)
            {
                request.Title = title;
                return this;
            }

            public AlimTalkRequestBuilder WithHeader(string header)
            {
                request.Header = header;
                return this;
            }

            public AlimTalkRequestBuilder WithLink(AlimTalkLink link)
            {
                request.Link = link;
                return this;
            }

            public AlimTalkRequestBuilder WithMsgType(string msgType)
            {
                if (KakaoBizMsgCheckField.ALIM_TALK_MSG_TYPE.IsValid(msgType) == false)
                {
                    throw new InvalidDataException("Not Supported AlimTalk Message Type");
                }
                request.MsgType = msgType;
                return this;
            }

            public AlimTalkRequestBuilder WithTemplateCode(string templateCode)
            {
                request.TemplateCode = templateCode;
                return this;
            }

            public AlimTalkRequestBuilder WithRef(string inRef)
            {
                request.Ref = inRef;
                return this;
            }

            public AlimTalkRequestBuilder WithButtion(KakaoAlimTalkButton button)
            {
                request.Buttions ??= new List<KakaoAlimTalkButton>();
                request.Buttions.Add(button);

                return this;
            }

            public AlimTalkRequestBuilder WithButtons(IEnumerable<KakaoAlimTalkButton> buttons)
            {
                request.Buttions ??= new List<KakaoAlimTalkButton>();
                request.Buttions.AddRange(buttons);

                return this;
            }


            public AlimTalkRequestBuilder WithFallback(KakaoBizMsgFallback fallback)
            {
                request.Fallback = fallback;
                return this;
            }

            public AlimTalkRequest Build()
            {
                return this.request;
            }

        }
    }
    public class AlimTalkLink
    {
        [JsonProperty("urlMobile")]
        public required string UrlMobile { get; set; }

        [JsonProperty("urlPc")]
        public required string UrlPc { get; set; }

        [JsonProperty("schemeAndroid")]
        public string? SchemeAndroid { get; set; }

        [JsonProperty("schemeIos")]
        public string? SchemeIos { get; set; }

        private AlimTalkLink()
        {
            this.UrlMobile = "";
            this.UrlPc = "";
            this.SchemeAndroid = null;
            this.SchemeIos = null;
        }
    }   

}