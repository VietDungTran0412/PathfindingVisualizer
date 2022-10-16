using System;
using System.Collections.Generic;
using SplashKitSDK;
namespace CustomProgram
{
    public class AStarIterator : NodeIterator
    {
        private DistanceHeap _openHeap;
        private Dictionary<AbstractNode, AbstractNode> _pathTable;
        private HashSet<AbstractNode> _closeSet;
        private Dictionary<AbstractNode, double> _costTable;
        public AStarIterator(Grid grid) : base(grid)
        {
            _openHeap = new DistanceHeap();
            _pathTable = new Dictionary<AbstractNode, AbstractNode>();
            _closeSet = new HashSet<AbstractNode>();
            _costTable = new Dictionary<AbstractNode, double>();
        }
        public override bool HasNext()
        {
            return _openHeap.Size != 0;
        }
        public override void Reset()
        {
            base.Reset();
            _openHeap.Clear();
            _closeSet.Clear();
            _pathTable.Clear();
        }
        private double HCost(AbstractNode node)
        {
            return EuclideanDistance(node,Destinations[1]);
        }
        private double EuclideanDistance(AbstractNode node1, AbstractNode node2)
        {
            double x1 = node1.Position.Row;
            double y1 = node1.Position.Column;
            double x2 = node2.Position.Row;
            double y2 = node2.Position.Column;
            double squareSum = Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2);
            return Math.Pow(squareSum, 0.6);
        }
        public override void AddNode(AbstractNode node)
        {
            if (CanVisit(node))
            {
                AbstractNode start = Destinations[0];
                AbstractNode end = Destinations[1];
                _openHeap.Insert(new DistanceElement(node, EuclideanDistance(start, end), HCost(node)));
            }
        }
        public override AbstractNode NextNode()
        {
            DistanceElement popItem = _openHeap.Delete();
            AbstractNode cur = popItem.Node;
            Highlight(cur);
            _closeSet.Add(cur);
            List<AbstractNode> neighbbors = GetNeighbors(cur);
            foreach(AbstractNode node in neighbbors)
            {               
                if (node is WallNode || _closeSet.Contains(node)) continue;
                double gcost = EuclideanDistance(node, cur) + popItem.GCost;
                if (Visited.Contains(node))
                {
                    if (gcost + HCost(node) >= _costTable[node]) continue;
                    _costTable[node] = gcost + HCost(node);
                    _openHeap.Insert(new DistanceElement(node, gcost, HCost(node)));
                }
                else
                {
                    _costTable.Add(node, gcost + HCost(node));
                    _openHeap.Insert(new DistanceElement(node, gcost, HCost(node)));
                    AddToPathTable(node, cur);
                    Visited.Add(node);
                }
            }
            return cur;
        }
    }
}

