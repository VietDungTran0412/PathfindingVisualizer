using System;
using System.Collections.Generic;
namespace CustomProgram
{
    // Generate Randome Maze in the Graph
    public class RandomMazeGenerator
    {
        private GraphBuilder _builder;
        private readonly Random _rand;
        private HashSet<string> _visited;
        private IGetNeighbors _neighbors;
        public RandomMazeGenerator(GraphBuilder builder, IGetNeighbors neighbors)
        {
            _builder = builder;
            _neighbors = new GetNeighbors(builder);
            _rand = new Random();
            _visited = new HashSet<string>();
        }
        public void Reset()
        {
            _visited.Clear();
        }
        public void Generate()
        {
            int size = _builder.Size;
            for(int i=0;i<size*size; i++)
            {
                if (_rand.Next(0, 100) > 60)
                {
                    int row = _rand.Next(0, size);
                    int col = _rand.Next(0, size);
                    if (_builder.Graph[row, col] is DestinationNode) continue;
                    if (!_visited.Contains($"{row}-{col}")){
                        _builder.Graph[row, col] = new WallNode(size * 2, new Coordinate(row, col));
                        _visited.Add($"{row}-{col}");
                    }
                }
            }

        }
    }

}

