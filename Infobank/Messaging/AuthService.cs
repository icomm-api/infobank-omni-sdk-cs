using Infobank.Vo;
using Infobank.Vo.Response;
using System;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;

namespace Infobank.Messaging
{
    public class AuthService : MessageService, IMessageService
    {

        private readonly string _v1TokenUrl;

        private string? ClientId { get; set; }
        private string? ClientSecret { get; set; }

        private readonly ILogger _logger;
        private readonly string _typeName ;



        public AuthService(HttpClient client, string baseUrl, string clientId, string clientSecret, ILogger logger) : base(client, baseUrl)
        {
            _v1TokenUrl = "v1/auth/token";

            ClientId = clientId;
            ClientSecret = clientSecret;

            _logger = logger;
            _typeName = "AuthService";

            Init();
        }

        public bool Init()
        {
            _client.DefaultRequestHeaders.Add("X-IB-Client-Id", ClientId);
            _client.DefaultRequestHeaders.Add("X-IB-Client-Passwd", ClientSecret);

            return true;
        }

        //Not Use
        public string? GetSendJsonData<T>(T message)
        {
            return null;
        }

        // Not Use
        public ApiResponse? SendRequest<T>(T message)
        {
            return null;
        }

        public ApiResponse? SendRequest()
        {

            try
            {

                HttpResponseMessage response = _client.PostAsync(_baseUrl + _v1TokenUrl, null).Result;

                if (response.IsSuccessStatusCode)
                {
                    // 성공적으로 요청이 처리됨
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    _logger.LogDebug("[{Type}] Request Json:{jsonData} ",_typeName, responseBody);
                    var response1 = JsonConvert.DeserializeObject<TokenResponse>(responseBody);

                    if (response1 is null)
                    {
                        _logger.LogDebug("[{Type}] Response Json Object Mapping Failed. Json:{Json}", _typeName, JObject.Parse(responseBody).ToString(Formatting.Indented));
                        return null;
                    }
                    else
                    {
                        return response1;
                    }

                }
                else
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    _logger.LogInformation("[{Type}] ResponseData:{body} ID:{clientId} Pwd:{Pwd}" ,_typeName, responseBody , this.ClientId , this.ClientSecret);
                    _logger.LogInformation("[{Type}] RequestFailed code:{code} url: {url}",_typeName, response.StatusCode, _baseUrl + _v1TokenUrl);
                 
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("[{Type}] Exception:{errMsg}" ,_typeName, ex.Message);
            }

            return null;

        }



    }
}
