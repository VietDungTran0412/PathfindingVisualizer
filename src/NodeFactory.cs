using System;
using System.Collections.Generic;
namespace CustomProgram
{
    public class NodeFactory
    {
        private int _size;
        private AbstractNode[,] _graph;
        private Queue<AbstractNode> _destinationQ;
        public NodeFactory()
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

