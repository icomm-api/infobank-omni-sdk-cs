using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;


namespace Infobank.Vo.Request
{
    public class BrandMessageImageVariableObject
    {
        [JsonProperty("imgUrl")]
        public string? ImgUrl { get; set; }

        [JsonProperty("imgLink")]
        public string? ImgLink { get; set; }

        public BrandMessageImageVariableObject(string imgUrl, string imgLink)
        {
            ImgUrl = imgUrl;
            ImgLink = imgLink;
        }   
    }


}
