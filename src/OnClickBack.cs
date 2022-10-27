using System;
namespace CustomProgram
{
    // Click back to the menu
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

