using Infobank.Vo;
using Infobank.Vo.Request;
using Infobank.Vo.Response;
using System;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;

namespace Infobank.Messaging
{
    public class MessageFormService : MessageService, IMessageService
    {
        private readonly string FormMessageSvcUrl;

        private readonly string? Token;
        private readonly ILogger _logger;
        private readonly string _typeName;

        public bool Init()
        {
            if (Token is null)
            {
                return false;
            }

            if (_client.DefaultRequestHeaders.Contains("Authorization") == false)
            {
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("multipart/form-data"));
                _client.DefaultRequestHeaders.Add("Accept", "application/json");
            }


            return true;
        }

        public MessageFormService(HttpClient client, string baseUrl, string token, ILogger logger) : base(client, baseUrl)
        {
            // Form Message Base URL /v1/form 
            // Form Message Modify Url /v1/form/{formId}
            // Form Message Delete Url /v1/form/{formId}
            FormMessageSvcUrl = "v1/form";
            Token = token;
            _logger = logger;
            _typeName = "MessageFormService";
        }

        // NOT USE
        public ApiResponse? SendRequest()
        {

            return null;
        }

        public string? GetSendJsonData<T>(T message)
        {
            if (message is MessageFormRegistRequest requestRegist)
            {
                return JsonConvert.SerializeObject(
                    requestRegist,
                    new JsonSerializerSettings { Formatting = Formatting.Indented, NullValueHandling = NullValueHandling.Ignore }
                );
            }
            else if (message is MessageFormModifyRequest requestModify)
            {
                return JsonConvert.SerializeObject(
                    requestModify,
                    new JsonSerializerSettings { Formatting = Formatting.Indented, NullValueHandling = NullValueHandling.Ignore }
                );
            }

            return "";
        }


        public ApiResponse? SendRequest<T>(T message)
        {
            string callUrl;
            HttpRequestMessage request;

            if (message is MessageFormRegistRequest)
            {
                callUrl = _baseUrl + FormMessageSvcUrl;
                request = new(HttpMethod.Post, callUrl);
            }
            else if (message is MessageFormModifyRequest requestModify)
            {
                callUrl = _baseUrl + FormMessageSvcUrl + "/" + requestModify.FormId;
                request = new(HttpMethod.Put, callUrl);
            }
            else if (message is MessageFormDeleteRequest requestDelete)
            {
                callUrl = _baseUrl + FormMessageSvcUrl + "/" + requestDelete.FormId;
                request = new(HttpMethod.Delete, callUrl);
            }
            else
            {
                return null;
            }

            try
            {
                string? jsonData = this.GetSendJsonData(message);

                if (jsonData is null)
                {
                    return null;
                }
                _logger.LogDebug("[{Type}] Request Json:{jsonData} ", _typeName, jsonData);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                request.Content = content;
                HttpResponseMessage response = _client.SendAsync(request).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    ApiResponse? response1 = null;

                    if (message is MessageFormRegistRequest)
                    {
                        response1 = JsonConvert.DeserializeObject<MessageFormRegistResponse>(responseBody);
                    }
                    else if (message is MessageFormModifyRequest requestModify)
                    {
                        response1 = JsonConvert.DeserializeObject<MessageFormModifyResponse>(responseBody);
                    }
                    else
                    {
                        response1 = JsonConvert.DeserializeObject<ApiResponse>(responseBody);
                    }

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
                    _logger.LogInformation("[{Type}] RequestFailed code:{code} url: {url}", _typeName, response.StatusCode, _baseUrl + callUrl);
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
