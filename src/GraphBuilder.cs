using System;
using System.Collections.Generic;
using SplashKitSDK;
namespace CustomProgram
{
    // Builder pattern to build the grid or graph by itself
    // Different method will be used for users to customize the grid or graph
    public class GraphBuilder
    {
        private int _size;
        private AbstractNode[,] _graph;
        private Queue<AbstractNode> _destinationQ;
        public GraphBuilder()
        {
            _size = 20;
            _graph = new AbstractNode[_size, _size];
            _destinationQ = new Queue<AbstractNode>();
            Clear();
        }
        public int Size
        {
            get { return _size; }
        }
        public AbstractNode Fetch(Coordinate coordinate) // Fetch the Abstract node in the graph by its coordinate
        {
            if (coordinate.Column < 0 || coordinate.Column >= Size || coordinate.Row >= Size || coordinate.Row < 0)
            {
                return null;
            }
            return Graph[coordinate.Row, coordinate.Column];
        }
        public Queue<AbstractNode> DestinationQ // Get the queue of destinations
        {
            get { return _destinationQ; }
        }
        public AbstractNode[,] Graph
        {
            get { return _graph; }
        }
        public void Clear()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    _graph[i, j] = new NormalNode(_size * 2, new Coordinate(i, j));
                }
            }
            _destinationQ.Clear();
        }
        public void SetRandomMaze() // Set random maze to the graph
        {
            SplashKit.Delay(40); // Deter overclick event when user accidentally click 2 times
            Clear();
            HashSet<string> visited = new HashSet<string>();
            Random rand = new Random();
            for (int i = 0; i < Size * Size; i++)
            {
                if (rand.Next(0, 100) > 60)
                {
                    int row = rand.Next(0, Size);
                    int col = rand.Next(0, Size);
                    if (Graph[row, col] is DestinationNode) continue;
                    if (!visited.Contains($"{row}-{col}"))
                    {
                        Graph[row, col] = new WallNode(Size * 2, new Coordinate(row, col));
                        visited.Add($"{row}-{col}");
                    }
                }
            }
        }
        public void RemoveAt() // Remove at specific position
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (_graph[i, j] is DestinationNode) continue;
                    if (_graph[i, j].Shape.IsAt())
                    {
                        _graph[i, j] = new NormalNode(_size * 2, new Coordinate(i, j));
                    }                    
                }
            }
        }
        public void AddWall() // Add Wall to the graph
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (_graph[i, j].Shape.IsAt())
                    {
                        _graph[i, j] = new WallNode(_size * 2, new Coordinate(i, j));
                    }
                }
            }
        }
        public void AddDestination() // Add destination to the graph
        {
            if (_destinationQ.Count == 2)
            {
                return;
            }
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (_graph[i, j].Shape.IsAt() && _graph[i, j] is NormalNode)
                    {
                        _graph[i, j] = new DestinationNode(_size * 2, new Coordinate(i, j), _destinationQ.Count);
                        _destinationQ.Enqueue(_graph[i, j]);

                    }
                }
            }
        }
        public void Draw() // Draw
        {
            foreach(AbstractNode node in _graph)
            {
                node.Draw();
            }
        }
    }
}

