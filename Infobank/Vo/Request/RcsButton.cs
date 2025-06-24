
using Newtonsoft.Json;

namespace Infobank.Vo.Request
{

    public abstract class RcsButton
    {

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string? Type { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string? Name { get; set; }
        protected RcsButton()
        {
            Type = null;
            Name = null;

        }
    }

    // 1. URL 연결 버튼 
    public class RcsButtonOpenUrl : RcsButton
    {
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string? Url { get; set; }

        private RcsButtonOpenUrl() : base()
        {
            Url = null;
            Type = "URL";
        }

        public static RcsButtonBuilderOpenUrl Builder()
        {
            return new RcsButtonBuilderOpenUrl();
        }

        public class RcsButtonBuilderOpenUrl
        {
            private readonly RcsButtonOpenUrl openUrlButton;

            public RcsButtonBuilderOpenUrl()
            {
                openUrlButton = new RcsButtonOpenUrl();
            }

            public RcsButtonBuilderOpenUrl WithName(string name)
            {
                openUrlButton.Name = name;
                return this;
            }

            public RcsButtonBuilderOpenUrl WithUrl(string url)
            {
                openUrlButton.Url = url;
                return this;
            }

            public RcsButtonOpenUrl Build()
            {
                return openUrlButton;
            }
        }
    }


    // 2.지도 보여주기 버튼 
    public class RcsButtonShowLocation : RcsButton
    {
        public string? Label { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? FallbackUrl { get; set; }

        private RcsButtonShowLocation() : base()
        {
            Label = null;
            Latitude = null;
            Longitude = null;
            FallbackUrl = null;
            Type = "MAP_LOC";
        }

        public static RcsButtonBuilderShowLocation Builder()
        {
            return new RcsButtonBuilderShowLocation();
        }
        public class RcsButtonBuilderShowLocation
        {
            private readonly RcsButtonShowLocation showLocationButton;

            public RcsButtonBuilderShowLocation()
            {
                showLocationButton = new RcsButtonShowLocation();
            }

            public RcsButtonBuilderShowLocation WithName(string name)
            {
                showLocationButton.Name = name;
                return this;
            }

            public RcsButtonBuilderShowLocation WithLabel(string label)
            {
                showLocationButton.Label = label;
                return this;
            }

            public RcsButtonBuilderShowLocation WithLatitude(string latitude)
            {
                showLocationButton.Latitude = latitude;
                return this;
            }

            public RcsButtonBuilderShowLocation WithLongitude(string longitude)
            {
                showLocationButton.Longitude = longitude;
                return this;
            }

            public RcsButtonBuilderShowLocation WithFallbackUrl(string fallbackUrl)
            {
                showLocationButton.FallbackUrl = fallbackUrl;
                return this;
            }

            public RcsButtonShowLocation Build()
            {
                return showLocationButton;
            }
        }
    }

    // 3.지도 검색 버튼 
    public class RcsButtonSearchLocation : RcsButton
    {
        public string? Query { get; set; }
        public string? FallbackUrl { get; set; }

        private RcsButtonSearchLocation() : base()
        {
            Query = null;
            FallbackUrl = null;
            Type = "MAP_QRY";
        }

        public static RcsButtonBuilderSearchLocation Builder()
        {
            return new RcsButtonBuilderSearchLocation();
        }
        public class RcsButtonBuilderSearchLocation
        {
            private readonly RcsButtonSearchLocation searchLocationButton;

            public RcsButtonBuilderSearchLocation()
            {
                searchLocationButton = new RcsButtonSearchLocation();
            }

            public RcsButtonBuilderSearchLocation WithName(string name)
            {
                searchLocationButton.Name = name;
                return this;
            }

            public RcsButtonBuilderSearchLocation WithQuery(string query)
            {
                searchLocationButton.Query = query;
                return this;
            }

            public RcsButtonBuilderSearchLocation WithFallbackUrl(string fallbackUrl)
            {
                searchLocationButton.FallbackUrl = fallbackUrl;
                return this;
            }

            public RcsButtonSearchLocation Build()
            {
                return searchLocationButton;
            }
        }
    }

    public class RcsButtonPushLocation : RcsButton
    {
        private RcsButtonPushLocation() : base()
        {
            Type = "MAP_SEND";
        }

        public static RcsButtonBuilderPushLocation Builder()
        {
            return new RcsButtonBuilderPushLocation();

        }
        public class RcsButtonBuilderPushLocation
        {
            private readonly RcsButtonPushLocation pushLocationButton;

            public RcsButtonBuilderPushLocation()
            {
                pushLocationButton = new RcsButtonPushLocation();
            }

            public RcsButtonBuilderPushLocation WithName(string name)
            {
                pushLocationButton.Name = name;
                return this;
            }

            public RcsButtonPushLocation Build()
            {
                return pushLocationButton;
            }
        }

    }


    // 5.일정 등록 버튼 
    public class RcsEventButtonCreateCalendar : RcsButton
    {
        [JsonProperty("startTime", NullValueHandling = NullValueHandling.Ignore)]
        public string? StartTime { get; set; }

        [JsonProperty("endTime", NullValueHandling = NullValueHandling.Ignore)]
        public string? EndTime { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string? Title { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string? Description { get; set; }


        private RcsEventButtonCreateCalendar() : base()
        {
            StartTime = null;
            EndTime = null;
            Title = null;
            Description = null;
            Type = "CALENDAR";
        }
        public static RcsButtonBuilderCreateCalendarEvent Builder()
        {
            return new RcsButtonBuilderCreateCalendarEvent();
        }


        public class RcsButtonBuilderCreateCalendarEvent
        {
            private readonly RcsEventButtonCreateCalendar createCalendarEventButton;

            public RcsButtonBuilderCreateCalendarEvent()
            {
                createCalendarEventButton = new RcsEventButtonCreateCalendar();
            }

            public RcsButtonBuilderCreateCalendarEvent WithStartTime(string startTime)
            {
                createCalendarEventButton.StartTime = startTime;
                return this;
            }

            public RcsButtonBuilderCreateCalendarEvent WithEndTime(string endTime)
            {
                createCalendarEventButton.EndTime = endTime;
                return this;
            }

            public RcsButtonBuilderCreateCalendarEvent WithTitle(string title)
            {
                createCalendarEventButton.Title = title;
                return this;
            }

            public RcsButtonBuilderCreateCalendarEvent WithDescription(string description)
            {
                createCalendarEventButton.Description = description;
                return this;
            }

            public RcsButtonBuilderCreateCalendarEvent WithName(string name)
            {
                createCalendarEventButton.Name = name;
                return this;
            }

            public RcsEventButtonCreateCalendar Build()
            {
                return createCalendarEventButton;
            }
        }


    }

    // 6.복사하기 버튼 
    public class RcsButtonCopyToClipboard : RcsButton
    {
        public string? Text { get; set; }


        private RcsButtonCopyToClipboard() : base()
        {
            Text = null;
            Type = "COPY";

        }

        public static RcsButtonBuilderCopyToClipboard Builder()
        {
            return new RcsButtonBuilderCopyToClipboard();
        }

        public class RcsButtonBuilderCopyToClipboard
        {
            private readonly RcsButtonCopyToClipboard copyToClipboardButton;

            public RcsButtonBuilderCopyToClipboard()
            {
                copyToClipboardButton = new RcsButtonCopyToClipboard();
            }

            public RcsButtonBuilderCopyToClipboard WithText(string text)
            {
                copyToClipboardButton.Text = text;
                return this;
            }

            public RcsButtonBuilderCopyToClipboard WithName(string name)
            {
                copyToClipboardButton.Name = name;
                return this;
            }

            public RcsButtonCopyToClipboard Build()
            {
                return copyToClipboardButton;
            }
        }

    }



    // 7.대화방 열기 TEXT (다른 번호로 메시지를 보낼 수 있도록 대화방을 엽니다.)

    public class RcsButtonComposeTextMessage : RcsButton
    {
        public string? PhoneNumber { get; set; }
        public string? Text { get; set; }


        private RcsButtonComposeTextMessage() : base()
        {
            PhoneNumber = null;
            Text = null;
            Type = "COM_T";
        }


        public static RcsButtonBuilderComposeTextMessage Builder()
        {
            return new RcsButtonBuilderComposeTextMessage();
        }

        public class RcsButtonBuilderComposeTextMessage
        {
            private readonly RcsButtonComposeTextMessage composeTextMessageButton;

            public RcsButtonBuilderComposeTextMessage()
            {
                composeTextMessageButton = new RcsButtonComposeTextMessage();
            }

            public RcsButtonBuilderComposeTextMessage WithPhoneNumber(string phoneNumber)
            {
                composeTextMessageButton.PhoneNumber = phoneNumber;
                return this;
            }

            public RcsButtonBuilderComposeTextMessage WithText(string text)
            {
                composeTextMessageButton.Text = text;
                return this;
            }

            public RcsButtonBuilderComposeTextMessage WithName(string name)
            {
                composeTextMessageButton.Name = name;
                return this;
            }

            public RcsButtonComposeTextMessage Build()
            {
                return composeTextMessageButton;
            }
        }
    }

    // 8.대화방 열기 Video/Audio (다른 번호로 메시지를 보낼 수 있도록 대화방을 엽니다.)

    public class RcsButtonComposeRecordingMessage : RcsButton
    {
        public string? PhoneNumber { get; set; }

        private RcsButtonComposeRecordingMessage() : base()
        {
            PhoneNumber = null;
            Type = "COM_V";
        }
        public static RcsButtonBuilderComposeRecordingMessage Builder()
        {
            return new RcsButtonBuilderComposeRecordingMessage();

        }
        public class RcsButtonBuilderComposeRecordingMessage
        {
            private readonly RcsButtonComposeRecordingMessage composeRecordingMessageButton;

            public RcsButtonBuilderComposeRecordingMessage()
            {
                composeRecordingMessageButton = new RcsButtonComposeRecordingMessage();
            }

            public RcsButtonBuilderComposeRecordingMessage WithPhoneNumber(string phoneNumber)
            {
                composeRecordingMessageButton.PhoneNumber = phoneNumber;
                return this;
            }

            public RcsButtonBuilderComposeRecordingMessage WithName(string name)
            {
                composeRecordingMessageButton.Name = name;
                return this;
            }

            public RcsButtonComposeRecordingMessage Build()
            {
                return composeRecordingMessageButton;
            }
        }

    }


    // 9.전화 연결 
    public class RcsButtonDialerAction : RcsButton
    {
        public string? PhoneNumber { get; set; }


        private RcsButtonDialerAction() : base()
        {
            PhoneNumber = null;
            Type = "DIAL";
        }

        public static RcsButtonBuilderDialerAction Builder()
        {
            return new RcsButtonBuilderDialerAction();
        }

        public class RcsButtonBuilderDialerAction
        {
            private readonly RcsButtonDialerAction dialerActionButton;

            public RcsButtonBuilderDialerAction()
            {
                dialerActionButton = new RcsButtonDialerAction();
            }

            public RcsButtonBuilderDialerAction WithPhoneNumber(string phoneNumber)
            {
                dialerActionButton.PhoneNumber = phoneNumber;
                return this;
            }

            public RcsButtonDialerAction Build()
            {
                return dialerActionButton;
            }
        }

    }




}