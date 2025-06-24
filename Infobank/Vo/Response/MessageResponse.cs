using Newtonsoft.Json;

namespace Infobank.Vo.Response
{
    public class MessageResponse :ApiResponse
    {

        [JsonProperty("msgKey")]
        protected string MsgKey;

        [JsonProperty("ref")]
        protected string RefValue;

        public MessageResponse()
        {

            this.Code = "";
            this.Result = "";
            this.MsgKey = "";
            this.RefValue = "";
        
        }
        public MessageResponse(string code, string result, string msgKey, string refValue)
        {
            this.Code = code;
            this.Result = result;
            this.MsgKey = msgKey;
            this.RefValue = refValue;

        }

        public override string ToString()
        {
            return $"resCode:{Code}, result:{Result}, messageKey:{MsgKey}, refValue:{RefValue}";
        }


    }

}