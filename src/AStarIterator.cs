using System;
using System.Collections.Generic;
using SplashKitSDK;
namespace CustomProgram
{

    public class AStarIterator : NodeIterator
    {
        private DistanceHeap _heap;
        private List<AbstractNode> _destination;
        private Dictionary<AbstractNode, AbstractNode> _pathTable;
        public AStarIterator(Grid grid):base(grid)
        {
            int total = grid.GetSize() * grid.GetSize();
            _heap = new DistanceHeap(total);
            _destination = new List<AbstractNode>(2);
            _pathTable = new Dictionary<AbstractNode, AbstractNode>();
        }
        private void AddToPathTable(AbstractNode key, AbstractNode val)
        {
            if (Visited.Contains(key)) return;
            if (_pathTable.ContainsKey(key))
            {
                _pathTable[key] = val;
            }
            else
            {
                _pathTable.Add(key, val);
            }
        }
        public override void AddNode(AbstractNode node)
        {
            if (CanVisit(node))
            {
                double GCost = ManhatanDistance(node, _destination[0]);
                double HCost = ManhatanDistance(node, _destination[1]);
                double FCost = GCost + HCost;
                _heap.Insert(new DistanceElement(node, FCost));
            }
        }
        public List<AbstractNode> Destination
        {
            get { return _destination; }
            set { _destination = value; }
        }
        public override bool HasNext()
        {
            return _heap.Size != 0;
        }
        public override void Reset()
        {
            base.Reset();
            _destination.Clear();
            _pathTable.Clear();
            _heap.Clear();
        }
        public override List<AbstractNode> GetPath(AbstractNode end)
        {
            List<AbstractNode> _shortestpath = new List<AbstractNode>();
            _shortestpath.Add(end);
            AbstractNode temp = end;
            while (_pathTable.ContainsKey(temp))
            {
                _shortestpath.Add(_pathTable[temp]);
                temp = _pathTable[temp];
            }
            return _shortestpath;
        }
        private double ManhatanDistance(AbstractNode node1, AbstractNode node2)
        {
            int x1 = node1.Position.Row;
            int y1 = node1.Position.Column;
            int x2 = node2.Position.Row;
            int y2 = node2.Position.Column;
            double squareSum = Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2);
            return Math.Pow(squareSum, 0.5);
        }
        public override AbstractNode NextNode()
        {
            AbstractNode cur = _heap.Delete().Node;
            Highlight(cur);
            AbstractNode temp;
            if (Grid.Fetch(GetTop(cur)) != null)
            {
                temp = Grid.Fetch(GetTop(cur));
                AddNode(temp);
                AddToPathTable(temp, cur);
                Visited.Add(temp);
            }
            if (Grid.Fetch(GetRight(cur)) != null)
            {
                temp = Grid.Fetch(GetRight(cur));
                AddNode(temp);
                AddToPathTable(temp, cur);
                Visited.Add(temp);
            }
            if (Grid.Fetch(GetBottom(cur)) != null)
            {
                temp = Grid.Fetch(GetBottom(cur));
                AddNode(temp);
                AddToPathTable(temp, cur);
                Visited.Add(temp);
            }
            if (Grid.Fetch(GetLeft(cur)) != null)
            {
                temp = Grid.Fetch(GetLeft(cur));
                AddNode(temp);
                AddToPathTable(temp, cur);
                Visited.Add(temp);
            }
            return cur;
        }
    }
}

