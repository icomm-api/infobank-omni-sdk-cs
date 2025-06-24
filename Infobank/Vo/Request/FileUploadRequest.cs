namespace Infobank.Vo.Request
{
    public class FileUploadRequest : MessageRequest
    {

        public string? ServiceType { get; set; }
        public string? MsgType { get; set; }

        public string? FilePath { get; set; }

        private FileUploadRequest()
        {
            this.ServiceType = null;
            this.MsgType = null;
            this.FilePath = null;
        }

        public static FileUploadRequestBuilder Builder()
        {
            return new FileUploadRequestBuilder();
        }


        public class FileUploadRequestBuilder
        {
            private readonly FileUploadRequest fileUploadRequest;

            public FileUploadRequestBuilder()
            {
                fileUploadRequest = new FileUploadRequest();
            }

            public FileUploadRequestBuilder WithServiceType(string serviceType)
            {
                fileUploadRequest.ServiceType = serviceType;
                return this;
            }

            public FileUploadRequestBuilder WithMsgType(string msgType)
            {
                fileUploadRequest.MsgType = msgType;
                return this;
            }

            public FileUploadRequestBuilder WithFilePath(string filePath)
            {
                fileUploadRequest.FilePath = filePath;
                return this;
            }

            public FileUploadRequest Build()
            {
                return fileUploadRequest;
            }
        }

    }
}