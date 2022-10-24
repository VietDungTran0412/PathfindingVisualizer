using System;
namespace CustomProgram
{
    // Strategy pattern for different On Click Action
    public interface IOnClick
    {
        // Observer pattern to notify the client to change the scene
        public void Notify();
    }
}

