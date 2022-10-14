using System;
namespace CustomProgram
{
    public class DistanceElement
    {
        private AbstractNode _node;
        private double _distance;
        public DistanceElement(AbstractNode node,double distance)
        {
            _node = node;
            _distance = distance;
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
}

