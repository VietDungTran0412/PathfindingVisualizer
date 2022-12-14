using System;
namespace CustomProgram
{
    // Distance element to store node and its distance like gcost, hcost and fcost.
    // Only use to store data and does not getting involve in the architecture
    public class DistanceElement
    {
        private AbstractNode _node;
        private double _gcost;
        private double _hcost;
        public DistanceElement(AbstractNode node, double gcost, double hcost)
        {
            _node = node;
            _gcost = gcost;
            _hcost = hcost;
        }
        public double GCost
        {
            get { return _gcost; }
            set { _gcost = value; }
        }
        public double HCost
        {
            get { return _hcost; }
            set { _hcost = value; }
        }
        public AbstractNode Node
        {
            get { return _node; }
        }
        public double FCost
        {
            get { return GCost + HCost; }
        }
    }
}

