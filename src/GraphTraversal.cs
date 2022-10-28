using System;
using SplashKitSDK;
using System.Collections.Generic;
namespace CustomProgram
{
    // Graph Traversal to control and manage the traversal
    public class GraphTraversal
    {
        private NodeIterator _iterator;
        private Queue<AbstractNode> _q; // Store destination Queue
        public GraphTraversal(INodeCollection collection)
        {
            _iterator = collection.CreateDepthFirstIterator();
            _q = collection.Builder.DestinationQ;
        }
        public NodeIterator Iterator // Public the iterator
        {
            get { return _iterator; }
            set { _iterator = value; }
        }
        public void FindPath() // Find path by looping to every node of the iterator 
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
        public List<AbstractNode> GetPath(AbstractNode end) // Get the shortest path
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
        public void RemoveAll() // Remove all iterator
        {
            _iterator.Reset();
        }
        public void HighlightPath(AbstractNode end)
        {
            foreach (AbstractNode node in GetPath(end))
            {
                node.ToPath();
            }
        }
    }
}

