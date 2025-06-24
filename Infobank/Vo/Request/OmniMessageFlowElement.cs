using Newtonsoft.Json;
using KakaoBrandTalkButton = Infobank.Vo.Request.KakaoFriendTalkButton;

namespace Infobank.Vo.Request
{
    public abstract class OmniMessageFlowElement { }

    public class OmniMessageFlowElementSms : OmniMessageFlowElement
    {
        [JsonProperty("from")]
        public string From { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("ttl", NullValueHandling = NullValueHandling.Ignore)]
        public string? Ttl { get; set; }
        [JsonProperty("originCID", NullValueHandling = NullValueHandling.Ignore)]
        public String? OriginCID { get; set; }

        private OmniMessageFlowElementSms()
        {
            From = "";
            Text = "";
            Ttl = null;
            OriginCID = null;
        }

        public static OmniMessageFlowElementSmsBuilder Builder()
        {
            return new OmniMessageFlowElementSmsBuilder();
        }

        public class OmniMessageFlowElementSmsBuilder
        {

            private readonly OmniMessageFlowElementSms _messageFlowSms;
            public OmniMessageFlowElementSmsBuilder()
            {
                _messageFlowSms = new OmniMessageFlowElementSms();
            }
            public OmniMessageFlowElementSmsBuilder(OmniMessageFlowElementSms messageFlowSms)
            {
                _messageFlowSms = messageFlowSms;
            }

            public OmniMessageFlowElementSmsBuilder WithFrom(string from)
            {
                _messageFlowSms.From = from;
                return this;
            }
            public OmniMessageFlowElementSmsBuilder WithText(string text)
            {
                _messageFlowSms.Text = text;
                return this;
            }

            public OmniMessageFlowElementSmsBuilder WithTtl(string Ttl)
            {
                _messageFlowSms.Ttl = Ttl;
                return this;
            }

            public OmniMessageFlowElementSmsBuilder WithOriginCID(string OriginCID)
            {
                _messageFlowSms.OriginCID = OriginCID;
                return this;
            }

            public OmniMessageFlowElementSms Build()
            {
                return _messageFlowSms;
            }

        }
    }

    public class OmniMessageFlowElementMms : OmniMessageFlowElement
    {
        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public string? Title { get; set; }

        [JsonProperty(PropertyName = "fileKey", NullValueHandling = NullValueHandling.Ignore)]
        public List<string>? FileKeys { get; set; }

        [JsonProperty(PropertyName = "ttl", NullValueHandling = NullValueHandling.Ignore)]
        public string? Ttl { get; set; }
        [JsonProperty(PropertyName = "originCID", NullValueHandling = NullValueHandling.Ignore)]
        public String? OriginCID { get; set; }

        private OmniMessageFlowElementMms()
        {
            From = "";
            Text = "";
            Title = null;
            FileKeys = null;
            Ttl = null;
            OriginCID = null;
        }

        public static OmniMessageFlowElementMmsBuilder Builder()
        {
            return new OmniMessageFlowElementMmsBuilder();
        }

        public class OmniMessageFlowElementMmsBuilder
        {

            private readonly OmniMessageFlowElementMms _messageFlowMms;
            public OmniMessageFlowElementMmsBuilder()
            {
                _messageFlowMms = new OmniMessageFlowElementMms();
            }
            public OmniMessageFlowElementMmsBuilder(OmniMessageFlowElementMms messageFlowMms)
            {
                _messageFlowMms = messageFlowMms;
            }

            public OmniMessageFlowElementMmsBuilder WithFrom(string from)
            {
                _messageFlowMms.From = from;
                return this;
            }
            public OmniMessageFlowElementMmsBuilder WithText(string text)
            {
                _messageFlowMms.Text = text;
                return this;
            }

            public OmniMessageFlowElementMmsBuilder WithTtl(string ttl)
            {
                _messageFlowMms.Ttl = ttl;
                return this;
            }

            public OmniMessageFlowElementMmsBuilder WithOriginCID(string originCID)
            {
                _messageFlowMms.OriginCID = originCID;
                return this;
            }

            public OmniMessageFlowElementMmsBuilder WithTitle(string title)
            {
                _messageFlowMms.Title = title;
                return this;
            }

            public OmniMessageFlowElementMmsBuilder WithFileKey(string fileKey)
            {
                _messageFlowMms.FileKeys ??= new List<string>();
                _messageFlowMms.FileKeys.Add(fileKey);
                return this;
            }

            public OmniMessageFlowElementMmsBuilder WithFileKeys(IEnumerable<string> fileKeys)
            {
                _messageFlowMms.FileKeys ??= new List<string>();
                _messageFlowMms.FileKeys.AddRange(fileKeys);
                return this;
            }

            public OmniMessageFlowElementMms Build()
            {
                return _messageFlowMms;
            }

        }
    }

    public class OmniMessageFlowElementRcs : OmniMessageFlowElement
    {
        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("content")]
        public RcsContent? Content { get; set; }

        [JsonProperty("formatId")]
        public string FormatId { get; set; }

        [JsonProperty("brandKey")]
        public string BrandKey { get; set; }

        [JsonProperty("brandId", NullValueHandling = NullValueHandling.Ignore)]
        public string? BrandId { get; set; }

        [JsonProperty(PropertyName = "expiryOption", NullValueHandling = NullValueHandling.Ignore)]
        public string? ExpiryOption { get; set; }

        [JsonProperty(PropertyName = "copyAllow", NullValueHandling = NullValueHandling.Ignore)]
        public string? CopyAllow { get; set; }

        [JsonProperty(PropertyName = "header", NullValueHandling = NullValueHandling.Ignore)]
        public string? Header { get; set; }

        [JsonProperty(PropertyName = "footer", NullValueHandling = NullValueHandling.Ignore)]
        public string? Footer { get; set; }

        [JsonProperty(PropertyName = "agencyId", NullValueHandling = NullValueHandling.Ignore)]
        public string? AgencyId { get; set; }

        [JsonProperty(PropertyName = "agencyKey", NullValueHandling = NullValueHandling.Ignore)]
        public string? AgencyKey { get; set; }

        [JsonProperty(PropertyName = "ttl", NullValueHandling = NullValueHandling.Ignore)]
        public string? Ttl { get; set; }

        private OmniMessageFlowElementRcs()
        {
            //mandatory
            this.From = "";
            this.Content = null;
            this.FormatId = "";
            this.BrandKey = "";

            //optional
            this.Header = null;
            this.Footer = null;
            this.ExpiryOption = null;
            this.CopyAllow = null;
            this.BrandId = null;
            this.AgencyId = null;
            this.AgencyKey = null;
            this.Ttl = null;

        }

        public static OmniMessageFlowElementRcsBuilder Builder()
        {
            return new OmniMessageFlowElementRcsBuilder();
        }

        public class OmniMessageFlowElementRcsBuilder
        {

            private readonly OmniMessageFlowElementRcs _messageFlowRcs;
            public OmniMessageFlowElementRcsBuilder(OmniMessageFlowElementRcs messageFlowRcs)
            {
                this._messageFlowRcs = messageFlowRcs;

            }
            public OmniMessageFlowElementRcsBuilder()
            {
                this._messageFlowRcs = new OmniMessageFlowElementRcs();
            }

            public OmniMessageFlowElementRcsBuilder WithRcsContent(RcsContent content)
            {
                _messageFlowRcs.Content = content;
                return this;
            }

            public OmniMessageFlowElementRcsBuilder WithFrom(string from)
            {
                _messageFlowRcs.From = from;
                return this;
            }

            public OmniMessageFlowElementRcsBuilder WithFormatId(string formatId)
            {
                _messageFlowRcs.FormatId = formatId;
                return this;
            }
            public OmniMessageFlowElementRcsBuilder WithBrandKey(string brandKey)
            {
                _messageFlowRcs.BrandKey = brandKey;
                return this;
            }

            public OmniMessageFlowElementRcsBuilder WithBrandId(string brandId)
            {
                _messageFlowRcs.BrandId = brandId;
                return this;
            }

            public OmniMessageFlowElementRcsBuilder WithHeader(string header)
            {
                _messageFlowRcs.Header = header;
                return this;
            }

            public OmniMessageFlowElementRcsBuilder WithFooter(string footer)
            {
                _messageFlowRcs.Footer = footer;
                return this;
            }

            public OmniMessageFlowElementRcsBuilder WithExpiryOption(string expiryOption)
            {
                _messageFlowRcs.ExpiryOption = expiryOption;
                return this;
            }
            public OmniMessageFlowElementRcsBuilder WithCopyAllow(string copyAllow)
            {
                _messageFlowRcs.CopyAllow = copyAllow;
                return this;
            }

            public OmniMessageFlowElementRcsBuilder WithTtl(string ttl)
            {
                _messageFlowRcs.Ttl = ttl;
                return this;
            }

            public OmniMessageFlowElementRcsBuilder WithAgencyId(string agencyId)
            {
                _messageFlowRcs.AgencyId = agencyId;
                return this;
            }

            public OmniMessageFlowElementRcsBuilder WithAgencyKey(string agencyKey)
            {
                _messageFlowRcs.AgencyKey = agencyKey;
                return this;
            }

            public OmniMessageFlowElementRcs Build()
            {
                return this._messageFlowRcs;
            }

        }
    }

    public class OmniMessageFlowElementAlimTalk : OmniMessageFlowElement
    {
        [JsonProperty("senderKey")]
        public string SenderKey { get; set; }

        [JsonProperty("msgType")]
        public string MsgType { get; set; }

        [JsonProperty("templateCode")]
        public string TemplateCode { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("header")]
        public string? Header { get; set; }

        [JsonProperty("link")]
        public AlimTalkLink? Link { get; set; }

        [JsonProperty(PropertyName = "attachment", NullValueHandling = NullValueHandling.Ignore)]
        public KakaoAlimAttachment? Attachment { get; set; }

        [JsonProperty(PropertyName = "supplement", NullValueHandling = NullValueHandling.Ignore)]
        public KakaoSupplement? Supplement { get; set; }

        [JsonProperty(PropertyName = "price", NullValueHandling = NullValueHandling.Ignore)]
        public string? Price { get; set; }

        [JsonProperty(PropertyName = "currencyType", NullValueHandling = NullValueHandling.Ignore)]
        public string? CurrencyType { get; set; }


        private OmniMessageFlowElementAlimTalk()
        {
            this.SenderKey = "";
            this.MsgType = "";
            this.TemplateCode = "";
            this.Text = "";

            this.Title = null;
            this.Header = null;
            this.Link = null;
            this.Attachment = null;
            this.Supplement = null;
            this.Price = null;
            this.CurrencyType = null;

        }


        public static OmniMessageFlowElementAlimTalkBuilder Builder()
        {
            return new OmniMessageFlowElementAlimTalkBuilder();
        }

        public class OmniMessageFlowElementAlimTalkBuilder
        {

            private readonly OmniMessageFlowElementAlimTalk _messageFlowAlimTalk;

            public OmniMessageFlowElementAlimTalkBuilder()
            {
                this._messageFlowAlimTalk = new OmniMessageFlowElementAlimTalk();
            }

            public OmniMessageFlowElementAlimTalkBuilder WithSenderKey(string senderKey)
            {
                _messageFlowAlimTalk.SenderKey = senderKey;
                return this;
            }
            public OmniMessageFlowElementAlimTalkBuilder WithTitle(string title)
            {
                _messageFlowAlimTalk.Title = title;
                return this;
            }


            public OmniMessageFlowElementAlimTalkBuilder WithHeader(string header)
            {
                _messageFlowAlimTalk.Header = header;
                return this;
            }

            public OmniMessageFlowElementAlimTalkBuilder WithLink(AlimTalkLink link)
            {
                _messageFlowAlimTalk.Link = link;
                return this;
            }

            public OmniMessageFlowElementAlimTalkBuilder WithText(string text)
            {
                _messageFlowAlimTalk.Text = text;
                return this;
            }


            public OmniMessageFlowElementAlimTalkBuilder WithMsgType(string msgType)
            {
                if (KakaoBizMsgCheckField.ALIM_TALK_MSG_TYPE.IsValid(msgType) == false)
                {
                    throw new InvalidDataException("Not Supported AlimTalk Message Type");
                }
                _messageFlowAlimTalk.MsgType = msgType;
                return this;
            }

            public OmniMessageFlowElementAlimTalkBuilder WithTemplateCode(string templateCode)
            {
                _messageFlowAlimTalk.TemplateCode = templateCode;
                return this;
            }


            public OmniMessageFlowElementAlimTalkBuilder WithAttachment(KakaoAlimAttachment attachment)
            {
                _messageFlowAlimTalk.Attachment = attachment;
                return this;
            }

            public OmniMessageFlowElementAlimTalkBuilder WithSupplyment(KakaoSupplement supplement)
            {
                _messageFlowAlimTalk.Supplement = supplement;

                return this;
            }
            public OmniMessageFlowElementAlimTalkBuilder WithCurrencyType(string currencyType)
            {
                _messageFlowAlimTalk.CurrencyType = currencyType;
                return this;
            }
            public OmniMessageFlowElementAlimTalkBuilder WithPrice(string price)
            {
                _messageFlowAlimTalk.Price = price;
                return this;
            }
            public OmniMessageFlowElementAlimTalk Build()
            {
                return this._messageFlowAlimTalk;
            }

        }
    }


    public class OmniMessageFlowElementFriendTalk : OmniMessageFlowElement
    {
        [JsonProperty("senderKey")]
        public string SenderKey { get; set; }

        [JsonProperty("msgType")]
        public string MsgType { get; set; }

        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonProperty(PropertyName = "attachment", NullValueHandling = NullValueHandling.Ignore)]
        public KakaoFriendAttachment? Attachment { get; set; }

        [JsonProperty(PropertyName = "adFlag", NullValueHandling = NullValueHandling.Ignore)]
        public string? AdFlag { get; set; }

        [JsonProperty(PropertyName = "addtionalContent", NullValueHandling = NullValueHandling.Ignore)]
        public string? AddtionalContent { get; set; }

        [JsonProperty(PropertyName = "adult", NullValueHandling = NullValueHandling.Ignore)]
        public string? Adult { get; set; }

        [JsonProperty(PropertyName = "header", NullValueHandling = NullValueHandling.Ignore)]
        public string? Header { get; set; }

        [JsonProperty(PropertyName = "carousel", NullValueHandling = NullValueHandling.Ignore)]
        public KakaoFriendTalkCarousel? Carousel { get; set; }

        [JsonProperty(PropertyName = "groupTagKey", NullValueHandling = NullValueHandling.Ignore)]
        public string? GroupTagKey { get; set; }

        [JsonProperty(PropertyName = "pushAlarm", NullValueHandling = NullValueHandling.Ignore)]
        public string? PushAlarm { get; set; }



        private OmniMessageFlowElementFriendTalk()
        {
            this.SenderKey = "";
            this.MsgType = "";
            this.Text = null;

            this.Attachment = null;
            this.AdFlag = null;

            this.AddtionalContent = null;
            this.Adult = null;
            this.Header = null;
            this.Carousel = null;
            this.GroupTagKey = null;
            this.PushAlarm = null;

        }


        public static OmniMessageFlowElementFriendTalkBuilder Builder()
        {
            return new OmniMessageFlowElementFriendTalkBuilder();
        }

        public class OmniMessageFlowElementFriendTalkBuilder
        {

            private readonly OmniMessageFlowElementFriendTalk _messageFlowFriendTalk;

            public OmniMessageFlowElementFriendTalkBuilder()
            {
                this._messageFlowFriendTalk = new OmniMessageFlowElementFriendTalk();
            }

            public OmniMessageFlowElementFriendTalkBuilder WithSenderKey(string senderKey)
            {
                _messageFlowFriendTalk.SenderKey = senderKey;
                return this;
            }


            public OmniMessageFlowElementFriendTalkBuilder WithText(string text)
            {
                _messageFlowFriendTalk.Text = text;
                return this;
            }

            public OmniMessageFlowElementFriendTalkBuilder WithMsgType(string msgType)
            {
                if (KakaoBizMsgCheckField.FRIEND_TALK_MSG_TYPE.IsValid(msgType) == false)
                {
                    throw new InvalidDataException("Not Supported FriendTalk Message Type");
                }
                _messageFlowFriendTalk.MsgType = msgType;
                return this;
            }


            public OmniMessageFlowElementFriendTalkBuilder WithAttachment(KakaoFriendAttachment attachment)
            {
                _messageFlowFriendTalk.Attachment = attachment;
                return this;
            }

            public OmniMessageFlowElementFriendTalkBuilder WithAdFlag(string adFlag)
            {
                _messageFlowFriendTalk.AdFlag = adFlag;

                return this;
            }

            public OmniMessageFlowElementFriendTalkBuilder WithAddtionalContent(string addtionalContent)
            {
                _messageFlowFriendTalk.AddtionalContent = addtionalContent;

                return this;
            }


            public OmniMessageFlowElementFriendTalkBuilder WithAdult(string adult)
            {
                _messageFlowFriendTalk.Adult = adult;

                return this;
            }


            public OmniMessageFlowElementFriendTalkBuilder WithHeader(string header)
            {
                _messageFlowFriendTalk.Header = header;

                return this;
            }


            public OmniMessageFlowElementFriendTalkBuilder WithCarousel(KakaoFriendTalkCarousel carousel)
            {
                _messageFlowFriendTalk.Carousel = carousel;

                return this;
            }


            public OmniMessageFlowElementFriendTalkBuilder WithGroupTagKey(string groupTagKey)
            {
                _messageFlowFriendTalk.GroupTagKey = groupTagKey;

                return this;
            }


            public OmniMessageFlowElementFriendTalkBuilder WithPushAlarm(string pushAlarm)
            {
                _messageFlowFriendTalk.PushAlarm = pushAlarm;

                return this;
            }


            public OmniMessageFlowElementFriendTalk Build()
            {
                return this._messageFlowFriendTalk;
            }

        }
    }



    /////////////////////// 브랜드 메시지 /////////////////////
    public class OmniMessageFlowElementBrandMessage : OmniMessageFlowElement
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

        private OmniMessageFlowElementBrandMessage(SendType sendType)
        {
            SendType = sendType;
        }

        public static OmniMessageFlowElementBrandMessageBuilder Builder(SendType sendType)
        {
            return new OmniMessageFlowElementBrandMessageBuilder(sendType);
        }

        public class OmniMessageFlowElementBrandMessageBuilder
        {
            private readonly OmniMessageFlowElementBrandMessage _request;

            public OmniMessageFlowElementBrandMessageBuilder(SendType sendType)
            {
                _request = new OmniMessageFlowElementBrandMessage(sendType);
            }

            public OmniMessageFlowElementBrandMessageBuilder WithSenderKey(string senderKey)
            {
                _request.SenderKey = senderKey;
                return this;
            }

            public OmniMessageFlowElementBrandMessageBuilder WithSendType(SendType sendType)
            {
                _request.SendType = sendType;
                return this;
            }

            public OmniMessageFlowElementBrandMessageBuilder WithMsgType(string msgType)
            {
                _request.MsgType = msgType;
                return this;
            }

            public OmniMessageFlowElementBrandMessageBuilder WithTo(string to)
            {
                _request.To = to;
                return this;
            }

            public OmniMessageFlowElementBrandMessageBuilder WithText(string text)
            {
                _request.Text = text;
                return this;
            }

            public OmniMessageFlowElementBrandMessageBuilder WithImgUrl(string imgUrl)
            {
                _request.ImgUrl = imgUrl;
                return this;
            }

            public OmniMessageFlowElementBrandMessageBuilder WithTargeting(string targeting)
            {
                _request.Targeting = targeting;
                return this;
            }

            public OmniMessageFlowElementBrandMessageBuilder WithTemplateCode(string templateCode)
            {
                _request.TemplateCode = templateCode;
                return this;
            }

            public OmniMessageFlowElementBrandMessageBuilder AddButton(KakaoBrandTalkButton button)
            {
                _request.Button ??= [];
                _request.Button.Add(button);
                return this;
            }

            public OmniMessageFlowElementBrandMessageBuilder WithFallback(KakaoBizMsgFallback fallback)
            {
                _request.Fallback = fallback;
                return this;
            }

            public OmniMessageFlowElementBrandMessageBuilder WithGroupTagKey(string groupTagKey)
            {
                _request.GroupTagKey = groupTagKey;
                return this;
            }

            public OmniMessageFlowElementBrandMessageBuilder WithAdult(string adult)
            {
                _request.Adult = adult;
                return this;
            }

            public OmniMessageFlowElementBrandMessageBuilder WithPushAlarm(string pushAlarm)
            {
                _request.PushAlarm = pushAlarm;
                return this;
            }

            public OmniMessageFlowElementBrandMessageBuilder WithMessageVariable(Dictionary<string, object> messageVariable)
            {
                _request.MessageVariable = messageVariable;
                return this;
            }

            public OmniMessageFlowElementBrandMessageBuilder WithButtonVariable(Dictionary<string, object> buttonVariable)
            {
                _request.ButtonVariable = buttonVariable;
                return this;
            }

            public OmniMessageFlowElementBrandMessageBuilder WithCouponVariable(Dictionary<string, object> couponVariable)
            {
                _request.CouponVariable = couponVariable;
                return this;
            }

            public OmniMessageFlowElementBrandMessageBuilder WithImageVariable(List<BrandMessageImageVariableObject> imageVariable)
            {
                _request.ImageVariable = imageVariable;
                return this;
            }

            public OmniMessageFlowElementBrandMessageBuilder WithVideoVariable(Dictionary<string, object> videoVariable)
            {
                _request.VideoVariable = videoVariable;
                return this;
            }

            public OmniMessageFlowElementBrandMessageBuilder WithCommerceVariable(Dictionary<string, object> commerceVariable)
            {
                _request.CommerceVariable = commerceVariable;
                return this;
            }

            public OmniMessageFlowElementBrandMessageBuilder WithCarouselVariable(List<BrandMessageCarouselVariableObject> carouselVariable)
            {
                _request.CarouselVariable ??= [];
                _request.CarouselVariable = carouselVariable;
                return this;
            }

            public OmniMessageFlowElementBrandMessageBuilder AddCarouselVariable(BrandMessageCarouselVariableObject carouselVariable)
            {
                _request.CarouselVariable ??= [];
                _request.CarouselVariable.Add(carouselVariable);
                return this;
            }

            public OmniMessageFlowElementBrandMessageBuilder WithOriginCID(string originCID)
            {
                _request.OriginCID = originCID;
                return this;
            }

            public OmniMessageFlowElementBrandMessageBuilder WithUnsubscribePhoneNumber(string unsubscribePhoneNumber)
            {
                _request.UnsubscribePhoneNumber = unsubscribePhoneNumber;
                return this;
            }

            public OmniMessageFlowElementBrandMessageBuilder WithUnsubscribeAuthNumber(string unsubscribeAuthNumber)
            {
                _request.UnsubscribeAuthNumber = unsubscribeAuthNumber;
                return this;
            }

            public OmniMessageFlowElementBrandMessageBuilder WithRef(string refValue)
            {
                _request.Ref = refValue;
                return this;
            }

            public OmniMessageFlowElementBrandMessage Build()
            {
                return _request;
            }

        }
    }


    public class KakaoAlimAttachment
    {
        [JsonProperty(PropertyName = "button", NullValueHandling = NullValueHandling.Ignore)]
        public List<KakaoAlimTalkButton>? Buttons;

        [JsonProperty(PropertyName = "item", NullValueHandling = NullValueHandling.Ignore)]
        public KakaoAlimTalkItem? Item;

        [JsonProperty(PropertyName = "itemHighlight", NullValueHandling = NullValueHandling.Ignore)]
        public KakaoBizMsgItemHighlight? ItemHighlight;

        private KakaoAlimAttachment()
        {
            this.Buttons = null;
            this.Item = null;
            this.ItemHighlight = null;

        }
        public static KakaoAlimAttachmentBuilder Builder()
        {
            return new KakaoAlimAttachmentBuilder();
        }

        public class KakaoAlimAttachmentBuilder
        {
            private readonly KakaoAlimAttachment _alimAttachment;

            public KakaoAlimAttachmentBuilder()
            {
                this._alimAttachment = new KakaoAlimAttachment();

            }
            public KakaoAlimAttachmentBuilder WithButton(KakaoAlimTalkButton button)
            {
                this._alimAttachment.Buttons ??= new List<KakaoAlimTalkButton>();
                this._alimAttachment.Buttons.Add(button);
                return this;
            }
            public KakaoAlimAttachmentBuilder WithButtons(IEnumerable<KakaoAlimTalkButton> buttons)
            {
                this._alimAttachment.Buttons ??= new List<KakaoAlimTalkButton>();
                this._alimAttachment.Buttons.AddRange(buttons);
                return this;
            }

            public KakaoAlimAttachmentBuilder WithItem(KakaoAlimTalkItem item)
            {
                this._alimAttachment.Item = item;
                return this;
            }

            public KakaoAlimAttachmentBuilder WithItemHighlight(KakaoBizMsgItemHighlight itemHighlight)
            {
                this._alimAttachment.ItemHighlight = itemHighlight;
                return this;
            }

            public KakaoAlimAttachment Build()
            {
                return _alimAttachment;
            }

        }
    }

    public class KakaoSupplement
    {
        [JsonProperty("quickReply", NullValueHandling = NullValueHandling.Ignore)]
        public List<AlimTalkQuickReply>? QuickReply;
        private KakaoSupplement()
        {
            this.QuickReply = null;
        }

        public static KakaoSupplementBuilder Builder()
        {
            return new KakaoSupplementBuilder();
        }

        public class KakaoSupplementBuilder
        {
            private readonly KakaoSupplement _kakaoSupplement;
            public KakaoSupplementBuilder()
            {
                _kakaoSupplement = new KakaoSupplement();
            }

            public KakaoSupplementBuilder WithQuickReply(AlimTalkQuickReply quickReply)
            {
                this._kakaoSupplement.QuickReply ??= [];
                this._kakaoSupplement.QuickReply.Add(quickReply);
                return this;
            }

            public KakaoSupplementBuilder WithQuickReplys(IEnumerable<AlimTalkQuickReply> quickReplys)
            {
                this._kakaoSupplement.QuickReply ??= [];
                this._kakaoSupplement.QuickReply.AddRange(quickReplys);
                return this;
            }
            public KakaoSupplement Build()
            {
                return this._kakaoSupplement;
            }
        }
    }


    public class KakaoFriendAttachment
    {
        [JsonProperty(PropertyName = "button", NullValueHandling = NullValueHandling.Ignore)]
        public List<KakaoFriendTalkButton>? Buttons;

        [JsonProperty(PropertyName = "image", NullValueHandling = NullValueHandling.Ignore)]
        public KakaoFriendTalkImage? Image;

        [JsonProperty(PropertyName = "item", NullValueHandling = NullValueHandling.Ignore)]
        public KakaoFriendTalkItem? Item;

        [JsonProperty(PropertyName = "coupon", NullValueHandling = NullValueHandling.Ignore)]
        public KakaoFriendTalkCoupon? Coupon;

        [JsonProperty(PropertyName = "commerce", NullValueHandling = NullValueHandling.Ignore)]
        public KakaoFriendTalkCommerce? Commerce;


        [JsonProperty(PropertyName = "video", NullValueHandling = NullValueHandling.Ignore)]
        public KakaoFriendTalkVideo? Video;



        private KakaoFriendAttachment()
        {
            this.Buttons = null;
            this.Item = null;
            this.Image = null;
            this.Coupon = null;
            this.Commerce = null;
            this.Video = null;

        }
        public static KakaoFriendAttachmentBuilder Builder()
        {
            return new KakaoFriendAttachmentBuilder();
        }

        public class KakaoFriendAttachmentBuilder
        {
            private readonly KakaoFriendAttachment _firendTalkAttachment;

            public KakaoFriendAttachmentBuilder()
            {
                this._firendTalkAttachment = new KakaoFriendAttachment();

            }


            public KakaoFriendAttachmentBuilder WithButton(KakaoFriendTalkButton button)
            {
                this._firendTalkAttachment.Buttons ??= new List<KakaoFriendTalkButton>();
                this._firendTalkAttachment.Buttons.Add(button);
                return this;
            }
            public KakaoFriendAttachmentBuilder WithButtons(IEnumerable<KakaoFriendTalkButton> buttons)
            {
                this._firendTalkAttachment.Buttons ??= new List<KakaoFriendTalkButton>();
                this._firendTalkAttachment.Buttons.AddRange(buttons);
                return this;
            }

            public KakaoFriendAttachmentBuilder WithItem(KakaoFriendTalkItem item)
            {
                this._firendTalkAttachment.Item = item;
                return this;
            }

            public KakaoFriendAttachmentBuilder WithImage(KakaoFriendTalkImage image)
            {
                this._firendTalkAttachment.Image = image;
                return this;
            }
            public KakaoFriendAttachmentBuilder WithCoupon(KakaoFriendTalkCoupon coupon)
            {
                this._firendTalkAttachment.Coupon = coupon;
                return this;
            }

            public KakaoFriendAttachmentBuilder WithCommerce(KakaoFriendTalkCommerce commerce)
            {
                this._firendTalkAttachment.Commerce = commerce;
                return this;
            }

            public KakaoFriendAttachmentBuilder WithVideo(KakaoFriendTalkVideo video)
            {
                this._firendTalkAttachment.Video = video;
                return this;
            }


            public KakaoFriendAttachment Build()
            {
                return _firendTalkAttachment;
            }

        }
    }

    public class KakaoAlimTalkItem
    {
        [JsonProperty(PropertyName = "list", NullValueHandling = NullValueHandling.Ignore)]
        public List<KakaoAlimTalkItemListElement>? ItemLists;

        [JsonProperty(PropertyName = "summary", NullValueHandling = NullValueHandling.Ignore)]
        public KakaoBizMsgSummary? ItepSummary;

        private KakaoAlimTalkItem()
        {
            this.ItepSummary = null;
            this.ItemLists = null;

        }

        public static KakaoBizMsgItemBuilder Builder()
        {
            return new KakaoBizMsgItemBuilder();
        }

        public class KakaoBizMsgItemBuilder
        {
            private readonly KakaoAlimTalkItem _kakaoItem;

            public KakaoBizMsgItemBuilder()
            {
                this._kakaoItem = new KakaoAlimTalkItem();
            }

            public KakaoBizMsgItemBuilder WithItemList(KakaoAlimTalkItemListElement itempList)
            {
                this._kakaoItem.ItemLists ??= [];
                this._kakaoItem.ItemLists.Add(itempList);
                return this;
            }

            public KakaoBizMsgItemBuilder WithItemLists(IEnumerable<KakaoAlimTalkItemListElement> itempLists)
            {
                this._kakaoItem.ItemLists ??= [];
                this._kakaoItem.ItemLists.AddRange(itempLists);
                return this;
            }

            public KakaoBizMsgItemBuilder WithSummary(KakaoBizMsgSummary summary)
            {
                this._kakaoItem.ItepSummary = summary;
                return this;
            }

        }

    }

    public class KakaoFriendTalkItem
    {
        [JsonProperty(PropertyName = "list", NullValueHandling = NullValueHandling.Ignore)]
        public List<KakaoFriendTalkItemListElement>? ItemLists;

        private KakaoFriendTalkItem()
        {
            this.ItemLists = null;

        }

        public static KakaoFriendTalkItemBuilder Builder()
        {
            return new KakaoFriendTalkItemBuilder();
        }

        public class KakaoFriendTalkItemBuilder
        {
            private readonly KakaoFriendTalkItem _kakaoItem;

            public KakaoFriendTalkItemBuilder()
            {
                this._kakaoItem = new KakaoFriendTalkItem();
            }

            public KakaoFriendTalkItemBuilder WithItemList(KakaoFriendTalkItemListElement itempList)
            {
                this._kakaoItem.ItemLists ??= [];
                this._kakaoItem.ItemLists.Add(itempList);
                return this;
            }

            public KakaoFriendTalkItemBuilder WithItemLists(IEnumerable<KakaoFriendTalkItemListElement> itempLists)
            {
                this._kakaoItem.ItemLists ??= [];
                this._kakaoItem.ItemLists.AddRange(itempLists);
                return this;
            }

            public KakaoFriendTalkItem Build()
            {
                return this._kakaoItem;
            }
        }

    }

    public class KakaoBizMsgItemHighlight
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }


        private KakaoBizMsgItemHighlight()
        {
            Title = "";
            Description = "";
        }

        public static KakaoBizMsgItemHighlightBuilder Builder()
        {
            return new KakaoBizMsgItemHighlightBuilder();
        }

        public class KakaoBizMsgItemHighlightBuilder
        {
            private readonly KakaoBizMsgItemHighlight _itemHighlight;

            public KakaoBizMsgItemHighlightBuilder()
            {
                this._itemHighlight = new KakaoBizMsgItemHighlight();
            }

            public KakaoBizMsgItemHighlightBuilder WithTitle(string title)
            {
                this._itemHighlight.Title = title;
                return this;
            }

            public KakaoBizMsgItemHighlightBuilder WithDescription(string description)
            {
                this._itemHighlight.Description = description;
                return this;
            }


            public KakaoBizMsgItemHighlight Build()
            {
                return _itemHighlight;
            }

        }

    }

    public class KakaoFriendTalkCoupon
    {
        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }


        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }


        [JsonProperty(PropertyName = "urlPc", NullValueHandling = NullValueHandling.Ignore)]
        public string? UrlPc { get; set; }


        [JsonProperty(PropertyName = "urlMobile", NullValueHandling = NullValueHandling.Ignore)]
        public string? UrlMobile { get; set; }


        [JsonProperty(PropertyName = "schemeAndroid", NullValueHandling = NullValueHandling.Ignore)]
        public string? SchemeAndroid { get; set; }


        [JsonProperty(PropertyName = "schemeIos", NullValueHandling = NullValueHandling.Ignore)]
        public string? SchemeIos { get; set; }

        private KakaoFriendTalkCoupon()
        {
            this.Title = "";
            this.Description = "";

            this.UrlPc = null;
            this.UrlMobile = null;
            this.SchemeAndroid = null;
            this.SchemeIos = null;
        }

        public static KakaoBizMsgCouponBuilder Builder()
        {
            return new KakaoBizMsgCouponBuilder();
        }

        public class KakaoBizMsgCouponBuilder
        {
            private readonly KakaoFriendTalkCoupon _kakaoCoupon;

            public KakaoBizMsgCouponBuilder()
            {
                this._kakaoCoupon = new KakaoFriendTalkCoupon();
            }

            public KakaoBizMsgCouponBuilder WithTitle(string title)
            {
                this._kakaoCoupon.Title = title;
                return this;
            }

            public KakaoBizMsgCouponBuilder WithDescription(string description)
            {
                this._kakaoCoupon.Description = description;
                return this;
            }


            public KakaoBizMsgCouponBuilder WithUrlPc(string urlPc)
            {
                this._kakaoCoupon.UrlPc = urlPc;
                return this;
            }


            public KakaoBizMsgCouponBuilder WithUrlMobile(string urlMobile)
            {
                this._kakaoCoupon.UrlMobile = urlMobile;
                return this;
            }

            public KakaoBizMsgCouponBuilder WithSchemeAndroid(string schemeAndroid)
            {
                this._kakaoCoupon.SchemeAndroid = schemeAndroid;
                return this;
            }

            public KakaoBizMsgCouponBuilder WithSchemeIos(string schemeIos)
            {
                this._kakaoCoupon.SchemeIos = schemeIos;
                return this;
            }

            public KakaoFriendTalkCoupon Builder()
            {
                return _kakaoCoupon;
            }

        }

    }

    public class KakaoFriendTalkCommerce
    {
        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public string? Title { get; set; }


        [JsonProperty(PropertyName = "regularPrice", NullValueHandling = NullValueHandling.Ignore)]
        public int RegularPrice { get; set; }


        [JsonProperty(PropertyName = "discountPrice", NullValueHandling = NullValueHandling.Ignore)]
        public int? DiscountPrice { get; set; }


        [JsonProperty(PropertyName = "discountRate", NullValueHandling = NullValueHandling.Ignore)]
        public int? DiscountRate { get; set; }


        [JsonProperty(PropertyName = "discountFixed", NullValueHandling = NullValueHandling.Ignore)]
        public int? DiscountFixed { get; set; }


        private KakaoFriendTalkCommerce()
        {
            this.Title = null;
            this.RegularPrice = 0;
            this.DiscountPrice = 0;
            this.DiscountRate = 0;
            this.DiscountFixed = 0;
        }

        public static KakaoBizMsgCommerceBuilder Builder()
        {
            return new KakaoBizMsgCommerceBuilder();
        }

        public class KakaoBizMsgCommerceBuilder
        {
            private readonly KakaoFriendTalkCommerce _kakaoCommerce;

            public KakaoBizMsgCommerceBuilder()
            {
                this._kakaoCommerce = new KakaoFriendTalkCommerce();
            }

            public KakaoBizMsgCommerceBuilder WithTitle(string title)
            {
                this._kakaoCommerce.Title = title;
                return this;
            }

            public KakaoBizMsgCommerceBuilder WithRegularPrice(int regularPrice)
            {
                this._kakaoCommerce.RegularPrice = regularPrice;
                return this;
            }


            public KakaoBizMsgCommerceBuilder WithDiscountPrice(int discountPrice)
            {
                this._kakaoCommerce.DiscountPrice = discountPrice;
                return this;
            }


            public KakaoBizMsgCommerceBuilder WithDiscountRate(int discountRate)
            {
                this._kakaoCommerce.DiscountRate = discountRate;
                return this;
            }

            public KakaoBizMsgCommerceBuilder WithDiscountFixed(int discountFixed)
            {
                this._kakaoCommerce.DiscountFixed = discountFixed;
                return this;
            }

            public KakaoFriendTalkCommerce Build()
            {
                return _kakaoCommerce;
            }

        }

    }

    public class KakaoFriendTalkVideo
    {
        [JsonProperty(PropertyName = "videoUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string VideoUrl { get; set; }


        [JsonProperty(PropertyName = "thumbnailUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string? ThumbnailUrl { get; set; }

        private KakaoFriendTalkVideo()
        {
            this.VideoUrl = "";
            this.ThumbnailUrl = null;
        }

        public static KakaoBizMsgVideoBuilder Builder()
        {
            return new KakaoBizMsgVideoBuilder();
        }

        public class KakaoBizMsgVideoBuilder
        {
            private readonly KakaoFriendTalkVideo _kakaoVideo;

            public KakaoBizMsgVideoBuilder()
            {
                this._kakaoVideo = new KakaoFriendTalkVideo();
            }

            public KakaoBizMsgVideoBuilder WithVideoUrl(string videoUrl)
            {
                this._kakaoVideo.VideoUrl = videoUrl;
                return this;
            }

            public KakaoBizMsgVideoBuilder WithThumbnailUrl(string thumbnailUrl)
            {
                this._kakaoVideo.ThumbnailUrl = thumbnailUrl;
                return this;
            }

            public KakaoFriendTalkVideo Build()
            {
                return _kakaoVideo;
            }

        }

    }

    public class KakaoFriendTalkCarousel
    {
        [JsonProperty(PropertyName = "head", NullValueHandling = NullValueHandling.Ignore)]
        public KakaoFriendTalkCarouselHead? Carouselhead;

        [JsonProperty(PropertyName = "list", NullValueHandling = NullValueHandling.Ignore)]
        public List<KakaoFriendTalkCarouselList>? CarouselList;

        [JsonProperty(PropertyName = "tail", NullValueHandling = NullValueHandling.Ignore)]
        public KakaoFriendTalkCarouselTail? Carouseltail;

        private KakaoFriendTalkCarousel()
        {
            this.Carouselhead = null;
            this.CarouselList = null;
            this.Carouseltail = null;

        }
        public static KakaoFriendCarouselBuilder Builder()
        {
            return new KakaoFriendCarouselBuilder();
        }

        public class KakaoFriendCarouselBuilder
        {
            private readonly KakaoFriendTalkCarousel _friendCarousel;

            public KakaoFriendCarouselBuilder()
            {
                this._friendCarousel = new KakaoFriendTalkCarousel();

            }

            public KakaoFriendCarouselBuilder WithCarouselhead(KakaoFriendTalkCarouselHead head)
            {
                _friendCarousel.Carouselhead = head;
                return this;
            }

            public KakaoFriendCarouselBuilder WithCarouselList(KakaoFriendTalkCarouselList list)
            {
                this._friendCarousel.CarouselList ??= [];
                this._friendCarousel.CarouselList.Add(list);
                return this;
            }
            public KakaoFriendCarouselBuilder WithCarouselLists(IEnumerable<KakaoFriendTalkCarouselList> lists)
            {
                this._friendCarousel.CarouselList ??= [];
                this._friendCarousel.CarouselList.AddRange(lists);
                return this;
            }

            public KakaoFriendCarouselBuilder WithCarouseltail(KakaoFriendTalkCarouselTail tail)
            {
                _friendCarousel.Carouseltail = tail;

                return this;
            }

            public KakaoFriendTalkCarousel Build()
            {
                return _friendCarousel;
            }

        }
    }

    public class KakaoFriendTalkCarouselHead
    {
        [JsonProperty(PropertyName = "header", NullValueHandling = NullValueHandling.Ignore)]
        public string Header { get; set; }


        [JsonProperty(PropertyName = "content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }

        [JsonProperty(PropertyName = "imageUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageUrl { get; set; }


        [JsonProperty(PropertyName = "urlMobile", NullValueHandling = NullValueHandling.Ignore)]
        public string? UrlMobile { get; set; }


        [JsonProperty(PropertyName = "urlPc", NullValueHandling = NullValueHandling.Ignore)]
        public string? UrlPc { get; set; }


        [JsonProperty(PropertyName = "schemeAndroid", NullValueHandling = NullValueHandling.Ignore)]
        public string? SchemeAndroid { get; set; }


        [JsonProperty(PropertyName = "schemeIos", NullValueHandling = NullValueHandling.Ignore)]
        public string? SchemeIos { get; set; }


        private KakaoFriendTalkCarouselHead()
        {
            this.Header = "";
            this.Content = "";
            this.ImageUrl = "";
            this.UrlMobile = null;
            this.UrlPc = null;
            this.SchemeAndroid = null;
            this.SchemeIos = null;
        }

        public static KakaoBizMsgCarouselHeadBuilder Builder()
        {
            return new KakaoBizMsgCarouselHeadBuilder();
        }

        public class KakaoBizMsgCarouselHeadBuilder
        {
            private readonly KakaoFriendTalkCarouselHead _kakaoCarouselHead;

            public KakaoBizMsgCarouselHeadBuilder()
            {
                this._kakaoCarouselHead = new KakaoFriendTalkCarouselHead();
            }

            public KakaoBizMsgCarouselHeadBuilder WithHeader(string header)
            {
                this._kakaoCarouselHead.Header = header;
                return this;
            }

            public KakaoBizMsgCarouselHeadBuilder WithContent(string content)
            {
                this._kakaoCarouselHead.Content = content;
                return this;
            }

            public KakaoBizMsgCarouselHeadBuilder WithImageUrl(string imageUrl)
            {
                this._kakaoCarouselHead.ImageUrl = imageUrl;
                return this;
            }

            public KakaoBizMsgCarouselHeadBuilder WithUrlMobile(string urlMobile)
            {
                this._kakaoCarouselHead.UrlMobile = urlMobile;
                return this;
            }

            public KakaoBizMsgCarouselHeadBuilder WithUrlPc(string urlPc)
            {
                this._kakaoCarouselHead.UrlPc = urlPc;
                return this;
            }

            public KakaoBizMsgCarouselHeadBuilder WithSchemeAndroid(string schemeAndroid)
            {
                this._kakaoCarouselHead.SchemeAndroid = schemeAndroid;
                return this;
            }

            public KakaoBizMsgCarouselHeadBuilder WithSchemeIos(string schemeIos)
            {
                this._kakaoCarouselHead.SchemeIos = schemeIos;
                return this;
            }

            public KakaoFriendTalkCarouselHead Builder()
            {
                return _kakaoCarouselHead;
            }

        }

    }

    public class KakaoFriendTalkCarouselListAttachment
    {

        [JsonProperty(PropertyName = "button", NullValueHandling = NullValueHandling.Ignore)]
        public List<KakaoFriendTalkButton>? Button { get; set; }

        [JsonProperty(PropertyName = "image", NullValueHandling = NullValueHandling.Ignore)]
        public KakaoFriendTalkImage? Image { get; set; }

        [JsonProperty(PropertyName = "coupon", NullValueHandling = NullValueHandling.Ignore)]
        public KakaoFriendTalkCoupon? Coupon { get; set; }

        [JsonProperty(PropertyName = "commerce", NullValueHandling = NullValueHandling.Ignore)]
        public KakaoFriendTalkCommerce? Commerce { get; set; }

        private KakaoFriendTalkCarouselListAttachment()
        {
            this.Button = null;
            this.Image = null;
            this.Coupon = null;
            this.Commerce = null;
        }

        public static KakaoFriendTalkCarouselListAttachmentBuilder Builder()
        {
            return new KakaoFriendTalkCarouselListAttachmentBuilder();
        }

        public class KakaoFriendTalkCarouselListAttachmentBuilder
        {
            private readonly KakaoFriendTalkCarouselListAttachment _kakaoCarouselListAttachment;

            public KakaoFriendTalkCarouselListAttachmentBuilder()
            {
                this._kakaoCarouselListAttachment = new KakaoFriendTalkCarouselListAttachment();
            }

            public KakaoFriendTalkCarouselListAttachmentBuilder AddButton(KakaoFriendTalkButton button)
            {
                this._kakaoCarouselListAttachment.Button ??= [];
                this._kakaoCarouselListAttachment.Button.Add(button);
                return this;
            }

            public KakaoFriendTalkCarouselListAttachmentBuilder WithImage(KakaoFriendTalkImage image)
            {
                this._kakaoCarouselListAttachment.Image = image;
                return this;
            }

            public KakaoFriendTalkCarouselListAttachmentBuilder WithCoupon(KakaoFriendTalkCoupon coupon)
            {
                this._kakaoCarouselListAttachment.Coupon = coupon;
                return this;
            }

            public KakaoFriendTalkCarouselListAttachmentBuilder WithCommerce(KakaoFriendTalkCommerce commerce)
            {
                this._kakaoCarouselListAttachment.Commerce = commerce;
                return this;
            }

            public KakaoFriendTalkCarouselListAttachment Build()
            {
                return _kakaoCarouselListAttachment;
            }
        }

    }

    public class KakaoFriendTalkCarouselList
    {
        [JsonProperty(PropertyName = "header", NullValueHandling = NullValueHandling.Ignore)]
        public string Header { get; set; }


        [JsonProperty(PropertyName = "message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "additionalContent", NullValueHandling = NullValueHandling.Ignore)]
        public string? AdditionalContent { get; set; }


        [JsonProperty(PropertyName = "attachment", NullValueHandling = NullValueHandling.Ignore)]
        public KakaoFriendTalkCarouselListAttachment? Attachment { get; set; }



        private KakaoFriendTalkCarouselList()
        {
            this.Header = "";
            this.Message = "";
            this.AdditionalContent = null;
            this.Attachment = null;
        }

        public static KakaoBizMsgCarouselListBuilder Builder()
        {
            return new KakaoBizMsgCarouselListBuilder();
        }

        public class KakaoBizMsgCarouselListBuilder
        {
            private readonly KakaoFriendTalkCarouselList _kakaoCarouselList;

            public KakaoBizMsgCarouselListBuilder()
            {
                this._kakaoCarouselList = new KakaoFriendTalkCarouselList();
            }

            public KakaoBizMsgCarouselListBuilder WithHeader(string header)
            {
                this._kakaoCarouselList.Header = header;
                return this;
            }

            public KakaoBizMsgCarouselListBuilder WithMessage(string message)
            {
                this._kakaoCarouselList.Message = message;
                return this;
            }

            public KakaoBizMsgCarouselListBuilder WithAdditionalContent(string additionalContent)
            {
                this._kakaoCarouselList.AdditionalContent = additionalContent;
                return this;
            }

            public KakaoBizMsgCarouselListBuilder WithAttachment(KakaoFriendTalkCarouselListAttachment attachment)
            {
                this._kakaoCarouselList.Attachment = attachment;
                return this;
            }


            public KakaoFriendTalkCarouselList Build()
            {
                return _kakaoCarouselList;
            }

        }

    }

    public class KakaoFriendTalkCarouselTail
    {

        [JsonProperty(PropertyName = "urlPc", NullValueHandling = NullValueHandling.Ignore)]
        public string? UrlPc { get; set; }

        [JsonProperty(PropertyName = "urlMobile", NullValueHandling = NullValueHandling.Ignore)]
        public string? UrlMobile { get; set; }

        [JsonProperty(PropertyName = "schemeIos", NullValueHandling = NullValueHandling.Ignore)]
        public string? SchemeIos { get; set; }


        [JsonProperty(PropertyName = "schemeAndroid", NullValueHandling = NullValueHandling.Ignore)]
        public string? SchemeAndroid { get; set; }


        private KakaoFriendTalkCarouselTail()
        {
            this.SchemeAndroid = "";
            this.SchemeIos = null;
            this.UrlMobile = null;
            this.UrlPc = null;
        }

        public static KakaoBizMsgCarouselTailBuilder Builder()
        {
            return new KakaoBizMsgCarouselTailBuilder();
        }

        public class KakaoBizMsgCarouselTailBuilder
        {
            private readonly KakaoFriendTalkCarouselTail _kakaoCarouselTail;

            public KakaoBizMsgCarouselTailBuilder()
            {
                this._kakaoCarouselTail = new KakaoFriendTalkCarouselTail();
            }


            public KakaoBizMsgCarouselTailBuilder WithSchemeAndroid(string schemeAndroid)
            {
                this._kakaoCarouselTail.SchemeAndroid = schemeAndroid;
                return this;
            }

            public KakaoBizMsgCarouselTailBuilder WithSchemeIos(string schemeIos)
            {
                this._kakaoCarouselTail.SchemeIos = schemeIos;
                return this;
            }

            public KakaoBizMsgCarouselTailBuilder WithUrlMobile(string urlMobile)
            {
                this._kakaoCarouselTail.UrlMobile = urlMobile;
                return this;
            }

            public KakaoBizMsgCarouselTailBuilder WithUrlPc(string urlPc)
            {
                this._kakaoCarouselTail.UrlPc = urlPc;
                return this;
            }

            public KakaoFriendTalkCarouselTail Build()
            {
                return _kakaoCarouselTail;
            }

        }

    }

    public class AlimTalkQuickReply
    {
        [JsonProperty("type")]
        public string QuickReplyType { get; set; }

        [JsonProperty("name")]
        public string QuickReplyName { get; set; }

        [JsonProperty("urlPc", NullValueHandling = NullValueHandling.Ignore)]
        public string? UrlPc { get; set; }

        [JsonProperty("urlMobile", NullValueHandling = NullValueHandling.Ignore)]
        public string? UrlMobile { get; set; }

        [JsonProperty("schemeIos", NullValueHandling = NullValueHandling.Ignore)]
        public string? SchemeIos { get; set; }

        [JsonProperty("schemeAndroid", NullValueHandling = NullValueHandling.Ignore)]
        public string? SchemeAndroid { get; set; }

        [JsonProperty("chatExtra", NullValueHandling = NullValueHandling.Ignore)]
        public string? ChatExtra { get; set; }

        [JsonProperty("chatEvent", NullValueHandling = NullValueHandling.Ignore)]
        public string? ChatEvent { get; set; }

        [JsonProperty("bizFormId", NullValueHandling = NullValueHandling.Ignore)]
        public string? BizFormId { get; set; }

        private AlimTalkQuickReply()
        {
            this.QuickReplyType = "";
            this.QuickReplyName = "";


            this.ChatEvent = null;
            this.BizFormId = null;
            this.UrlPc = null;
            this.UrlMobile = null;
            this.ChatExtra = null;
            this.SchemeAndroid = null;
            this.SchemeIos = null;

        }

        public QuickReplyBuilder Builder()
        {
            return new QuickReplyBuilder();
        }

        public class QuickReplyBuilder
        {
            private AlimTalkQuickReply _quickReply;

            public QuickReplyBuilder()
            {
                this._quickReply = new AlimTalkQuickReply();
            }

            public QuickReplyBuilder WithType(string type)
            {
                this._quickReply.QuickReplyType = type;
                return this;
            }
            public QuickReplyBuilder WithName(string name)
            {
                this._quickReply.QuickReplyName = name;
                return this;
            }

            public QuickReplyBuilder WithUrlPc(string urlPc)
            {
                this._quickReply.UrlPc = urlPc;
                return this;
            }

            public QuickReplyBuilder WithUrlMobile(string urlMobile)
            {
                this._quickReply.UrlMobile = urlMobile;
                return this;
            }

            public QuickReplyBuilder WithSchemeIos(string schemeIos)
            {
                this._quickReply.SchemeIos = schemeIos;
                return this;
            }

            public QuickReplyBuilder WithSchemeAndroid(string schemeAndroid)
            {
                this._quickReply.SchemeAndroid = schemeAndroid;
                return this;
            }

            public QuickReplyBuilder WithChatExtra(string chatExtra)
            {
                this._quickReply.ChatExtra = chatExtra;
                return this;
            }

            public QuickReplyBuilder WithChatEvent(string chatEvent)
            {
                this._quickReply.ChatEvent = chatEvent;
                return this;
            }

            public QuickReplyBuilder WithBizFormId(string bizFormId)
            {
                this._quickReply.BizFormId = bizFormId;
                return this;
            }

            public AlimTalkQuickReply Build()
            {
                return _quickReply;
            }
        }

    }

    public class KakaoFriendTalkImage
    {
        [JsonProperty("imgUrl")]
        public string ImgUrl;
        [JsonProperty("imgLink", NullValueHandling = NullValueHandling.Ignore)]
        public string? ImgLink;
        private KakaoFriendTalkImage()
        {
            this.ImgUrl = "";
            this.ImgLink = null;
        }

        public static KakaoBizMsgImageBuilder Builder()
        {
            return new KakaoBizMsgImageBuilder();
        }

        public class KakaoBizMsgImageBuilder
        {
            private readonly KakaoFriendTalkImage _image;

            public KakaoBizMsgImageBuilder()
            {
                this._image = new KakaoFriendTalkImage();
            }

            public KakaoBizMsgImageBuilder WithImgUrl(string imgUrl)
            {
                this._image.ImgUrl = imgUrl;
                return this;
            }
            public KakaoBizMsgImageBuilder WithImgLink(string imgLink)
            {
                this._image.ImgLink = imgLink;
                return this;
            }

            public KakaoFriendTalkImage Build()
            {
                return this._image;
            }
        }
    }

    public class KakaoAlimTalkItemListElement
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        private KakaoAlimTalkItemListElement()
        {
            this.Title = "";
            this.Description = "";
        }

        public static KakaoBizMsgItemListElementBuilder Builder()
        {
            return new KakaoBizMsgItemListElementBuilder();
        }

        public class KakaoBizMsgItemListElementBuilder
        {
            private readonly KakaoAlimTalkItemListElement _element;

            public KakaoBizMsgItemListElementBuilder()
            {
                this._element = new KakaoAlimTalkItemListElement();
            }

            public KakaoBizMsgItemListElementBuilder WithTitle(string title)
            {
                this._element.Title = title;
                return this;
            }

            public KakaoBizMsgItemListElementBuilder WithDescription(string description)
            {
                this._element.Description = description;
                return this;
            }

            public KakaoAlimTalkItemListElement Build()
            {
                return _element;
            }

        }

    }

    public class KakaoFriendTalkItemListElement
    {
        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("imgUrl")]
        public string? ImgUrl { get; set; }

        [JsonProperty("schemeAndroid")]
        public string? SchemeAndroid { get; set; }

        [JsonProperty("schemeIos")]
        public string? SchemeIos { get; set; }

        [JsonProperty("urlMobile")]
        public string? UrlMobile { get; set; }

        [JsonProperty("urlPc")]
        public string? UrlPc { get; set; }


        private KakaoFriendTalkItemListElement()
        {
            this.Title = "";
            this.ImgUrl = "";
            this.SchemeAndroid = "";
            this.SchemeIos = "";
            this.UrlMobile = "";
            this.UrlPc = "";
        }

        public static KakaoFriendTalkItemListElementBuilder Builder()
        {
            return new KakaoFriendTalkItemListElementBuilder();
        }

        public class KakaoFriendTalkItemListElementBuilder
        {
            private readonly KakaoFriendTalkItemListElement _element;

            public KakaoFriendTalkItemListElementBuilder()
            {
                this._element = new KakaoFriendTalkItemListElement();
            }

            public KakaoFriendTalkItemListElementBuilder WithTitle(string title)
            {
                this._element.Title = title;
                return this;
            }

            public KakaoFriendTalkItemListElementBuilder WithImgUrl(string imgUrl)
            {
                this._element.ImgUrl = imgUrl;
                return this;
            }

            public KakaoFriendTalkItemListElementBuilder WithSchemeAndroid(string schemeAndroid)
            {
                this._element.SchemeAndroid = schemeAndroid;
                return this;
            }

            public KakaoFriendTalkItemListElementBuilder WithSchemeIos(string schemeIos)
            {
                this._element.SchemeIos = schemeIos;
                return this;
            }

            public KakaoFriendTalkItemListElementBuilder WithUrlMobile(string urlMobile)
            {
                this._element.UrlMobile = urlMobile;
                return this;
            }

            public KakaoFriendTalkItemListElementBuilder WithUrlPc(string urlPc)
            {
                this._element.UrlPc = urlPc;
                return this;
            }


            public KakaoFriendTalkItemListElement Build()
            {
                return _element;
            }

        }

    }

    public class KakaoBizMsgSummary
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        private KakaoBizMsgSummary()
        {
            this.Title = "";
            this.Description = "";
        }

        public static KakaoBizMsgSummaryBuilder Builder()
        {
            return new KakaoBizMsgSummaryBuilder();
        }

        public class KakaoBizMsgSummaryBuilder
        {
            private readonly KakaoBizMsgSummary _summary;

            public KakaoBizMsgSummaryBuilder()
            {
                this._summary = new KakaoBizMsgSummary();
            }

            public KakaoBizMsgSummaryBuilder WithTitle(string title)
            {
                this._summary.Title = title;
                return this;
            }

            public KakaoBizMsgSummaryBuilder WithDescription(string description)
            {
                this._summary.Description = description;
                return this;
            }

            public KakaoBizMsgSummary Build()
            {
                return _summary;
            }

        }

    }

}
