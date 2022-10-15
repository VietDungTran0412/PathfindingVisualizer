using System;
using System.Collections.Generic;
using SplashKitSDK;
namespace CustomProgram
{
    public class BreadthFirstSearch : IGraphTraversal
    {
        private NodeIterator _bfiterator;
        private Queue<AbstractNode> _q;
        public BreadthFirstSearch(INodeCollection collection)
        {
            _bfiterator = collection.CreateBreadthFirstIterator();
            _q = collection.GetDestinationQueue();
        }
        public bool IsEnd()
        {
            if (!_bfiterator.HasNext()) return true;
            return false;
        }
        public void FindPath()
        {
            if (_q.Count == 2)
            {
                _bfiterator.AddNode(_q.Peek());
                _bfiterator.Visited.Add(_q.Dequeue());
            }

            if (_bfiterator.HasNext())
            {
                AbstractNode temp = _bfiterator.NextNode();
                // Get the destination
                if (temp == _q.Peek())
                {
                    HighlightPath(temp);
                    _q.Dequeue();
                }
            }
        }
        public void RemoveAll()
        {
            _bfiterator.Reset();
        }
        public void HighlightPath(AbstractNode end)
        {
            List<AbstractNode> path = _bfiterator.GetPath(end);
            foreach(AbstractNode node in path)
            {
                if (node is DestinationNode) continue;
                node.ToPath();
            }
        }
    }
}

