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
            _q = collection.Builder.DestinationQ;
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
                    _iterator.Reset();
                }
            }
        }
        public List<AbstractNode> GetPath(AbstractNode end)
        {
            List<AbstractNode> _shortestpath = new List<AbstractNode>();
            _shortestpath.Add(end);
            AbstractNode temp = end;
            while (_iterator.PathTable.ContainsKey(temp))
            {
                _shortestpath.Add(_iterator.PathTable[temp]);
                temp = _iterator.PathTable[temp];
            }
            return _shortestpath;
        }
        public void RemoveAll()
        {
            _iterator.Reset();
        }
        public void HighlightPath(AbstractNode end)
        {
            foreach (AbstractNode node in GetPath(end))
            {
                if (node is DestinationNode) continue;
                node.ToPath();
            }
        }
    }
}

