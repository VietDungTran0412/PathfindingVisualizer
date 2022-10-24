using System;
namespace CustomProgram
{
    // If user click on BFS button --> Click behavior is execute to notify client to change to BFS algo
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

