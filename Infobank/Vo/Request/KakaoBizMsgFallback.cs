using Newtonsoft.Json;

namespace Infobank.Vo.Request
{
    public class KakaoBizMsgFallback
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string? Type { get; set; }

        [JsonProperty("from", NullValueHandling = NullValueHandling.Ignore)]
        public string? From { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string? Text { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string? Title { get; set; }

        [JsonProperty("fileKey", NullValueHandling = NullValueHandling.Ignore)]
        public List<string>? FileKey { get; set; }

        [JsonProperty("originCID", NullValueHandling = NullValueHandling.Ignore)]
        public string? OrginCID { get; set; }

        private KakaoBizMsgFallback() { }

        public static KakaoBizMsgFallbackBuilder Builder()
        {
            return new KakaoBizMsgFallbackBuilder();
        }

        public class KakaoBizMsgFallbackBuilder
        {
            private readonly KakaoBizMsgFallback kakaoBizMsgFallback;

            public KakaoBizMsgFallbackBuilder()
            {
                kakaoBizMsgFallback = new KakaoBizMsgFallback();
            }

            public KakaoBizMsgFallbackBuilder WithType(string type)
            {
                kakaoBizMsgFallback.Type = type;
                return this;
            }

            public KakaoBizMsgFallbackBuilder WithFrom(string from)
            {
                kakaoBizMsgFallback.From = from;
                return this;
            }

            public KakaoBizMsgFallbackBuilder WithText(string text)
            {
                kakaoBizMsgFallback.Text = text;
                return this;
            }

            public KakaoBizMsgFallbackBuilder WithTitle(string title)
            {
                kakaoBizMsgFallback.Title = title;
                return this;
            }

            public KakaoBizMsgFallbackBuilder WithFileKey(string fileKey)
            {
                kakaoBizMsgFallback.FileKey ??= new List<string>();
                if (kakaoBizMsgFallback.FileKey.Count < 3)
                {
                    kakaoBizMsgFallback.FileKey.Add(fileKey);
                }
                return this;
            }

            public KakaoBizMsgFallbackBuilder WithFileKeys(IEnumerable<String> fileKeys)
            {
                kakaoBizMsgFallback.FileKey ??= new List<string>();
                List<string> fileKeysList = fileKeys.ToList();
                if (kakaoBizMsgFallback.FileKey.Count < 3 && fileKeysList.Count <= 3)
                {
                    kakaoBizMsgFallback.FileKey.AddRange(fileKeys);
                }
                return this;
            }

            public KakaoBizMsgFallbackBuilder WithOriginCID(string originCID)
            {
                kakaoBizMsgFallback.OrginCID = originCID;
                return this;
            }

            public KakaoBizMsgFallback Build()
            {
                return kakaoBizMsgFallback;
            }
        }

    }
}