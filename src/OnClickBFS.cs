using System;
namespace CustomProgram
{
    public class OnClickBFS : IOnClick
    {
        private Client _client;
        public OnClickBFS(Client client)
        {
            _client = client;
        }
        public void Notify()
        {
            MainScene scene = new MainScene(_client);
            scene.GraphTraversal.Iterator = scene.NodeCollection.CreateBreadthFirstIterator();
            _client.Scene = scene;
        }
    }
}

