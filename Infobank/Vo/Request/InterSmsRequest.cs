using Newtonsoft.Json;

namespace Infobank.Vo.Request
{
    public class InterSmsRequest : MessageRequest
    {

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "ref", NullValueHandling = NullValueHandling.Ignore)]
        public string? Ref { get; set; }

        private InterSmsRequest()
        {
            this.From = "";
            this.To = "";
            this.Text = "";
            this.Ref = null;

        }

        public static InterSmsRequestBuilder Builder()
        {
            return new InterSmsRequestBuilder();
        }

        public class InterSmsRequestBuilder
        {

            private readonly InterSmsRequest request;
            public InterSmsRequestBuilder(InterSmsRequest request)
            {
                this.request = request;

            }
            public InterSmsRequestBuilder()
            {
                this.request = new InterSmsRequest();
            }

            public InterSmsRequestBuilder WithFrom(string from)
            {
                request.From = from;
                return this;
            }

            public InterSmsRequestBuilder WithTo(string to)
            {
                request.To = to;
                return this;
            }

            public InterSmsRequestBuilder WithText(string text)
            {
                request.Text = text;
                return this;
            }

            public InterSmsRequestBuilder WithRef(string inRef)
            {
                request.Ref = inRef;
                return this;
            }

            public InterSmsRequest Build()
            {
                return this.request;
            }

        }

    }


}