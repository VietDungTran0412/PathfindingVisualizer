using System;
using System.Collections.Generic;
namespace CustomProgram
{
    public interface INodeCollection
    {
        public int GetSize();
        public void Reset();
        public Queue<AbstractNode> GetDestinationQueue();
        public NodeIterator CreateDepthFirstIterator();
        public NodeIterator CreateBreadthFirstIterator();
        public AbstractNode Fetch(Coordinate coordinate);
        public void UpdateScreen();
    }

}

