using Newtonsoft.Json;

namespace Infobank.Vo.Request
{
    public class FriendTalkRequest : MessageRequest
    {
        [JsonProperty("senderKey")]
        public string SenderKey { get; set; }

        [JsonProperty("msgType")]
        public string MsgType { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("imgUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string? ImgUrl { get; set; }

        [JsonProperty(PropertyName = "button", NullValueHandling = NullValueHandling.Ignore)]
        public List<KakaoFriendTalkButton>? Buttions { get; set; }


        [JsonProperty(PropertyName = "ref", NullValueHandling = NullValueHandling.Ignore)]
        public string? Ref { get; set; }

        [JsonProperty(PropertyName = "fallback", NullValueHandling = NullValueHandling.Ignore)]
        public KakaoBizMsgFallback? Fallback { get; set; }


        private FriendTalkRequest()
        {
            this.SenderKey = "";
            this.To = "";
            this.Text = "";
            this.MsgType = "";

            this.ImgUrl = null;
            this.Ref = null;
            this.Buttions = null;
            this.Fallback = null;

        }


        public static FriendTalkRequestBuilder Builder()
        {
            return new FriendTalkRequestBuilder();
        }

        public class FriendTalkRequestBuilder
        {

            private readonly FriendTalkRequest request;

            public FriendTalkRequestBuilder()
            {
                this.request = new FriendTalkRequest();
            }

            public FriendTalkRequestBuilder WithSenderKey(string senderKey)
            {
                request.SenderKey = senderKey;
                return this;
            }

            public FriendTalkRequestBuilder WithTo(string to)
            {
                request.To = to;
                return this;
            }

            public FriendTalkRequestBuilder WithText(string text)
            {
                request.Text = text;
                return this;
            }

            public FriendTalkRequestBuilder WithMsgType(string msgType)
            {
                if (KakaoBizMsgCheckField.FRIEND_TALK_MSG_TYPE.IsValid(msgType) == false)
                {
                    throw new InvalidDataException("Not Supported FriendTalk Message Type");
                }
                request.MsgType = msgType;
                return this;
            }

            public FriendTalkRequestBuilder WithImgUrl(string imgUrl)
            {
                request.ImgUrl = imgUrl;
                return this;
            }

            public FriendTalkRequestBuilder WithRef(string inRef)
            {
                request.Ref = inRef;
                return this;
            }

            public FriendTalkRequestBuilder WithButtion(KakaoFriendTalkButton button)
            {
                request.Buttions ??= [];
                request.Buttions.Add(button);

                return this;
            }

            public FriendTalkRequestBuilder WithButtons(IEnumerable<KakaoFriendTalkButton> buttons)
            {
                request.Buttions ??= [];
                request.Buttions.AddRange(buttons);

                return this;
            }


            public FriendTalkRequestBuilder WithFallback(KakaoBizMsgFallback fallback)
            {
                request.Fallback = fallback;
                return this;
            }

            public FriendTalkRequest Build()
            {
                return this.request;
            }

        }
    }

}