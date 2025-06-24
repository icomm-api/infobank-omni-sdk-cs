using Infobank.Vo;
using System;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;

namespace Infobank.Messaging
{
    public class MessageService 
    {
        protected readonly HttpClient _client;
        protected readonly string _baseUrl;

        public MessageService(HttpClient client, string baseUrl)
        {
            _client = client;
            _baseUrl = baseUrl;
        }

    }
}
