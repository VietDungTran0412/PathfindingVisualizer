using System;
using SplashKitSDK;
using System.Collections.Generic;
namespace CustomProgram
{
    public class GraphTraversal
    {
        private NodeIterator _iterator;
        private Queue<AbstractNode> _q;
        public GraphTraversal(INodeCollection collection)
        {
            _iterator = collection.CreateDepthFirstIterator();
            _q = collection.DestinationQueue;
        }
        public NodeIterator Iterator
        {
            get { return _iterator; }
            set { _iterator = value; }
        }
        public bool IsEnd()
        {
            if (!_iterator.HasNext()) return true;
            return false;
        }
        public void FindPath()
        {
            if (_q.Count == 2)
            {
                _iterator.Destinations = new List<AbstractNode>(_q.ToArray());
                _iterator.AddNode(_q.Peek());
                _iterator.Visited.Add(_q.Dequeue());
            }
            if (_iterator.HasNext())
            {
                AbstractNode temp = _iterator.NextNode();
                if (temp == _q.Peek())
                {
                    HighlightPath(temp);
                    _q.Dequeue();
                }
            }
        }
        public void RemoveAll()
        {
            _iterator.Reset();
        }
        public void HighlightPath(AbstractNode end)
        {
            foreach (AbstractNode node in _iterator.GetPath(end))
            {
                if (node is DestinationNode) continue;
                node.ToPath();
            }
        }
    }
}

