using Newtonsoft.Json;


namespace Infobank.Vo.Response
{
    public class TokenData
    {

        [JsonProperty("token")]
        public string Token { get; set; }   

        [JsonProperty("schema")]
        public string Schema { get; set; }  

        [JsonProperty("expired")]
        public string Expired{ get; set; }  

        public TokenData()
        {
            Token = "";
            Schema = "";
            Expired = "";

        }
 
        
        public override string ToString()
        {
            return $"Token: {Token}, Schema:{Schema}, Expired:{Expired}";
        }


    }

    class TokenResponse :ApiResponse
    {

        [JsonProperty("data")]
        private TokenData _data;

        public TokenResponse()
        {
            this.Code = "";
            this.Result = "";
            this._data = new TokenData();
        }



        [JsonIgnore]
        public TokenData Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public override string ToString()
        {
            return $"Code: {Code}, result:{Result}, Data:{_data}";
        }


    }

}