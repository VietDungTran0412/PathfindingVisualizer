using System;
using SplashKitSDK;
using System.Collections.Generic;
namespace CustomProgram
{
    public class DepthFirstSearch : IGraphTraversal
    {
        private NodeIterator _dfiterator;
        private Queue<AbstractNode> _q;
        public DepthFirstSearch(INodeCollection collection)
        {
            _dfiterator = collection.CreateDepthFirstIterator();
            _q = collection.GetDestinationQueue();
        }
        public bool IsEnd()
        {
            if (!_dfiterator.HasNext()) return true;
            return false;
        }
        public void FindPath()
        {
            if (_q.Count == 2)
            {
                _dfiterator.AddNode(_q.Peek());
                _dfiterator.Visited.Add(_q.Dequeue());
            }
            if (_dfiterator.HasNext())
            {
                AbstractNode temp = _dfiterator.NextNode();
                if (temp == _q.Peek())
                {
                    HighlightPath(temp);
                    _q.Dequeue();
                }
            }
        }
        public void RemoveAll()
        {
            _dfiterator.Reset();
        }
        public void HighlightPath(AbstractNode end)
        {
            foreach (AbstractNode node in _dfiterator.GetPath(end))
            {
                if (node is DestinationNode) continue;
                node.ToPath();
            }
        }
    }
}

