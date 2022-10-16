using System;
using SplashKitSDK;
namespace CustomProgram
{
    public class OnClickDFS : IOnClick
    {
        private Client _client;
        public OnClickDFS(Client client)
        {
            _client = client;
        }
        public void Notify()
        {
            MainScene scene = new MainScene(_client);
            scene.GraphTraversal.Iterator = scene.NodeCollection.CreateDepthFirstIterator();
            _client.Scene = scene;
        }
    }
}

