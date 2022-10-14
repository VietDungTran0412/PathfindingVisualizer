using System;
using System.Collections.Generic;
using SplashKitSDK;
namespace CustomProgram
{
    public class AStarSearch:IGetPath
    {
        private AStarIterator _astar;
        private Queue<AbstractNode> _q;
        public AStarSearch(INodeCollection collection)
        {
            _astar = collection.CreateAStarIterator();
            _q = collection.GetDestinationQueue();
        }
        public bool IsEnd()
        {
            if (!_astar.HasNext()) return true;
            return false;
        }
        public void FindPath()
        {
            if(_q.Count == 2)
            {
                _astar.Destination = new List<AbstractNode>(_q.ToArray());
                _astar.AddNode(_q.Peek());
                _astar.Visited.Add(_q.Dequeue());
                //return;
            }

            if (_astar.HasNext())
            {
                AbstractNode temp = _astar.NextNode();
                if (temp == _q.Peek())
                {
                    HighlightPath(temp);
                    _q.Dequeue();
                }
            }
        }
        public void RemoveAll()
        {
            _astar.Reset();
        }
        public void HighlightPath(AbstractNode end)
        {
            foreach(AbstractNode node in _astar.GetPath(end))
            {
                if (node is DestinationNode) continue;
                node.Shape.Color = Color.DeepPink;
            }
        }
    }
}

