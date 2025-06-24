using Infobank.Vo;
using Infobank.Vo.Request;
using Infobank.Vo.Response;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;

namespace Infobank.Messaging
{
    public class FileService : MessageService, IMessageService
    {
        private readonly string FileUploadSvcUrl;

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

        public FileService(HttpClient client, string baseUrl, string token, ILogger logger) : base(client, baseUrl)
        {
            // File URL /v1/file/{servieType}/{msgType}
            FileUploadSvcUrl = "v1/file";
            Token = token;
            _logger = logger;
            _typeName = "FileService";
        }

        // NOT USE
        public ApiResponse? SendRequest()
        {

            return null;
        }

        // Not Use
        public string? GetSendJsonData<T>(T message)
        {

            return null;
        }


        private static string GetMineTypeString(string imagePath)
        {
            string? extension = Path.GetExtension(imagePath)?.ToLowerInvariant();

            if (extension is null)
            {
                return "application/octet-stream";
            }
            return extension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".bmp" => "image/bmp",
                _ => "application/octet-stream",
            };
        }

        public ApiResponse? SendRequest<T>(T message)
        {
            if (message is not FileUploadRequest uploadFileInfo || uploadFileInfo.FilePath is null)
            {
                return null;
            }

            try
            {
                var callUrl = "";

                if (uploadFileInfo.MsgType is not null)
                {
                    callUrl = _baseUrl + FileUploadSvcUrl + "/" + uploadFileInfo.ServiceType + "/" + uploadFileInfo.MsgType;
                }
                else
                {
                    callUrl = _baseUrl + FileUploadSvcUrl + "/" + uploadFileInfo.ServiceType;
                }

                var request = new HttpRequestMessage(HttpMethod.Post, callUrl);
                var content = new MultipartFormDataContent();
                byte[] imageData = File.ReadAllBytes(uploadFileInfo.FilePath);
                var fileContent = new ByteArrayContent(imageData);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(GetMineTypeString(uploadFileInfo.FilePath));
                content.Add(fileContent, "file", Path.GetFileName(uploadFileInfo.FilePath));

                request.Content = content;

                HttpResponseMessage response = _client.SendAsync(request).Result;

                if (response.IsSuccessStatusCode)
                {
                    // 성공적으로 요청이 처리됨
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    var response1 = JsonConvert.DeserializeObject<FileUploadResponse>(responseBody);

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
                    // 요청이 실패함
                    _logger.LogInformation("[{Type}] RequestFailed code:{code} url:{url}", _typeName, response.StatusCode, callUrl);
                    _logger.LogDebug("[{Type}] Response Body:{body} ", _typeName, response.Content.ReadAsStringAsync().Result);
                    return null;
                }

            }
            catch (Exception ex)
            {
                _logger.LogInformation("[{Type}] Exception:{errMsg}", _typeName, ex.Message);
            }

            return null;
        }

    }
}
