using System;
using System.Collections.Generic;
namespace CustomProgram
{
    public class BreadthFirstIterator : NodeIterator
    {
        private Queue<AbstractNode> _q;
        private Dictionary<AbstractNode, AbstractNode> _path;
        public BreadthFirstIterator(Grid grid) : base(grid)
        {
            _q = new Queue<AbstractNode>();
            _path = new Dictionary<AbstractNode, AbstractNode>();
        }
        public override void AddNode(AbstractNode node)
        {
            if (CanVisit(node)) _q.Enqueue(node);
        }
        public override void Reset()
        {
            base.Reset();
            _q.Clear();
            _path.Clear();
        }
        public override bool HasNext()
        {
            return _q.Count != 0;
        }
        private void AddToPathTable(AbstractNode key, AbstractNode val)
        {
            if (Visited.Contains(key)) return;
            if (_path.ContainsKey(key))
            {
                _path[key] = val;
            }
            else
            {
                _path.Add(key, val);
            }
        }
        public override List<AbstractNode> GetPath(AbstractNode end)
        {
            List<AbstractNode> _shortestpath = new List<AbstractNode>();
            _shortestpath.Add(end);
            AbstractNode temp = end;
            while (_path.ContainsKey(temp))
            {
                _shortestpath.Add(_path[temp]);
                temp = _path[temp];
            }
            return _shortestpath;
        }
        public override AbstractNode NextNode()
        {
            if (!HasNext()) return null;
            AbstractNode cur = _q.Dequeue();
            AbstractNode temp;
            Highlight(cur);
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

