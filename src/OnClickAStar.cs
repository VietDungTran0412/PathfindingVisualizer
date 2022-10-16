﻿using System;
namespace CustomProgram
{
    public class OnClickAStar : IOnClick
    {
        private Client _client;
        public OnClickAStar(Client client)
        {
            _client = client;
        }
        public void Notify()
        {
            MainScene scene = new MainScene(_client);
            scene.GraphTraversal.Iterator = scene.NodeCollection.CreateAStarIterator();
            _client.Scene = scene;
        }
    }
}
