using System;
using System.Collections.Generic;
namespace CustomProgram
{
    public interface IGetNeighbors
    {
        public List<AbstractNode> Get(AbstractNode cur);
    }
}

