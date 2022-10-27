using System;
namespace CustomProgram
{
    // Click to guidline scene
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

