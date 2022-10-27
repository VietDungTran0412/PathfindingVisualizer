using System;
using System.Collections.Generic;
using SplashKitSDK;
namespace CustomProgram
{
    // Iterator pattern used to traverse through the node collection using specific algorithm like DFS,BFS and AStar
    public abstract class NodeIterator
    {
        private INodeCollection _grid;
        private Dictionary<AbstractNode, AbstractNode> _pathTable; // Path table to check which node is came from --> to find shortest path
        private HashSet<AbstractNode> _visited; // Store visited node
        private List<AbstractNode> _destinations; // Store destination
        protected IGetNeighbors _neighbors;
        public NodeIterator(INodeCollection grid)
        {
            _grid = grid;
            _visited = new HashSet<AbstractNode>();
            _pathTable = new Dictionary<AbstractNode, AbstractNode>();
            _destinations = new List<AbstractNode>();
            _neighbors = new GetNeighbors(grid.Builder);
        }
        public List<AbstractNode> Destinations // List of Destination or checkpoint, last index will be the last checkpoint
        {
            get { return _destinations; }
            set { _destinations = value; }
        }
        // Get the path from path table which store the previos traversal node
        public Dictionary<AbstractNode,AbstractNode> PathTable
        {
            get => _pathTable;
        }
        // Add to the path table to store the node where it comes from
        public void AddToPathTable(AbstractNode key, AbstractNode from)
        {
            if (Visited.Contains(key)) return;
            if (_pathTable.ContainsKey(key))
            {
                _pathTable[key] = from;
            }
            else
            {
                _pathTable.Add(key, from);
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
        public void Highlight(AbstractNode node) // Highlight the current node and its neighbor
        {
            node.Shape.Color = Color.RGBColor(34,211,242);
            if (node is DestinationNode) node.Shape.Color = node.GetColor();
            foreach (AbstractNode item in _neighbors.Get(node))
            {
                if(item is DestinationNode || item is WallNode || Visited.Contains(item))
                {
                    continue;
                }
                item.Shape.Color = Color.RGBColor(90,149,237);
            }
        }
        public abstract void AddNode(AbstractNode node); // Add node the specific data structure of iterator
        public abstract bool HasNext(); // Check if is there any node left
        public abstract AbstractNode NextNode(); // Return the next node from traverse process
    }

}

