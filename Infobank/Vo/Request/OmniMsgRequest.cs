using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Infobank.Vo.Request
{
    public class OmniMsgRequest : MessageRequest
    {
        [JsonProperty("destinations", NullValueHandling = NullValueHandling.Ignore)]
        public List<OmniDestinations> Destinations { get; set; }

        [JsonIgnore]
        public List<OmniMessageFlowElement>? MessageFlowList { get; set; }

        [JsonProperty("messageFlow", NullValueHandling = NullValueHandling.Ignore)]
        public List<OmniMessageFlowElementObject>? MessageFlowObjectList { get; set; }

        [JsonProperty("messageForm", NullValueHandling = NullValueHandling.Ignore)]
        public string? MessageForm { get; set; }

        [JsonProperty("paymentCode", NullValueHandling = NullValueHandling.Ignore)]
        public string? PaymentCode { get; set; }

        [JsonProperty(PropertyName = "ref", NullValueHandling = NullValueHandling.Ignore)]
        public string? Ref { get; set; }


        private OmniMsgRequest()
        {
            this.Destinations = new List<OmniDestinations>();
            this.MessageFlowList = null;
            this.MessageForm = null;
            this.PaymentCode = null;
            this.Ref = null;
            this.MessageFlowObjectList = null;
        }

        public static OmniMsgRequestBuilder Builder()
        {
            return new OmniMsgRequestBuilder();
        }

        public class OmniMsgRequestBuilder
        {
            private readonly OmniMsgRequest omniMsgRequest;

            public OmniMsgRequestBuilder()
            {
                omniMsgRequest = new OmniMsgRequest();
            }

            public OmniMsgRequestBuilder WithDestination(string recipientNumber)
            {
                omniMsgRequest.Destinations.Add(OmniDestinations.Builder().WithTo(recipientNumber).Build());
                return this;
            }

            public OmniMsgRequestBuilder WithDestination(string recipientNumber, Dictionary<string, string> replaceWords)
            {
                omniMsgRequest.Destinations.Add(OmniDestinations.Builder().WithTo(recipientNumber).WithReplaceWords(replaceWords).Build());
                return this;
            }

            public OmniMsgRequestBuilder WithDestination(string recipientNumber, Action<Dictionary<string, string>> replaceWordAction)
            {
                var replaceWords = new Dictionary<string, string>();
                replaceWordAction(replaceWords);
                omniMsgRequest.Destinations.Add(OmniDestinations.Builder().WithTo(recipientNumber).WithReplaceWords(replaceWords).Build());
                return this;
            }

            public OmniMsgRequestBuilder WithSingleOmniMessageFlow(OmniMessageFlowElement element)
            {
                omniMsgRequest.MessageFlowList ??= [];
                omniMsgRequest.MessageFlowList.Add(element);
                return this;
            }

            public OmniMsgRequestBuilder WithOmniMessageFlow(IEnumerable<OmniMessageFlowElement> elements)
            {
                omniMsgRequest.MessageFlowList ??= [];
                omniMsgRequest.MessageFlowList.AddRange(elements);
                return this;
            }

            public OmniMsgRequestBuilder WithMessageForm(string messageFormId)
            {
                omniMsgRequest.MessageForm = messageFormId;
                return this;
            }

            public OmniMsgRequestBuilder WithPaymentCode(string paymentCode)
            {
                omniMsgRequest.PaymentCode = paymentCode;
                return this;
            }


            public OmniMsgRequestBuilder WithRef(string Ref)
            {
                omniMsgRequest.Ref = Ref;
                return this;
            }

            public OmniMsgRequest Build()
            {

                if (omniMsgRequest.MessageFlowList is not null)
                {
                    foreach (OmniMessageFlowElement element in omniMsgRequest.MessageFlowList)
                    {
                        omniMsgRequest.MessageFlowObjectList ??= new List<OmniMessageFlowElementObject>();

                        if (element.GetType() == typeof(OmniMessageFlowElementSms))
                        {
                            omniMsgRequest.MessageFlowObjectList.Add(new OmniMessageFlowElementObjectSms((OmniMessageFlowElementSms)element));
                        }
                        else if (element.GetType() == typeof(OmniMessageFlowElementMms))
                        {
                            omniMsgRequest.MessageFlowObjectList.Add(new OmniMessageFlowElementObjectMms((OmniMessageFlowElementMms)element));

                        }
                        else if (element.GetType() == typeof(OmniMessageFlowElementRcs))
                        {
                            omniMsgRequest.MessageFlowObjectList.Add(new OmniMessageFlowElementObjectRcs((OmniMessageFlowElementRcs)element));
                        }
                        else if (element.GetType() == typeof(OmniMessageFlowElementAlimTalk))
                        {
                            omniMsgRequest.MessageFlowObjectList.Add(new OmniMessageFlowElementObjectAlimTalk((OmniMessageFlowElementAlimTalk)element));
                        }
                        else if (element.GetType() == typeof(OmniMessageFlowElementFriendTalk))
                        {
                            omniMsgRequest.MessageFlowObjectList.Add(new OmniMessageFlowElementObjectFriendTalk((OmniMessageFlowElementFriendTalk)element));
                        }
                        else if (element.GetType() == typeof(OmniMessageFlowElementBrandMessage))
                        {
                            omniMsgRequest.MessageFlowObjectList.Add(new OmniMessageFlowElementObjectBrandMessage((OmniMessageFlowElementBrandMessage)element));
                        }

                    }
                }

                return this.omniMsgRequest;
            }
        }

        public abstract class OmniMessageFlowElementObject { }
        public class OmniMessageFlowElementObjectSms : OmniMessageFlowElementObject
        {
            [JsonProperty("sms")]
            public OmniMessageFlowElementSms SmsData { get; set; }
            public OmniMessageFlowElementObjectSms(OmniMessageFlowElementSms smsData)
            {
                this.SmsData = smsData;
            }
        }
        public class OmniMessageFlowElementObjectMms : OmniMessageFlowElementObject
        {
            [JsonProperty("mms")]
            public OmniMessageFlowElementMms MmsData { get; set; }
            public OmniMessageFlowElementObjectMms(OmniMessageFlowElementMms mmsData)
            {
                this.MmsData = mmsData;
            }
        }
        public class OmniMessageFlowElementObjectRcs : OmniMessageFlowElementObject
        {
            [JsonProperty("rcs")]
            public OmniMessageFlowElementRcs RcsData { get; set; }
            public OmniMessageFlowElementObjectRcs(OmniMessageFlowElementRcs rcsData)
            {
                this.RcsData = rcsData;
            }
        }

        public class OmniMessageFlowElementObjectAlimTalk : OmniMessageFlowElementObject
        {
            [JsonProperty("alimtalk")]
            public OmniMessageFlowElementAlimTalk AlimTalkData { get; set; }
            public OmniMessageFlowElementObjectAlimTalk(OmniMessageFlowElementAlimTalk alimTalkData)
            {
                this.AlimTalkData = alimTalkData;
            }
        }

        public class OmniMessageFlowElementObjectFriendTalk : OmniMessageFlowElementObject
        {
            [JsonProperty("friendtalk")]
            public OmniMessageFlowElementFriendTalk FriendTalk { get; set; }
            public OmniMessageFlowElementObjectFriendTalk(OmniMessageFlowElementFriendTalk frienTalk)
            {
                this.FriendTalk = frienTalk;
            }
        }

        public class OmniMessageFlowElementObjectBrandMessage : OmniMessageFlowElementObject
        {
            [JsonProperty("brandmessage")]
            public OmniMessageFlowElementBrandMessage BrandMessage { get; set; }
            public OmniMessageFlowElementObjectBrandMessage(OmniMessageFlowElementBrandMessage brandMessage)
            {
                this.BrandMessage = brandMessage;
            }
        }

    }
}