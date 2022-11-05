using System;
using System.Collections.Generic;
namespace CustomProgram
{
    // Public interface INodeCollection control the graph of node
    public interface INodeCollection
    {
        public IGraphBuilder Builder { get; }
        public void Reset();
        public NodeIterator CreateDepthFirstIterator();
        public NodeIterator CreateBreadthFirstIterator();
        public NodeIterator CreateAStarIterator();
        public void UpdateEvent(bool running);
    }

}

