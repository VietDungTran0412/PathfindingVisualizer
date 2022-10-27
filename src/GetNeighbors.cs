using System;
using System.Collections.Generic;
namespace CustomProgram
{
    // Get neighbors Strategy applying strategy pattern
    public class GetNeighbors : IGetNeighbors
    {
        private GraphBuilder _builder;
        public GetNeighbors(GraphBuilder builder)
        {
            _builder = builder;
        }
        public List<AbstractNode> Get(AbstractNode node)
        {
            List<AbstractNode> neighbors = new List<AbstractNode>();
            AbstractNode temp;
            temp = _builder.Fetch(new Coordinate(node.Position.Row-1, node.Position.Column));
            if (temp != null) neighbors.Add(temp);
            temp = _builder.Fetch(new Coordinate(node.Position.Row, node.Position.Column+1));
            if (temp != null) neighbors.Add(temp);
            temp = _builder.Fetch(new Coordinate(node.Position.Row+1, node.Position.Column));
            if (temp != null) neighbors.Add(temp);
            temp = _builder.Fetch(new Coordinate(node.Position.Row, node.Position.Column-1));
            if (temp != null) neighbors.Add(temp);
            return neighbors;
        }
    }
}

