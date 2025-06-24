using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Infobank.Vo.Request
{

    public abstract class RcsContentObject
    {

    }

    public class RcsCarouselJsonConverter : JsonConverter<RcsCarousel>
    {
        public override void WriteJson(JsonWriter writer, RcsCarousel? value, JsonSerializer serializer)
        {
            if (value is not null)
            {
                Object? data = value.GetCarouselElements();
                if (data is not null)
                {
                    JArray jsonArray = JArray.FromObject(data);
                    jsonArray.WriteTo(writer);
                }
            }
        }

        public override RcsCarousel ReadJson(JsonReader reader, Type objectType, RcsCarousel? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }


    public class RcsTemplateJsonConverter : JsonConverter<RcsTemplate>
    {
        public override void WriteJson(JsonWriter writer, RcsTemplate? value, JsonSerializer serializer)
        {

            if (value is not null)
            {

                JToken t = JToken.FromObject(value);

                if (t.Type != JTokenType.Object)
                {
                    t.WriteTo(writer);
                }
                else
                {
                    JObject data = (JObject)t;
                    if (value.TemplateKeyValue is not null)
                    {
                        foreach (KeyValuePair<string, string> entry in value.TemplateKeyValue)
                        {
                            data.Add(new JProperty(entry.Key, entry.Value));
                        }
                    }


                    /*      
                    if (value.Description is not null)
                    {
                        data.AddFirst(new JProperty("description", value.Description));
                    }


                    if (value.RcsSubContent is not null)
                    {
                        IList<RcsSubContent> subContent = value.RcsSubContent;
                        data.Add(subContent);
                    }

                    */

                    data.WriteTo(writer);
                }
            }
        }

        public override RcsTemplate ReadJson(JsonReader reader, Type objectType, RcsTemplate? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }


    public class RcsContent
    {

        [JsonIgnore]
        public RcsContentObject? RcsContentObject { get; set; }

        [JsonProperty("standalone", NullValueHandling = NullValueHandling.Ignore)]
        protected RcsStandAlone? RcsStandAlone { get; set; }

        [JsonProperty("carousel", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(RcsCarouselJsonConverter))]
        protected RcsCarousel? RcsCarousel { get; set; }

        [JsonProperty("template", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(RcsTemplateJsonConverter))]
        protected RcsTemplate? RcsTemplate { get; set; }

        private RcsContent()
        {
            this.RcsContentObject = null;
            this.RcsCarousel = null;
            this.RcsCarousel = null;
            this.RcsTemplate = null;
        }

        public static RcsContentBuilder Builder()
        {
            return new RcsContentBuilder();
        }


        public class RcsContentBuilder
        {
            private readonly RcsContent _rcsContent;
            private bool _isRcsContentSet = false;

            public RcsContentBuilder()
            {
                _rcsContent = new RcsContent();
            }

            public RcsContentBuilder SetRcsContent(RcsContentObject rcsContent)
            {

                // 이미 설정한 Content가 있다면, 더 설정을 못하도록 강제 한다. 
                if (_isRcsContentSet)
                {
                    throw new InvalidOperationException("RcsContent has already been set.");
                }

                switch (rcsContent)
                {
                    case RcsStandAlone standAlone:
                        _rcsContent.RcsStandAlone = standAlone;
                        _isRcsContentSet = true;
                        break;
                    case RcsCarousel carousel:
                        _rcsContent.RcsCarousel = carousel;
                        _isRcsContentSet = true;
                        break;
                    case RcsTemplate template:
                        _rcsContent.RcsTemplate = template;
                        _isRcsContentSet = true;
                        break;
                }

                return this;
            }

            public RcsContent Build()
            {
                return this._rcsContent;

            }

        }

    }

    public class RcsStandAlone : RcsContentObject
    {
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string? Text { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string? Title { get; set; }

        [JsonProperty("media", NullValueHandling = NullValueHandling.Ignore)]
        public string? Media { get; set; }

        [JsonProperty("mediaUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string? MediaUrl { get; set; }

        [JsonProperty("button", NullValueHandling = NullValueHandling.Ignore)]
        public List<RcsButton>? Buttons { get; set; }

        [JsonProperty("subContent", NullValueHandling = NullValueHandling.Ignore)]
        public List<RcsSubContent>? SubContents { get; set; }

        private RcsStandAlone()
        {
            Text = null;
            Title = null;
            Media = null;
            MediaUrl = null;
            Buttons = null;
            SubContents = null;

        }
        public static RcsStandAloneBuilder Builder()
        {
            return new RcsStandAloneBuilder();
        }

        public class RcsStandAloneBuilder
        {
            private readonly RcsStandAlone rcsStandAlone;

            public RcsStandAloneBuilder()
            {
                rcsStandAlone = new RcsStandAlone();
            }

            public RcsStandAloneBuilder WithText(string text)
            {
                rcsStandAlone.Text = text;
                return this;
            }

            public RcsStandAloneBuilder WithTitle(string title)
            {
                rcsStandAlone.Title = title;
                return this;
            }

            public RcsStandAloneBuilder WithMedia(string media)
            {
                rcsStandAlone.Media = media;
                return this;
            }

            public RcsStandAloneBuilder WithMediaUrl(string mediaUrl)
            {
                rcsStandAlone.MediaUrl = mediaUrl;
                return this;
            }

            public RcsStandAloneBuilder WithButton(RcsButton button)
            {
                rcsStandAlone.Buttons ??= new List<RcsButton>();
                rcsStandAlone.Buttons.Add(button);
                return this;
            }

            public RcsStandAloneBuilder WithButtons(IEnumerable<RcsButton> buttons)
            {
                rcsStandAlone.Buttons ??= new List<RcsButton>();
                rcsStandAlone.Buttons.AddRange(buttons);
                return this;
            }

            public RcsStandAloneBuilder WithSubContent(RcsSubContent subContent)
            {
                rcsStandAlone.SubContents ??= new List<RcsSubContent>();
                rcsStandAlone.SubContents.Add(subContent);

                return this;
            }

            public RcsStandAloneBuilder WithSubContents(IEnumerable<RcsSubContent> subContents)
            {
                rcsStandAlone.SubContents ??= new List<RcsSubContent>();
                rcsStandAlone.SubContents.AddRange(subContents);

                return this;
            }

            public RcsStandAlone Build()
            {
                return rcsStandAlone;
            }
        }



    }




    public class RcsCarousel : RcsContentObject
    {
        private IList<RcsCarouselElement>? _rcsCorouselContent;

        private RcsCarousel()
        {
            this._rcsCorouselContent = null;
        }

        private bool AddRcsCorouselElement(RcsCarouselElement element)
        {
            this._rcsCorouselContent ??= new List<RcsCarouselElement>();
            this._rcsCorouselContent.Add(element);
            return true;

        }
        public IList<RcsCarouselElement>? GetCarouselElements()
        {
            return _rcsCorouselContent;
        }

        public static RcsCarouselBuilder Builder()
        {
            return new RcsCarouselBuilder();
        }

        public class RcsCarouselBuilder
        {

            private readonly RcsCarousel rcsCarouselContent;

            public RcsCarouselBuilder()
            {
                rcsCarouselContent = new RcsCarousel();
            }

            public RcsCarouselBuilder WithRcsCarouselElement(RcsCarouselElement element)
            {
                rcsCarouselContent.AddRcsCorouselElement(element);
                return this;
            }

            public RcsCarouselBuilder WithRcsCarouselElements(IEnumerable<RcsCarouselElement> elements)
            {
                foreach (var element in elements)
                {
                    rcsCarouselContent.AddRcsCorouselElement(element);
                }

                return this;
            }

            public RcsCarousel Build()
            {
                return rcsCarouselContent;
            }
        }
    }

    public class RcsCarouselElement
    {
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string? Text { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string? Title { get; set; }

        [JsonProperty("media", NullValueHandling = NullValueHandling.Ignore)]
        public string? Media { get; set; }

        [JsonProperty("mediaUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string? MediaUrl { get; set; }

        [JsonProperty("button", NullValueHandling = NullValueHandling.Ignore)]
        public List<RcsButton>? Buttons { get; set; }

        private RcsCarouselElement()
        {
            Text = null;
            Title = null;
            Media = null;
            MediaUrl = null;
            Buttons = null;

        }

        public static RcsCarouselElementBuilder Builder()
        {
            return new RcsCarouselElementBuilder();
        }
        public class RcsCarouselElementBuilder
        {
            private readonly RcsCarouselElement rcsCarouselElement;

            public RcsCarouselElementBuilder()
            {
                rcsCarouselElement = new RcsCarouselElement();
            }

            public RcsCarouselElementBuilder WithText(string text)
            {
                rcsCarouselElement.Text = text;
                return this;
            }

            public RcsCarouselElementBuilder WithTitle(string title)
            {
                rcsCarouselElement.Title = title;
                return this;
            }

            public RcsCarouselElementBuilder WithMedia(string media)
            {
                rcsCarouselElement.Media = media;
                return this;
            }

            public RcsCarouselElementBuilder WithMediaUrl(string mediaUrl)
            {
                rcsCarouselElement.MediaUrl = mediaUrl;
                return this;
            }

            public RcsCarouselElementBuilder WithButton(RcsButton button)
            {
                rcsCarouselElement.Buttons ??= new List<RcsButton>();
                rcsCarouselElement.Buttons.Add(button);
                return this;
            }

            public RcsCarouselElementBuilder WithButtons(IEnumerable<RcsButton> buttons)
            {
                rcsCarouselElement.Buttons ??= new List<RcsButton>();
                rcsCarouselElement.Buttons.AddRange(buttons);
                return this;
            }


            public RcsCarouselElement Build()
            {
                return rcsCarouselElement;
            }
        }
    }




    public class RcsTemplate : RcsContentObject
    {
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string? Description { get; set; }
        [JsonIgnore]
        public Dictionary<string, string>? TemplateKeyValue { get; set; }

        [JsonProperty("subContent", NullValueHandling = NullValueHandling.Ignore)]
        public List<RcsSubContent>? RcsSubContent { get; set; }

        private RcsTemplate()
        {
            Description = null;
            TemplateKeyValue = null;
            RcsSubContent = null;
        }

        public static RcsTemplateBuilder Builder()
        {
            return new RcsTemplateBuilder();
        }


        public class RcsTemplateBuilder
        {
            private readonly RcsTemplate template;

            public RcsTemplateBuilder()
            {
                template = new RcsTemplate();
            }

            public RcsTemplateBuilder WithDescription(string description)
            {
                template.Description = description;
                return this;
            }
            public RcsTemplateBuilder WithTemplateKeyValue(Action<Dictionary<string, string>> keyValueAction)
            {
                var keyValue = new Dictionary<string, string>();
                keyValueAction(keyValue);
                template.TemplateKeyValue = keyValue;
                return this;
            }

            public RcsTemplateBuilder WithSubContent(RcsSubContent rcsSubContent)
            {
                template.RcsSubContent ??= new List<RcsSubContent>();
                template.RcsSubContent.Add(rcsSubContent);
                return this;
            }

            public RcsTemplateBuilder WithSubContents(IEnumerable<RcsSubContent> rcsSubContents)
            {
                template.RcsSubContent ??= new List<RcsSubContent>();
                template.RcsSubContent.AddRange(rcsSubContents);
                return this;
            }

            public RcsTemplate Build()
            {
                return template;
            }
        }
    }



    public class RcsSubContent
    {
        public string? SubTitle { get; set; }
        public string? SubDesc { get; set; }
        public string? SubMedia { get; set; }
        public string? SubMediaUrl { get; set; }

        private RcsSubContent()
        {
            SubTitle = null;
            SubDesc = null;
            SubMedia = null;
            SubMediaUrl = null;
        }

        public static RcsSubContentBuilder Builder()
        {
            return new RcsSubContentBuilder();
        }

        public class RcsSubContentBuilder
        {
            private readonly RcsSubContent subContent;

            public RcsSubContentBuilder()
            {
                subContent = new RcsSubContent();
            }

            public RcsSubContentBuilder WithSubTitle(string subTitle)
            {
                subContent.SubTitle = subTitle;
                return this;
            }

            public RcsSubContentBuilder WithSubDesc(string subDesc)
            {
                subContent.SubDesc = subDesc;
                return this;
            }

            public RcsSubContentBuilder WithSubMedia(string subMedia)
            {
                subContent.SubMedia = subMedia;
                return this;
            }

            public RcsSubContentBuilder WithSubMediaUrl(string subMediaUrl)
            {
                subContent.SubMediaUrl = subMediaUrl;
                return this;
            }

            public RcsSubContent Build()
            {
                return subContent;
            }
        }
    }


}
