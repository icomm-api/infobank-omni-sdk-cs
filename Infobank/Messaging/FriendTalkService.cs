using Infobank.Vo;
using Infobank.Vo.Request;
using Infobank.Vo.Response;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;

namespace Infobank.Messaging
{
    public class FriendTalkService : MessageService, IMessageService
    {
        private readonly string _friendTalkSvcUrl;

        private readonly string? _token;
        private readonly ILogger _logger;

        private readonly string _typeName;

        public bool Init()
        {
            if (_token is null)
            {
                return false;
            }

            if (_client.DefaultRequestHeaders.Contains("Authorization") == false)
            {
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _token);
                _client.DefaultRequestHeaders.Add("Accept", "application/json");
            }


            return true;
        }

        public FriendTalkService(HttpClient client, string baseUrl, string token, ILogger logger) : base(client, baseUrl)
        {
            _friendTalkSvcUrl = "v1/send/friendtalk";

            _token = token;
            _logger = logger;
            _typeName = "FriendTalkService";

        }

        // NOT USE
        public ApiResponse? SendRequest()
        {
            return null;
        }

        public string? GetSendJsonData<T>(T message)
        {
            if (message is FriendTalkRequest request)
            {

                return JsonConvert.SerializeObject(
                    request,
                    new JsonSerializerSettings { Formatting = Formatting.Indented, NullValueHandling = NullValueHandling.Ignore }
                    );

            }
            else
            {

                _logger.LogInformation("[{Type}] Not vaild FriendTalk Request data", _typeName);
            }
            return "";
        }

        public ApiResponse? SendRequest<T>(T message)
        {
            try
            {

                string? jsonData = this.GetSendJsonData(message);

                if (jsonData is null)
                {
                    return null;
                }

                _logger.LogDebug("[{Type}] Request Json:{jsonData} ", _typeName, jsonData);

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_baseUrl + _friendTalkSvcUrl, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    var response1 = JsonConvert.DeserializeObject<MessageResponse>(responseBody);

                    if (response1 is null)
                    {
                        _logger.LogDebug("[{Type}] Response Json Object Mapping Failed. Json:{Json}", _typeName, JObject.Parse(responseBody).ToString(Formatting.Indented));
                        return null;
                    }
                    else
                    {
                        _logger.LogDebug("[{Type}] Response  Json:{resData}", _typeName, response1.ToString());
                        return response1;
                    }

                }
                else
                {
                    _logger.LogInformation("[{Type}] RequestFailed code:{code} url: {url}", _typeName, response.StatusCode, _baseUrl + _friendTalkSvcUrl);
                    _logger.LogDebug("[{Type}] Response Data:{result}", _typeName, response.Content.ReadAsStringAsync().Result);
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("[{Type}] Exception:{errorMsg} ", _typeName, ex.Message);
            }

            return null;


        }



    }
}
