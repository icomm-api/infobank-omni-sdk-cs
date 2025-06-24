using Infobank.Vo;
using Infobank.Vo.Request;
using Infobank.Vo.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;

namespace Infobank.Messaging
{

    class PollingReportService : MessageService, IMessageService
    {

        private readonly string _rptPollSvcUrl;

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

        public PollingReportService(HttpClient client, string baseUrl, string token, ILogger logger) : base(client, baseUrl)
        {
            _rptPollSvcUrl = "v1/report/polling";
            _token = token;
            _logger = logger;
            _typeName = "PollingReportService";

        }

        public ApiResponse? DeleteReport(string reportId)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, _baseUrl + _rptPollSvcUrl + "/" + reportId);
                request.Content = new StringContent("", System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = _client.SendAsync(request).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    var response1 = JsonConvert.DeserializeObject<ApiResponse>(responseBody);

                    if (response1 is null)
                    {
                        _logger.LogDebug("[{Type}] Response Json Object Mapping Failed(DeleteReport). Json:{Json}", _typeName, JObject.Parse(responseBody).ToString(Formatting.Indented));
                        return null;
                    }
                    else
                    {
                        _logger.LogDebug("[{Type}] Response(DeleteReport)  Json:{resData}", _typeName, response1.ToString());
                        return response1;
                    }

                }
                else
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    _logger.LogInformation("[{Type}] RequestFailed(DeleteReport) code:{code} url: {url}", _typeName, response.StatusCode, _baseUrl + _rptPollSvcUrl);
                    _logger.LogDebug("[{Type}] Response(DeleteReport) Data:{result}", _typeName, response.Content.ReadAsStringAsync().Result);
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("[{Type}] Exception(DeleteReport):{errorMsg} ", _typeName, ex.Message);
            }

            return null;

        }

        // NOT USE
        public ApiResponse? SendRequest()
        {

            try
            {

                var request = new HttpRequestMessage(HttpMethod.Get, _baseUrl + _rptPollSvcUrl);
                request.Content = new StringContent("", System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = _client.SendAsync(request).Result;

                if (response.IsSuccessStatusCode)
                {
                    // 성공적으로 요청이 처리됨
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    var response1 = JsonConvert.DeserializeObject<ReportPollingResponse>(responseBody);

                    if (response1 is null)
                    {
                        _logger.LogDebug("[{Type}] Response Json Object Mapping Failed. Json:{Json}", _typeName, JObject.Parse(responseBody).ToString(Formatting.Indented));
                        return null;
                    }
                    else
                    {
                        _logger.LogDebug("[{Type}] Response Json:{resData}", _typeName, response1.ToString());
                        return response1;
                    }

                }
                else
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    _logger.LogInformation("[{Type}] RequestFailed code:{code} url: {url}", _typeName, response.StatusCode, _baseUrl + _rptPollSvcUrl);
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

        //NOT USE
        public string? GetSendJsonData<T>(T message)
        {
            return null;
        }

        //NOT USE
        public ApiResponse? SendRequest<T>(T message)
        {
            return null;
        }


    }

}