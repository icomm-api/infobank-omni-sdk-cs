using Newtonsoft.Json;

namespace Infobank.Vo.Request
{
    public class SmsRequest : MessageRequest
    {
        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "ref", NullValueHandling = NullValueHandling.Ignore)]
        public string? Ref { get; set; }

        [JsonProperty(PropertyName = "originCID", NullValueHandling = NullValueHandling.Ignore)]
        public string? OriginCID { get; set; }

        private SmsRequest()
        {
            this.From = "";
            this.To = "";
            this.Text = "";
            this.Ref = null;
            this.OriginCID = null;

        }


        public static SmsRequestBuilder Builder()
        {
            return new SmsRequestBuilder();
        }

        public class SmsRequestBuilder
        {

            private readonly SmsRequest request;
            public SmsRequestBuilder(SmsRequest request)
            {
                this.request = request;

            }
            public SmsRequestBuilder()
            {
                this.request = new SmsRequest();
            }

            public SmsRequestBuilder WithFrom(string from)
            {
                request.From = from;
                return this;
            }

            public SmsRequestBuilder WithTo(string to)
            {
                request.To = to;
                return this;
            }

            public SmsRequestBuilder WithText(string text)
            {
                request.Text = text;
                return this;
            }

            public SmsRequestBuilder WithRef(string inRef)
            {
                request.Ref = inRef;
                return this;
            }

            public SmsRequestBuilder WithOriginCID(string originCID)
            {
                request.OriginCID = originCID;
                return this;
            }

            public SmsRequest Build()
            {
                return this.request;
            }

        }
    }

}