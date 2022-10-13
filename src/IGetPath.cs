using System;
namespace CustomProgram
{
    public interface IGetPath
    {
        public void FindPath();
        public void HighlightPath(AbstractNode end);
        public bool IsEnd();
        public void RemoveAll();
    }
}

