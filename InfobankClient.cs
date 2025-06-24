using Infobank.Vo;
using Infobank.Vo.Request;
using Infobank.Vo.Response;
using Infobank.Common;
using Infobank.Messaging;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Infobank
{
    public class InfobankClient
    {
        private AuthService? AuthSvc { get; set; }
        private PollingReportService? PollingReportSvc { get; set; }
        // private FileService? FileSvc { get; set; }

        private readonly string DefaultBaseUrl = "https://omni.ibapi.kr/";

        private readonly HttpClient _httpClient;

        private string? _token;
        private string? _tokenExpired;
        private readonly string _clientId;
        private readonly string _clientSecret;

        private SdkLoggerProvider SdkLogger { get; set; } = new SdkLoggerProvider();
        private ILogger Logger { get; set; } = NullLogger.Instance;

        private Dictionary<Type, IMessageService> ServiceMap { get; set; }


        private readonly Dictionary<Type, Type> _serviceTypeMap = new()
        {
            { typeof(SmsRequest), typeof(SmsService) },
            { typeof(InterSmsRequest), typeof(InterSmsService) },
            { typeof(MmsRequest), typeof(MmsService) },
            { typeof(AlimTalkRequest), typeof(AlimTalkService) },
            { typeof(FriendTalkRequest), typeof(FriendTalkService) },
            { typeof(OmniMsgRequest), typeof(OmniService) },
            { typeof(RcsRequest), typeof(RcsService) },
            { typeof(FileUploadRequest), typeof(FileService) },
            { typeof(MessageFormRegistRequest), typeof(MessageFormService) },
            { typeof(MessageFormModifyRequest), typeof(MessageFormService) },
            { typeof(MessageFormDeleteRequest), typeof(MessageFormService) },
            { typeof(BrandMessageRequest), typeof(BrandMessageService) }

        };


        public InfobankClient(string clientId, string clientSecret)
        {

            _httpClient = new HttpClient();
            AuthSvc = null;
            _token = null;
            _clientSecret = clientSecret;
            _clientId = clientId;
            ServiceMap = new Dictionary<Type, IMessageService>();
        }
        public InfobankClient(string clientId, string clientSecret, string baseUrl)
        {

            DefaultBaseUrl = baseUrl;
            _httpClient = new HttpClient();
            //인증 및 토큰 정보 획득
            AuthSvc = null;
            _token = null;
            _clientSecret = clientSecret;
            _clientId = clientId;
            ServiceMap = new Dictionary<Type, IMessageService>();

        }

        public void SetSDKLogFactory(ILoggerFactory loggerFactory)
        {
            this.SdkLogger.SetSdkLogger(loggerFactory);
            Logger = SdkLogger.CreateLogger("Infobank");
        }

        public bool Init()
        {
            AuthSvc ??= new AuthService(_httpClient, DefaultBaseUrl, _clientId, _clientSecret, Logger);

            if (AuthSvc.SendRequest() is not TokenResponse tokenResponse)
            {
                return false;
            }
            else
            {
                if (tokenResponse.Code == Constants.API_RESPONSE_SUCCESS)
                {
                    TokenData data = tokenResponse.Data;
                    if (data.Token is not null)
                    {
                        _token = data.Token;
                        _tokenExpired = data.Expired;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return false;
        }


        private Boolean CheckToken()
        {
            if (_token is null)
            {
                // Token 발급 처리 후 진행
                if (this.Init() == false)
                {
                    return false;
                }
            }
            else // 유효성 체크
            {
                if (_tokenExpired is not null)
                {
                    DateTime dateTime = DateTime.Parse(_tokenExpired, null, System.Globalization.DateTimeStyles.RoundtripKind);

                    // 만료 5분 전에 갱신 하도록 한다.
                    DateTime now = DateTime.Now.AddMinutes(5);

                    int result = DateTime.Compare(dateTime, now);

                    if (result <= 0)
                    {
                        Logger.LogDebug("5 minutes until token information expiration. Token Info Change. ");
                        if (this.Init() == false)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        Logger.LogDebug("Token is Vaild:{token}", _token);
                    }
                }
                else // not vaild Expired Info
                {
                    Logger.LogDebug("Token expired Info Error. change Token Info ");
                    if (this.Init() == false)
                    {
                        return false;
                    }
                }

            }

            return true;
        }
        private Boolean RegistService(Type requestType)
        {
            // 요청 타입과 매핑된 서비스 타입을 찾습니다.
            //public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value);
            if (_serviceTypeMap.TryGetValue(requestType, out Type? serviceType))
            {
                // 서비스 객체를 생성하여 등록합니다.
                IMessageService? service = (IMessageService?)Activator.CreateInstance(serviceType, _httpClient, DefaultBaseUrl, _token, Logger);
                if (service is not null)
                {
                    service.Init();
                    ServiceMap[requestType] = service;
                    return true;
                }
            }
            return false;

        }

        public ApiResponse? SendMessage(MessageRequest request)
        {
            try
            {
                if (this.CheckToken() is false)
                {
                    throw new GetTokenException("Get Token Failed.");
                }

                if (request is not null)
                {
                    Type requestType = request.GetType();

                    //public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value);
                    if (this.ServiceMap.TryGetValue(requestType, out IMessageService? service))
                    {
                        return service.SendRequest(request);
                    }
                    else  // Service is registered but not usable
                    {
                        // Register service by determining whether registration is possible
                        if (RegistService(requestType))
                        {
                            return ServiceMap[requestType].SendRequest(request);
                        }
                        else
                        {
                            throw new NotSupportServiceException("RequestType:" + requestType.Name + "not found Service");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogInformation("{Class}.{Method}: {Message}", ex.TargetSite?.DeclaringType?.Name, ex.TargetSite?.Name, ex.Message);
                Logger.LogInformation("{traceInfo}", ex.StackTrace);
            }
            return null;

        }

        public ApiResponse? ReceivePollingReport()
        {
            if (this.CheckToken() is false)
            {
                throw new GetTokenException("Get Token Failed.");
            }

            if (PollingReportSvc is null)
            {
                if (_token is not null)
                {
                    PollingReportSvc = new PollingReportService(_httpClient, DefaultBaseUrl, _token, Logger);
                    if (PollingReportSvc.Init())
                    {
                        Logger.LogInformation("polling Report Service Init OK ");
                    }

                }
                else
                {
                    throw new GetTokenException("Token Data Not Vaild.");
                }
            }

            return PollingReportSvc.SendRequest();
        }

        public ApiResponse? DeleteReport(string reportId)
        {
            if (this.CheckToken() is false)
            {
                throw new GetTokenException("Get Token Failed.");
            }

            if (PollingReportSvc is null)
            {

                if (_token is not null)
                {
                    PollingReportSvc = new PollingReportService(_httpClient, DefaultBaseUrl, _token, Logger);
                    if (PollingReportSvc.Init())
                    {
                        Logger.LogInformation("polling Report Service Init OK ");
                    }

                }
                else
                {
                    throw new GetTokenException("Token Data Not Vaild.");
                }

            }

            return PollingReportSvc.DeleteReport(reportId);

        }

        public ApiResponse? FileUpload(string servieType, string filePath)
        {
            return FileUpload(servieType, "", filePath);
        }
        public ApiResponse? FileUpload(string servieType, string msgType, string filePath)
        {
            FileUploadRequest fileInfo = FileUploadRequest.Builder()
                                                          .WithServiceType(servieType)
                                                          .WithMsgType(msgType)
                                                          .WithFilePath(filePath)
                                                          .Build();
            return this.SendMessage(fileInfo);
        }

    }
}