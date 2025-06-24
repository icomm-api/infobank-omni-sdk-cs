
using Newtonsoft.Json;


namespace Infobank.Vo.Response
{

    public class ApiResponse
    {

        [JsonProperty("code")]
        public string Code { get; set; } 

        [JsonProperty("result")]
        public string Result { get; set; }   

        public ApiResponse()
        {
            this.Code = "";
            this.Result = "";
        }
        
        public override string ToString()
        {
            return $"Code: {Code} Result: {Result}";
        }


    }
}