using System;
namespace CustomProgram
{
    public class OnClickGuidline:IOnClick
    {
        private Client _client;
        public OnClickGuidline(Client client)
        {
            _client = client;
        }
        public void Notify()
        {
            _client.Scene = new GuidlineScene(_client, "Guidlines");
        }
    }
}

