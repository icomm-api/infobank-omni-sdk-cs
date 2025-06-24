using Newtonsoft.Json;


namespace Infobank.Vo.Response
{
    public class FileData
    {

        [JsonProperty("imgUrl")]
        public string ImgUrl {get; set; }    

        [JsonProperty("fileKey")]
        public string FileKey   {get; set; }    

        [JsonProperty("media")]
        public string Media {get; set; }    

        [JsonProperty("expired")]
        public string Expired{get; set; }   

        public FileData()
        {
            ImgUrl = "";
            FileKey = "";
            Media = "";
            Expired = "";
        }

        public override string ToString()
        {
            return $"ImgUrl: {ImgUrl}, FileKey:{FileKey}, Media:{Media}, Expired: {Expired}";
        }


    }

    public class FileUploadResponse : ApiResponse
    {

        [JsonProperty("data")]
        public FileData Data { get; set; }

        public FileUploadResponse()
        {
            this.Code = "";
            this.Result = "";
            this.Data = new FileData();
        }

        public override string ToString()
        {
            return $"Code: {Code}, result:{Result}, Data:{Data}";
        }


    }

}