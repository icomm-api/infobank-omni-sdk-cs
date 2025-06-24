using Infobank.Vo;
using Infobank.Vo.Response;

namespace Infobank.Messaging
{
    public interface IMessageService
    {
        public bool Init();

        public ApiResponse? SendRequest<T>(T message);
        public ApiResponse? SendRequest();

        public string?  GetSendJsonData<T> (T message);

    }
}
