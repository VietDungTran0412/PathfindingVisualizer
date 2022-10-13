using System;
using System.Collections.Generic;
using SplashKitSDK;
namespace CustomProgram
{
    public abstract class NodeIterator
    {
        private INodeCollection _grid;
        private HashSet<AbstractNode> _visited;
        public NodeIterator(Grid grid)
        {
            _grid = grid;
            _visited = new HashSet<AbstractNode>();
        }
        public bool CanVisit(AbstractNode node)
        {
            if (node is WallNode || _visited.Contains(node)) return false;
            return true;
        }
        public virtual void Reset()
        {
            Visited.Clear();
        }
        public abstract List<AbstractNode> GetPath(AbstractNode end);
        public abstract void AddNode(AbstractNode node);
        public abstract bool HasNext();
        public abstract AbstractNode NextNode();
        public HashSet<AbstractNode> Visited
        {
            get { return _visited; }
        }
        public INodeCollection Grid
        {
            get { return _grid; }
        }
        private void HighlightNeighbors(AbstractNode node)
        {
            if (node is DestinationNode || node is WallNode) return;
            if (!Visited.Contains(node))
            {
                node.Shape.Color = Color.Green;
            }
        }
        public void Highlight(AbstractNode node)
        {
            if (node is DestinationNode) return;
            node.Shape.Color = Color.Blue;
            AbstractNode temp;
            if (Grid.Fetch(GetTop(node)) != null)
            {
                temp = Grid.Fetch(GetTop(node));
                HighlightNeighbors(temp);
            }
            if (Grid.Fetch(GetRight(node)) != null)
            {
                temp = Grid.Fetch(GetRight(node));
                HighlightNeighbors(temp);
            }
            if (Grid.Fetch(GetBottom(node)) != null)
            {
                temp = Grid.Fetch(GetBottom(node));
                HighlightNeighbors(temp);
            }
            if (Grid.Fetch(GetLeft(node)) != null)
            {
                temp = Grid.Fetch(GetLeft(node));
                HighlightNeighbors(temp);
            }
        }
        public Coordinate GetTop(AbstractNode node)
        {
            if (node.Position.Row == 0) return null;
            return new Coordinate(node.Position.Row - 1, node.Position.Column);
        }
        public Coordinate GetBottom(AbstractNode node)
        {
            if (node.Position.Row == _grid.GetSize()) return null;
            return new Coordinate(node.Position.Row + 1, node.Position.Column);
        }
        public Coordinate GetLeft(AbstractNode node)
        {
            if (node.Position.Column == 0) return null;
            return new Coordinate(node.Position.Row, node.Position.Column - 1);
        }
        public Coordinate GetRight(AbstractNode node)
        {
            if (node.Position.Column == _grid.GetSize()) return null;
            return new Coordinate(node.Position.Row , node.Position.Column + 1);
        }
    }

}

