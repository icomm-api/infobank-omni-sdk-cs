using Newtonsoft.Json;


namespace Infobank.Vo.Response
{
    public class FormInfo
    {

        [JsonProperty("formId")]
        public string FormId {get; set; }    


        [JsonProperty("expired")]
        public string Expired{get; set; }   

        public FormInfo()
        {
            FormId = "";
            Expired = "";
        }

        public override string ToString()
        {
            return $"FormId: {FormId}, Expired: {Expired}";
        }


    }

    public class MessageFormRegistResponse : ApiResponse
    {

        [JsonProperty("data")]
        public FormInfo Data { get; set; }

        public MessageFormRegistResponse()
        {
            this.Code = "";
            this.Result = "";
            this.Data = new FormInfo();
        }

        public override string ToString()
        {
            return $"Code: {Code}, result:{Result}, Data:{Data}";
        }


    }

    public class MessageFormModifyResponse : ApiResponse
    {

        [JsonProperty("data")]
        public FormInfo Data { get; set; }

        public MessageFormModifyResponse()
        {
            this.Code = "";
            this.Result = "";
            this.Data = new FormInfo();
        }

        public override string ToString()
        {
            return $"Code: {Code}, result:{Result}, Data:{Data}";
        }


    }

}