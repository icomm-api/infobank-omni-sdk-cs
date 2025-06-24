using Newtonsoft.Json;

namespace Infobank.Vo.Response
{
    public class OmniMessageResponse :ApiResponse
    {

        [JsonProperty("data")]
        protected OmniResponseData? Data;

        [JsonProperty("ref")]
        protected string RefValue;

        public OmniMessageResponse()
        {

            this.Code = "";
            this.Result = "";
            this.RefValue = "";
            this.Data = null;
        
        }
        public OmniMessageResponse(string code, string result, string refValue)
        {
            this.Code = code;
            this.Result = result;
            this.RefValue = refValue;
            this.Data = null;
        }

        public override string ToString()
        {
            return $"resCode:{Code}, result:{Result}, data:[{Data?.ToString()}], refValue:{RefValue}";
        }


    }

    public class OmniResponseData
    {
        [JsonProperty("destinations")]
        protected List<Destination>? Destinations;

        public override string ToString()
        {
            if (Destinations is null)
            {
                return "destinations:null";
            }
            else
            {
                string result = "";
                foreach (var destination in Destinations)
                {
                    result += destination.ToString() + "\n";
                }
                return $"destinations:{result}";
            }
        }   



    }

}