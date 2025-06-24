
using Newtonsoft.Json;
using Infobank.Vo.Response;

namespace Infobank.Vo.Response
{
    public class ReportData
    {
        [JsonProperty("reportId")]
        public string? RepotId { get; set; }

        [JsonProperty("report")]
        public List<Report>? ReportDataList { get; set; }

        public ReportData()
        {
            RepotId = null;
            ReportDataList = null;
        }

        public override string ToString()
        {
            string result = "";
            result += $"reportId: {RepotId ?? "null"}, " +
               $"reportCnt: {ReportDataList?.Count.ToString() ?? "null"} ";

            if (ReportDataList is not null)
            {
                foreach (var report in ReportDataList)
                {
                    result += report.ToString() + "\n";
                }
            }
            return result;
        }


    }

    public class Report
    {

        [JsonProperty("msgKey")]
        public string? MsgKey { get; set; }

        [JsonProperty("serviceType")]
        public string? ServiceType { get; set; }

        [JsonProperty("msgType")]
        public string? MsgType { get; set; }

        [JsonProperty("sendTime")]
        public string? SendTime { get; set; }

        [JsonProperty("reportTime")]
        public string? ReportTime { get; set; }

        [JsonProperty("reportType")]
        public string? ReportType { get; set; }

        [JsonProperty("reportCode")]
        public string? ReportCode { get; set; }

        [JsonProperty("reportText")]
        public string? ReportText { get; set; }

        [JsonProperty("carrier")]
        public string? Carrier { get; set; }
        
        [JsonProperty("userType")]
        public string? UserType { get; set; }

        [JsonProperty("resCnt")]
        public string? ResCnt { get; set; }

        [JsonProperty("ref")]
        public string? Ref { get; set; }

        public Report()
        {
            this.MsgKey = null;
            this.ServiceType = null;
            this.MsgType = null;
            this.ReportType = null;
            this.ReportCode = null;
            this.ReportTime = null;
            this.Carrier = null;
            this.UserType = null;
            this.ReportText = null;
            this.ResCnt = null;
            this.Ref = null;

        }


        public override string ToString()
        {
            return $"MsgKey: {MsgKey ?? "null"}, " +
                   $"ServiceType: {ServiceType ?? "null"}, " +
                   $"MsgType: {MsgType ?? "null"}, " +
                   $"ReportType: {ReportType ?? "null"}, " +
                   $"ReportCode: {ReportCode ?? "null"}, " +
                   $"ReportTime: {ReportTime ?? "null"}, " +
                   $"Carrier: {Carrier ?? "null"}, " +
                   $"UserType: {UserType ?? "null"}, " +
                   $"ResCnt: {ResCnt ?? "null"}, " +
                   $"ReportText: {ReportText ?? "null"}, " +
                   $"Ref: {Ref ?? "null"}";
        }

    }
    public class ReportPollingResponse : ApiResponse
    {
        [JsonProperty("data")]
        public ReportData? Data { get; set; }

        public ReportPollingResponse() : base()
        {
            this.Data = null;
        }

        public override string ToString()
        {
            return $"Code: {Code ?? "null"}, result:{Result ?? "null"}, Data:{Data?.ToString() ?? "null"}";
        }

    }

}