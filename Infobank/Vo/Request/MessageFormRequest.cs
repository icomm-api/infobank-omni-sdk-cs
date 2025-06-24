using Newtonsoft.Json;

namespace Infobank.Vo.Request
{

    public class MessageFormRequest : MessageRequest
    {
        [JsonIgnore]
        public List<OmniMessageFlowElement>? MessageFormInfo { get; set; }

        [JsonProperty("messageForm", NullValueHandling = NullValueHandling.Ignore)]
        public List<MessageFormElementObject>? MessageFormInfoObject { get; set; }

        protected MessageFormRequest()
        {
            this.MessageFormInfo = null;
            this.MessageFormInfoObject = null;
        }
    }


    public abstract class MessageFormElementObject { }
    public class MessageFormElementObjectSms : MessageFormElementObject
    {
        [JsonProperty("sms")]
        public OmniMessageFlowElementSms SmsData { get; set; }
        public MessageFormElementObjectSms(OmniMessageFlowElementSms smsData)
        {
            this.SmsData = smsData;
        }
    }
    public class MessageFormElementObjectMms : MessageFormElementObject
    {
        [JsonProperty("mms")]
        public OmniMessageFlowElementMms MmsData { get; set; }
        public MessageFormElementObjectMms(OmniMessageFlowElementMms mmsData)
        {
            this.MmsData = mmsData;
        }
    }
    public class MessageFormElementObjectRcs : MessageFormElementObject
    {
        [JsonProperty("rcs")]
        public OmniMessageFlowElementRcs RcsData { get; set; }
        public MessageFormElementObjectRcs(OmniMessageFlowElementRcs rcsData)
        {
            this.RcsData = rcsData;
        }
    }

    public class MessageFormElementObjectAlimTalk : MessageFormElementObject
    {
        [JsonProperty("alimtalk")]
        public OmniMessageFlowElementAlimTalk AlimTalkData { get; set; }
        public MessageFormElementObjectAlimTalk(OmniMessageFlowElementAlimTalk alimTalkData)
        {
            this.AlimTalkData = alimTalkData;
        }
    }

    public class MessageFormElementObjectFriendTalk : MessageFormElementObject
    {
        [JsonProperty("friendtalk")]
        public OmniMessageFlowElementFriendTalk FriendTalk { get; set; }
        public MessageFormElementObjectFriendTalk(OmniMessageFlowElementFriendTalk frienTalk)
        {
            this.FriendTalk = frienTalk;
        }
    }

    public class MessageFormElementObjectBrandMessage : MessageFormElementObject
    {
        [JsonProperty("brandmessage")]
        public OmniMessageFlowElementBrandMessage BrandMessage { get; set; }
        public MessageFormElementObjectBrandMessage(OmniMessageFlowElementBrandMessage brandMessage)
        {
            this.BrandMessage = brandMessage;
        }

    }
    public class MessageFormRegistRequest : MessageFormRequest
    {
        public static MessageFormRegistRequestBuilder Builder()
        {
            return new MessageFormRegistRequestBuilder();
        }

        public class MessageFormRegistRequestBuilder
        {
            private readonly MessageFormRegistRequest messageForm;

            public MessageFormRegistRequestBuilder()
            {
                messageForm = new MessageFormRegistRequest();
            }


            public MessageFormRegistRequestBuilder WithSingleFormMessageFlow(OmniMessageFlowElement element)
            {
                messageForm.MessageFormInfo ??= new List<OmniMessageFlowElement>();
                messageForm.MessageFormInfo.Add(element);
                return this;
            }

            public MessageFormRegistRequestBuilder WitFormMessageFlow(IEnumerable<OmniMessageFlowElement> elements)
            {
                messageForm.MessageFormInfo ??= new List<OmniMessageFlowElement>();
                messageForm.MessageFormInfo.AddRange(elements);
                return this;
            }

            public MessageFormRequest Build()
            {

                if (messageForm.MessageFormInfo is not null)
                {
                    foreach (OmniMessageFlowElement element in messageForm.MessageFormInfo)
                    {
                        messageForm.MessageFormInfoObject ??= new List<MessageFormElementObject>();

                        if (element.GetType() == typeof(OmniMessageFlowElementSms))
                        {
                            messageForm.MessageFormInfoObject.Add(new MessageFormElementObjectSms((OmniMessageFlowElementSms)element));
                        }
                        else if (element.GetType() == typeof(OmniMessageFlowElementMms))
                        {
                            messageForm.MessageFormInfoObject.Add(new MessageFormElementObjectMms((OmniMessageFlowElementMms)element));

                        }
                        else if (element.GetType() == typeof(OmniMessageFlowElementRcs))
                        {
                            messageForm.MessageFormInfoObject.Add(new MessageFormElementObjectRcs((OmniMessageFlowElementRcs)element));
                        }
                        else if (element.GetType() == typeof(OmniMessageFlowElementAlimTalk))
                        {
                            messageForm.MessageFormInfoObject.Add(new MessageFormElementObjectAlimTalk((OmniMessageFlowElementAlimTalk)element));
                        }
                        else if (element.GetType() == typeof(OmniMessageFlowElementFriendTalk))
                        {
                            messageForm.MessageFormInfoObject.Add(new MessageFormElementObjectFriendTalk((OmniMessageFlowElementFriendTalk)element));
                        }
                        else if (element.GetType() == typeof(OmniMessageFlowElementBrandMessage))
                        {
                            messageForm.MessageFormInfoObject.Add(new MessageFormElementObjectBrandMessage((OmniMessageFlowElementBrandMessage)element));
                        }

                    }
                }

                return this.messageForm;
            }

        }
    }

    public class MessageFormModifyRequest : MessageFormRequest
    {
        [JsonIgnore]
        public string FormId { get; set; }

        protected MessageFormModifyRequest()
        {
            this.FormId = "";
        }

        public static MessageFormModifyRequestBuilder Builder()
        {
            return new MessageFormModifyRequestBuilder();
        }

        public class MessageFormModifyRequestBuilder
        {
            private readonly MessageFormModifyRequest messageFormModify;

            public MessageFormModifyRequestBuilder()
            {
                this.messageFormModify = new MessageFormModifyRequest();
            }

            public MessageFormModifyRequestBuilder WithModifyFormId(string formId)
            {
                messageFormModify.FormId = formId;
                return this;
            }

            public MessageFormModifyRequestBuilder WithModifyFormInfo(IEnumerable<OmniMessageFlowElement> elements)
            {
                messageFormModify.MessageFormInfo ??= new List<OmniMessageFlowElement>();
                messageFormModify.MessageFormInfo.AddRange(elements);
                return this;
            }
            public MessageFormModifyRequest Build()
            {
                if (messageFormModify.MessageFormInfo is not null)
                {
                    foreach (OmniMessageFlowElement element in messageFormModify.MessageFormInfo)
                    {
                        messageFormModify.MessageFormInfoObject ??= new List<MessageFormElementObject>();

                        if (element.GetType() == typeof(OmniMessageFlowElementSms))
                        {
                            messageFormModify.MessageFormInfoObject.Add(new MessageFormElementObjectSms((OmniMessageFlowElementSms)element));
                        }
                        else if (element.GetType() == typeof(OmniMessageFlowElementMms))
                        {
                            messageFormModify.MessageFormInfoObject.Add(new MessageFormElementObjectMms((OmniMessageFlowElementMms)element));

                        }
                        else if (element.GetType() == typeof(OmniMessageFlowElementRcs))
                        {
                            messageFormModify.MessageFormInfoObject.Add(new MessageFormElementObjectRcs((OmniMessageFlowElementRcs)element));
                        }
                        else if (element.GetType() == typeof(OmniMessageFlowElementAlimTalk))
                        {
                            messageFormModify.MessageFormInfoObject.Add(new MessageFormElementObjectAlimTalk((OmniMessageFlowElementAlimTalk)element));
                        }
                        else if (element.GetType() == typeof(OmniMessageFlowElementFriendTalk))
                        {
                            messageFormModify.MessageFormInfoObject.Add(new MessageFormElementObjectFriendTalk((OmniMessageFlowElementFriendTalk)element));
                        }
                    }
                }

                return messageFormModify;
            }
        }
    }

    public class MessageFormDeleteRequest :MessageFormRequest
    {
        [JsonIgnore]
        public string FormId { get; set; }

        protected MessageFormDeleteRequest()
        {
            this.FormId = "";
        }

        public static MessageFormDeleteRequestBuilder Builder()
        {
            return new MessageFormDeleteRequestBuilder();
        }

        public class MessageFormDeleteRequestBuilder
        {
            private readonly MessageFormDeleteRequest messageFormModify;

            public MessageFormDeleteRequestBuilder()
            {
                this.messageFormModify = new MessageFormDeleteRequest();
            }

            public MessageFormDeleteRequestBuilder WithDeleteFormId(string formId)
            {
                messageFormModify.FormId = formId;
                return this;
            }

            public MessageFormDeleteRequest Build()
            {
                return this.messageFormModify;
            }
            
        }
    }
}