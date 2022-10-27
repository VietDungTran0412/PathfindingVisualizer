using System;
namespace CustomProgram
{
    public class OnClickBack:IOnClick
    {
        private readonly Client _client;
        public OnClickBack(Client client)
        {
            _client = client;
        }
        public void Notify()
        {
            _client.Scene = new MenuScene(_client);
        }
    }
}

