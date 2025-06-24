using Newtonsoft.Json;

namespace Infobank.Vo.Request
{
    public class MmsRequest : MessageRequest
    {

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }


        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public string? Title { get; set; }

        [JsonProperty(PropertyName = "fileKey", NullValueHandling = NullValueHandling.Ignore)]
        public List<string>? FileKey { get; set; }

        [JsonProperty(PropertyName = "ref", NullValueHandling = NullValueHandling.Ignore)]
        public string? Ref { get; set; }

        [JsonProperty(PropertyName = "originCID", NullValueHandling = NullValueHandling.Ignore)]
        public string? OriginCID { get; set; }

        private MmsRequest()
        {
            this.From = "";
            this.To = "";
            this.Text = "";
            this.Title = null;
            this.FileKey = null;
            this.Ref = null;
            this.OriginCID = null;


        }

        public static MmsRequestBuilder Builder()
        {
            return new MmsRequestBuilder();
        }

        public class MmsRequestBuilder
        {

            private readonly MmsRequest request;
            public MmsRequestBuilder(MmsRequest request)
            {
                this.request = request;

            }
            public MmsRequestBuilder()
            {
                this.request = new MmsRequest();
            }

            public MmsRequestBuilder WithFrom(string from)
            {
                request.From = from;
                return this;
            }

            public MmsRequestBuilder WithTo(string to)
            {
                request.To = to;
                return this;
            }

            public MmsRequestBuilder WithText(string text)
            {
                request.Text = text;
                return this;
            }

            public MmsRequestBuilder WithRef(string inRef)
            {
                request.Ref = inRef;
                return this;
            }

            public MmsRequestBuilder WithOriginCID(string originCID)
            {
                request.OriginCID = originCID;
                return this;
            }

            public MmsRequestBuilder WithTitle(string title)
            {
                request.Title = title;
                return this;
            }

            public MmsRequestBuilder WithFileKey(List<string> filekey)
            {
                request.FileKey = filekey;
                return this;
            }

            public MmsRequestBuilder WithFileKey(string fileKey)
            {
                if (request.FileKey == null)
                {
                    request.FileKey = new List<string>();
                }

                if (request.FileKey.Count < 3)
                {
                    request.FileKey.Add(fileKey);
                }

                return this;
            }

            public MmsRequest Build()
            {
                return this.request;
            }

        }

    }


}