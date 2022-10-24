using System;
using SplashKitSDK;
namespace CustomProgram
{
    // If user click on DFS button --> Click behavior is execute to notify client to change to DFS algo
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

