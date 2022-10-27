using System;
using System.Collections.Generic;
namespace CustomProgram
{
    // Breadth First Iterator to traverse through node collection  using Breadth First Search Algorithm
    public class BreadthFirstIterator : NodeIterator
    {
        private Queue<AbstractNode> _q; // Specific Data Structure to store nodes
        public BreadthFirstIterator(Grid grid) : base(grid)
        {
            _q = new Queue<AbstractNode>();
        }
        public override void AddNode(AbstractNode node)
        {
            if (CanVisit(node)) _q.Enqueue(node);
        }
        public override void Reset()
        {
            base.Reset();
            _q.Clear();
        }
        public override bool HasNext()
        {
            return _q.Count != 0;
        }
        public override AbstractNode NextNode()
        { 
            AbstractNode cur = _q.Dequeue();
            Highlight(cur);
            List<AbstractNode> neighbors = GetNeighbors(cur);
            foreach(AbstractNode node in neighbors)
            {
                AddNode(node);
                AddToPathTable(node,cur);
                Visited.Add(node);
            }
            return cur;
        }
    }
}

