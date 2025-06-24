using Infobank.Vo;
using Infobank.Vo.Request;
using Infobank.Vo.Response;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;

namespace Infobank.Messaging
{
    public class MmsService : MessageService, IMessageService
    {
        private readonly string _mmsSvcUrl;

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

        public MmsService(HttpClient client, string baseUrl, string token, ILogger logger) : base(client, baseUrl)
        {
            _mmsSvcUrl = "v1/send/mms";

            _token = token;
            _logger = logger;
            _typeName = "MmsService";

        }

        // NOT USE
        public ApiResponse? SendRequest()
        {
            return null;
        }

        public string? GetSendJsonData<T>(T message)
        {
            if (message is MmsRequest request)
            {
                return JsonConvert.SerializeObject(request);
            }
            else
            {

                _logger.LogInformation("[{Type}] Not vaild MMS Request data", _typeName);
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
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_baseUrl + _mmsSvcUrl, content).Result;
                _logger.LogDebug("[{Type}] Request Json:{jsonData} ", _typeName, jsonData);

                if (response.IsSuccessStatusCode)
                {

                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    var response1 = JsonConvert.DeserializeObject<MessageResponse>(responseBody);

                    if (response1 is null)
                    {
                        _logger.LogDebug("[{Type}] Response Json Object Mapping Failed. Json:{Json}", GetType().Name, JObject.Parse(responseBody).ToString(Formatting.Indented));
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

                    _logger.LogInformation("[{Type}] RequestFailed code:{code} url: {url}", _typeName, response.StatusCode, _baseUrl + _mmsSvcUrl);
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
