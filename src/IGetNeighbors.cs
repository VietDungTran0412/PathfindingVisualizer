using System;
using System.Collections.Generic;
namespace CustomProgram
{
    // Get neighbors Strategy applying strategy pattern
    public interface IGetNeighbors
    {
        public List<AbstractNode> Get(AbstractNode cur);
    }
}

