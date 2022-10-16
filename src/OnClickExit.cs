using System;
namespace CustomProgram
{
    public class OnClickExit:IOnClick
    {
        private Client _client;
        public OnClickExit(Client client)
        {
            _client = client;
        }
        public void Notify()
        {
            _client.Close();
        }
    }
}

