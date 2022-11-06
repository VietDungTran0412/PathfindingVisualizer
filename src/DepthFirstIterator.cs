using System;
using System.Collections.Generic;
using SplashKitSDK;
namespace CustomProgram
{
    // Depth First Iterator to traverse through node collection using Depth First Search Algorithm
    public class DepthFirstIterator : NodeIterator
    {
        private Stack<AbstractNode> _st; // Stack data structure to store node
        public DepthFirstIterator(Grid grid):base(grid)
        {
            _st = new Stack<AbstractNode>();
        }
        public override void AddNode(AbstractNode node)
        {
            if (CanVisit(node))
            {
                _st.Push(node);
            }
        }
        public override bool HasNext()
        {
            return _st.Count != 0;
        }
        public override void Reset()
        {
            base.Reset();
            _st.Clear();
        }
        public override AbstractNode NextNode()
        {
            AbstractNode cur = _st.Pop();
            Highlight(cur);
            List<AbstractNode> neighbors = GetNeighbors(cur);
            foreach(AbstractNode node in neighbors)
            {
                AddNode(node);
                AddToPathTable(node, cur);
                Visited.Add(node);
            }
            return cur;
        }
    }
}

