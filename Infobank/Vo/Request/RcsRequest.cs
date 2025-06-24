using Infobank.Common;
using Newtonsoft.Json;

namespace Infobank.Vo.Request
{


    public class RcsRequest : MessageRequest
    {
       
        [JsonProperty("content")]
        public RcsContent? Content { get; set; }
    
        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("formatId")]
        public string FormatId { get; set; }

        [JsonProperty("brandKey")]
        public string BrandKey { get; set; }

        [JsonProperty("brandId", NullValueHandling = NullValueHandling.Ignore)]
        public string? BrandId { get; set; }


        [JsonProperty(PropertyName = "expiryOption", NullValueHandling = NullValueHandling.Ignore)]
        public string? ExpiryOption { get; set; }

        [JsonProperty(PropertyName = "header", NullValueHandling = NullValueHandling.Ignore)]
        public string? Header { get; set; }

        [JsonProperty(PropertyName = "footer", NullValueHandling = NullValueHandling.Ignore)]
        public string? Footer { get; set; }

        [JsonProperty(PropertyName = "ref", NullValueHandling = NullValueHandling.Ignore)]
        public string? Ref { get; set; }


        [JsonProperty(PropertyName = "fallback", NullValueHandling = NullValueHandling.Ignore)]
        public RcsFallbackMsg? RcsFallbackMsg { get; set; }



        private RcsRequest()
        {
            //mandatory
            this.From = "";
            this.To = "";
            this.Content = null;
            this.FormatId = "";
            this.BrandKey = "";

            //optional
            this.Ref = null;
            this.Header = null;
            this.Footer = null;
            this.ExpiryOption = null;
            this.RcsFallbackMsg = null;
            this.BrandId = null;

        }

        public static RcsRequestBuilder Builder()
        {
            return new RcsRequestBuilder();
        }

        public class RcsRequestBuilder
        {

            private readonly RcsRequest request;
            public RcsRequestBuilder(RcsRequest request)
            {
                this.request = request;

            }
            public RcsRequestBuilder()
            {
                this.request = new RcsRequest();
            }
            
            public RcsRequestBuilder WithRcsContent(RcsContent content)
            {
                request.Content = content;
                return this;
            }
            
            public RcsRequestBuilder WithFrom(string from)
            {
                request.From = from;
                return this;
            }

            public RcsRequestBuilder WithTo(string to)
            {
                request.To = to;
                return this;
            }
            public RcsRequestBuilder WithFormatId(string formatId)
            {
                request.FormatId = formatId;
                return this;
            }
            public RcsRequestBuilder WithBrandKey(string brandKey)
            {
                request.BrandKey = brandKey;
                return this;
            }

            public RcsRequestBuilder WithBrandId(string brandId)
            {
                request.BrandId = brandId;
                return this;
            }

            public RcsRequestBuilder WithHeader(string header)
            {
                request.Header = header;
                return this;
            }

            public RcsRequestBuilder WithFooter(string footer)
            {
                request.Footer = footer;
                return this;
            }

            public RcsRequestBuilder WithExpiryOption(string expiryOption)
            {
                request.ExpiryOption = expiryOption;
                return this;
            }

            public RcsRequestBuilder WithRef(string inRef)
            {
                request.Ref = inRef;
                return this;
            }

            public RcsRequestBuilder WithRcsFallbackMsg(RcsFallbackMsg fallbackMsg)
            {
                request.RcsFallbackMsg = fallbackMsg;
                return this;
            }

            public RcsRequest Build()
            {
                return this.request;
            }

        }

    }


}