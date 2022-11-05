using System;
using System.Collections.Generic;
namespace CustomProgram
{
    public interface IGraphBuilder
    {
        public Queue<AbstractNode> DestinationQ { get; }
        public AbstractNode[,] Graph { get; }
        public void Clear();
        public void SetRandomMaze();
        public void RemoveAt();
        public void AddWall();
        public void AddDestination();
        public AbstractNode Fetch(Coordinate coordinate);
    }
}

