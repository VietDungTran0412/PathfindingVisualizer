using System;
using System.Collections.Generic;
using SplashKitSDK;
namespace CustomProgram
{
    public abstract class NodeIterator
    {
        private INodeCollection _grid;
        private Dictionary<AbstractNode, AbstractNode> _pathTable;
        private HashSet<AbstractNode> _visited;
        private List<AbstractNode> _destinations;
        public NodeIterator(INodeCollection grid)
        {
            _grid = grid;
            _visited = new HashSet<AbstractNode>();
            _pathTable = new Dictionary<AbstractNode, AbstractNode>();
            _destinations = new List<AbstractNode>();
        }
        public List<AbstractNode> Destinations
        {
            get { return _destinations; }
            set { _destinations = value; }
        }
        public List<AbstractNode> GetPath(AbstractNode end)
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
        public void AddToPathTable(AbstractNode key, AbstractNode val)
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
        public bool CanVisit(AbstractNode node)
        {
            if (node is WallNode || _visited.Contains(node)) return false;
            return true;
        }
        public virtual void Reset()
        {
            Visited.Clear();
            _pathTable.Clear();
            Destinations.Clear();
        }
        public HashSet<AbstractNode> Visited
        {
            get { return _visited; }
        }
        public void Highlight(AbstractNode node)
        {
            node.Shape.Color = Color.RGBColor(34,211,242);
            if (node is DestinationNode) node.Shape.Color = node.GetColor();
            foreach (AbstractNode item in GetNeighbors(node))
            {
                if(item is DestinationNode || item is WallNode || Visited.Contains(item))
                {
                    continue;
                }
                item.Shape.Color = Color.RGBColor(90,149,237);
            }
        }
        public List<AbstractNode> GetNeighbors(AbstractNode node)
        {
            AbstractNode temp;
            List<AbstractNode> neighbors = new List<AbstractNode>();
            temp = _grid.Fetch(new Coordinate(node.Position.Row - 1, node.Position.Column));
            if (temp != null) neighbors.Add(temp);
            temp = _grid.Fetch(new Coordinate(node.Position.Row, node.Position.Column + 1));
            if (temp != null) neighbors.Add(temp);
            temp = _grid.Fetch(new Coordinate(node.Position.Row + 1, node.Position.Column));
            if (temp != null) neighbors.Add(temp);
            temp = _grid.Fetch(new Coordinate(node.Position.Row, node.Position.Column - 1));
            if (temp != null) neighbors.Add(temp);
            return neighbors;
        }
        public abstract void AddNode(AbstractNode node);
        public abstract bool HasNext();
        public abstract AbstractNode NextNode();
    }

}

