using System;
using System.Collections.Generic;
using SplashKitSDK;
namespace CustomProgram
{
    public class DepthFirstIterator : NodeIterator
    {
        private Stack<AbstractNode> _st;
        private List<AbstractNode> _path;
        public DepthFirstIterator(Grid grid):base(grid)
        {
            _st = new Stack<AbstractNode>();
            _path = new List<AbstractNode>();
        }
        public override void AddNode(AbstractNode node)
        {
            if(CanVisit(node)) _st.Push(node); 
        }
        public override bool HasNext()
        {
            return _st.Count != 0;
        }
        public override void Reset()
        {
            base.Reset();
            _path.Clear();
            _st.Clear();
        }
        public override List<AbstractNode> GetPath(AbstractNode end)
        {
            return _path;
        }
        public override AbstractNode NextNode()
        {
            AbstractNode cur = _st.Pop();
            _path.Add(cur);
            
            AbstractNode temp;
            if (Grid.Fetch(GetTop(cur)) != null)
            {
                temp = Grid.Fetch(GetTop(cur));
                AddNode(temp);
                Visited.Add(cur); 
            }
            if (Grid.Fetch(GetRight(cur)) != null)
            {
                temp = Grid.Fetch(GetRight(cur));
                AddNode(temp);
                Visited.Add(cur);
            }
            if (Grid.Fetch(GetBottom(cur)) != null)
            {
                temp = Grid.Fetch(GetBottom(cur));
                AddNode(temp);
                Visited.Add(cur);
            }
            if (Grid.Fetch(GetLeft(cur)) != null)
            {
                temp = Grid.Fetch(GetLeft(cur));
                AddNode(temp);
                Visited.Add(cur);
            }
            Highlight(cur);
            return cur;
        }
    }
}

