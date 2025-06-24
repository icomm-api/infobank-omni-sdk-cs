using Newtonsoft.Json;

namespace Infobank.Vo.Response
{

    public class Destination
    {
        [JsonProperty("to")]
        public string To {get; set;}

        [JsonProperty("msgKey")]
        public string MsgKey {get; set;}

        [JsonProperty("code")]
        public string Code {get; set; }

        [JsonProperty("result")]
        public string Result {get; set;}

        public Destination()
        {
            this.To = "";
            this.Result ="";
            this.MsgKey = "";
            this.Code = "";
        }

        public override string ToString()
        {
            return $"to:{To}, msgKey:{MsgKey}, code:{Code}, result:{Result}";
        }
        
    }
    
}