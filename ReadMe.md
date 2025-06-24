# Infobank Omni SDK for .NET

A comprehensive .NET SDK for Infobank's OMNI API (Unified Messaging API). This SDK provides easy integration with various messaging services including SMS, MMS, AlimTalk, FriendTalk, RCS, and more.

인포뱅크 OMNI API(통합메시지 API)용 .NET SDK입니다. SMS, MMS, 알림톡, 친구톡, RCS 등 다양한 메시지 서비스를 .NET 환경에서 쉽게 연동할 수 있습니다.

## Features / 주요 특징

-   **Multiple Message Types**: Support for SMS, MMS, AlimTalk, FriendTalk, RCS, Brand Messages
-   **다양한 메시지 타입 지원**: SMS, MMS, 알림톡, 친구톡, RCS, 브랜드메시지 등 지원

-   **File Upload**: Built-in file upload service for media content
-   **파일 업로드**: 미디어 파일 업로드 기능 내장

-   **Comprehensive Logging**: Microsoft.Extensions.Logging integration
-   **로깅 연동**: Microsoft.Extensions.Logging 연동

-   **Type Safety**: Strongly typed request/response objects
-   **타입 안전성**: 강력한 타입의 요청/응답 객체 제공

-   **Error Handling**: Comprehensive exception handling
-   **예외 처리**: 상세한 예외 처리 제공

## Documentation / 문서

-   **EN:** For detailed API specifications, please refer to the [OMNI API Documentation](https://omniapi.gitbook.io/omni-api-specification/).
-   **KR:** 자세한 API 규격은 [OMNI API 문서](https://omniapi.gitbook.io/omni-api-specification/)를 참고하세요.

## Requirements / 요구사항

-   [Create an account](https://bizgo.io) for API usage
-   Register sender numbers for MT/RCS transmission
-   Join RCS BizCenter for RCS transmission
-   Join Kakao Business for Kakao AlimTalk/FriendTalk/Brand Message transmission
-   Configure firewall to allow IP addresses specified in the documentation

-   API 사용을 위한 [계정 생성](https://bizgo.io)
-   MT/RCS 발송을 위한 발신번호 등록
-   RCS 전송을 위한 RCS BizCenter 가입
-   카카오 알림톡/친구톡/브랜드메시지 발송을 위한 카카오비즈니스 가입
-   규격서에 안내된 IP로 방화벽 허용

## Supported Platforms / 지원 환경

-   C# (12.0 or higher) / C# 12.0 이상
-   .NET (8.0 or higher) / .NET 8.0 이상

## Installation / 설치 방법

### NuGet Package Manager

```bash
Install-Package Infobank.Omni.Sdk.Cs
```

### .NET CLI

```bash
dotnet add package Infobank.Omni.Sdk.Cs
```

### PackageReference

```xml
<PackageReference Include="Infobank.Omni.Sdk.Cs" Version="1.0.0" />
```

## Quick Start / 빠른 시작

### Initialize the Client / 클라이언트 초기화

```csharp
using Infobank;

// Initialize with your credentials
InfobankClient client = new InfobankClient(clientId, clientSecret);

// For staging environment
// InfobankClient client = new InfobankClient(clientId, clientSecret, stgUrl);

// Set up logging
client.SetSDKLogFactory(loggerFactory);

// Initialize the client
if (!client.Init())
{
    _logger.LogInformation("Message Client Init Failed");
    return;
}
```

-   **EN:** Initialize the SDK client with your credentials. For staging, use the staging URL.
-   **KR:** 클라이언트 ID, 시크릿으로 SDK를 초기화합니다. 스테이징 환경은 별도 URL을 사용하세요.

### Send SMS / SMS 전송

```csharp
// Create SMS request
SmsRequest smsRequest = SmsRequest.Builder()
                                  .WithFrom("SENDER_NUMBER")
                                  .WithTo("RECIPIENT_NUMBER")
                                  .WithText("Hello from Infobank SDK!")
                                  .Build();

// Send the message
ApiResponse? response = client.SendMessage(smsRequest);

if (response?.IsSuccess == true)
{
    Console.WriteLine("SMS sent successfully!");
}
```

-   **EN:** Build and send an SMS message.
-   **KR:** SMS 요청 객체를 생성하고 메시지를 전송합니다.

### Send AlimTalk / 알림톡 전송

```csharp
// Create AlimTalk request
            //버튼 없는 알림톡
            AlimTalkRequest alimTalkRequest = AlimTalkRequest.Builder()
                                           .WithSenderKey("SENDER_KEY")
                                           .WithMsgType("AT")
                                           .WithTo("RECIPIENT_NUMNER")
                                           .WithText("AlrimTalk Message")
                                           .WithTemplateCode("TEMPLATE_CODE")
                                           .Build();

// Send the message
ApiResponse? response = client.SendMessage(alimTalkRequest);
```

-   **EN:** Build and send a Kakao AlimTalk message.
-   **KR:** 알림톡 요청 객체를 생성하고 메시지를 전송합니다.

### Send MMS / MMS 전송

```csharp
// Create MMS request
MmsRequest mmsRequest = MmsRequest.Builder()
                                  .WithFrom("SENDER_NUMBER")
                                  .WithTo("RECIPIENT_NUMBER")
                                  .WithSubject("MMS Subject")
                                  .WithText("MMS content")
                                  .WithFileId("UPLOADED_FILE_ID")
                                  .Build();

// Send the message
ApiResponse? response = client.SendMessage(mmsRequest);
```

-   **EN:** Build and send an MMS message with attachments.
-   **KR:** MMS 요청 객체를 생성하고 첨부파일과 함께 메시지를 전송합니다.

## Logging Support / 로깅 지원

The SDK uses Microsoft.Extensions.Logging for comprehensive logging support. You can configure your preferred logging provider:

SDK는 Microsoft.Extensions.Logging을 사용합니다. 원하는 로깅 프로바이더를 설정할 수 있습니다.

```csharp
using Microsoft.Extensions.Logging;

var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
});

client.SetSDKLogFactory(loggerFactory);
```

## Error Handling / 예외 처리

The SDK provides comprehensive error handling through custom exceptions:

SDK는 커스텀 예외를 통해 상세한 에러 처리를 지원합니다.

```csharp
try
{
    ApiResponse? response = client.SendMessage(request);
}
catch (InfobankException ex)
{
    _logger.LogError($"Infobank API Error: {ex.Message}");
}
catch (Exception ex)
{
    _logger.LogError($"Unexpected error: {ex.Message}");
}
```

## Message Types Supported / 지원 메시지 타입

-   **SMS**: Simple text messages / 단문 문자 메시지
-   **MMS**: Multimedia messages with attachments / 첨부파일 포함 멀티미디어 메시지
-   **AlimTalk**: Kakao AlimTalk messages / 카카오 알림톡
-   **FriendTalk**: Kakao FriendTalk messages / 카카오 친구톡
-   **RCS**: Rich Communication Services / RCS 메시지
-   **Brand Messages**: Brand-specific messaging / 브랜드 메시지
-   **InterSMS**: International SMS / 국제 SMS
-   **File Upload**: Media file upload service / 미디어 파일 업로드

## License / 라이선스

This project is licensed under the MIT License - see the LICENSE file for details.
본 프로젝트는 MIT 라이선스로 배포됩니다. 자세한 내용은 LICENSE 파일을 참고하세요.

## Contact / 문의

For technical support and questions, please contact us at:
기술 문의는 아래 메일로 연락해 주세요.

> support@infobank.net

## Changelog / 변경 이력

### Version 1.0.0

-   Initial release / 첫 릴리즈
-   Support for all major message types / 주요 메시지 타입 지원
-   Comprehensive logging integration / 로깅 연동
-   Strongly typed request/response objects / 타입 안전 요청/응답 객체 제공
