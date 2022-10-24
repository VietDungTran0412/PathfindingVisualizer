using System;
namespace CustomProgram
{
    // Counter use to customize the annimation speed of traversal
    public class Counter
    {
        private int _count;
        private int _limit;
        public Counter(int init,int limit)
        {
            _count = init;
            _limit = limit;
        }
        // Increase animation speed
        public void IncreaseLimit()
        {
            int edge = 20; // Maximum is 20
            if (_limit >= edge) return;
            _limit += 5;
        }
        // Decrease the animation speed
        public void DecreaseLimit()
        {
            if (_limit == 0) return;
            _limit -= 5;
        }
        // Decrease the counter
        public void Decrease()
        {
            if (_count == 0) return;
            _count -= 1;
        }
        // Reset the counter to limit and count down
        public void Reset()
        {
            _count = _limit;
        }
        public int Tick
        {
            get => _count;
        }
    }
}

