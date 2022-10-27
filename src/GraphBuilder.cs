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
        private RandomMazeGenerator _generator;
        public GraphBuilder()
        {
            _size = 20;
            _graph = new AbstractNode[_size, _size];
            _destinationQ = new Queue<AbstractNode>();
            Clear();
            _generator = new RandomMazeGenerator(this, new GetNeighbors(this));
        }
        public int Size
        {
            get { return _size; }
        }
        public AbstractNode Fetch(Coordinate coordinate)
        {
            if (coordinate.Column < 0 || coordinate.Column >= Size || coordinate.Row >= Size || coordinate.Row < 0)
            {
                return null;
            }
            return Graph[coordinate.Row, coordinate.Column];
        }
        public Queue<AbstractNode> DestinationQ
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
        public void SetRandomMaze()
        {
            SplashKit.Delay(40);
            Clear();
            _generator.Reset();
            _generator.Generate();
        }
        public void RemoveAt()
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
        public void AddWall()
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
        public void AddDestination()
        {
            if (_destinationQ.Count == 2) return;
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
        public void Draw()
        {
            foreach(AbstractNode node in _graph)
            {
                node.Draw();
            }
        }
    }
}

