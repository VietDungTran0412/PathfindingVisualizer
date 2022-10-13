using System;
using System.Collections.Generic;
namespace CustomProgram
{
    public class NodePriorityQueue<T>
    {
        private AbstractNode
    }
    public class DistanceQElements
    {
        private AbstractNode _node;
        private double _distance;
        public DistanceQElements(AbstractNode node)
        {
            _node = node;
            _distance = 0;
        }
        public double Distance
        {
            get { return _distance; }
            set { _distance = value; }
        }
        public AbstractNode Node
        {
            get { return _node; }
        }
    }
    public class AStarIterator : NodeIterator
    {
        public AStarIterator()
        {
        }
    }
}

