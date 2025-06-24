using Newtonsoft.Json;

namespace Infobank.Vo.Request
{
    public class RcsFallbackMsg
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public string? Title { get; set; }

        [JsonProperty(PropertyName = "fileKey", NullValueHandling = NullValueHandling.Ignore)]
        public List<string>? FileKey { get; set; }

        [JsonProperty(PropertyName = "originCID", NullValueHandling = NullValueHandling.Ignore)]
        public string? OriginCID { get; set; }

        private RcsFallbackMsg()
        {
            this.Type = "";
            this.Text = "";
            this.Title = null;
            this.FileKey = null;
            this.OriginCID = null;

        }

        public static RcsFallbackMsgBuilder Builder()
        {
            return new RcsFallbackMsgBuilder();
        }

        public class RcsFallbackMsgBuilder
        {
            private readonly RcsFallbackMsg request;

            public RcsFallbackMsgBuilder(RcsFallbackMsg request)
            {
                this.request = request;

            }
            public RcsFallbackMsgBuilder()
            {
                this.request = new RcsFallbackMsg();
            }

            public RcsFallbackMsgBuilder WithType(string type)
            {
                request.Type = type;
                return this;
            }

            public RcsFallbackMsgBuilder WithText(string text)
            {
                request.Text = text;
                return this;
            }

            public RcsFallbackMsgBuilder WithTitle(string title)
            {
                request.Title = title;
                return this;
            }

            public RcsFallbackMsgBuilder WithFileKey(string fileKey)
            {
                request.FileKey ??= new List<string>();
                request.FileKey.Add(fileKey);

                return this;
            }
            public RcsFallbackMsgBuilder WithFileKey(IEnumerable<string> fileKeys)
            {
                request.FileKey ??= new List<string>();
                foreach (var fileKey in fileKeys)
                {
                    if (request.FileKey.Count < 3)
                    {
                        request.FileKey.Add(fileKey);
                    }
                }

                return this;
            }
            public RcsFallbackMsgBuilder WithOriginCID(string originCID)
            {
                request.OriginCID = originCID;
                return this;
            }

            public RcsFallbackMsg Build()
            {
                return request;
            }
        }

    }


}