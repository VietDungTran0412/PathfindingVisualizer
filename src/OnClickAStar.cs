using System;
namespace CustomProgram
{
    // If user click on AStar button --> Click behavior is execute to notify client to change to AStar
    public class OnClickAStar : IOnClick
    {
        private Client _client;
        public OnClickAStar(Client client)
        {
            _client = client;
        }
        public void Notify()
        {
            MainScene scene = new MainScene(new OnClickBack(_client));
            scene.GraphTraversal.Iterator = scene.NodeCollection.CreateAStarIterator();
            _client.Scene = scene;
        }
    }
}

