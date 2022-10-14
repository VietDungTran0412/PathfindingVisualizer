﻿using System;
using System.Collections.Generic;
namespace CustomProgram
{
    public class DistanceHeap
    {
        private List<DistanceElement> _elements;
        private int _size;
        private int _capacity;
        public DistanceHeap(int capacity)
        {
            _size = 0;
            _elements = new List<DistanceElement>();
            _capacity = capacity;
        }
        private int Father(int pos)
        {
            if (pos <= 0 || pos >= Size) return -1;
            int father = (pos - 1) / 2;
            return father;
        }
        private int LeftChild(int pos)
        {
            int left = 2 * pos + 1;
            if (left >= Size) return -1;
            return left;
        }
        private int RightChild(int pos)
        {
            int right = 2 * pos + 2;
            if (right >= Size) return -1;
            return right;
        }
        public void Clear()
        {
            _elements.Clear();
            Size = 0;
        }
        private void Swap(int pos1, int pos2)
        {
            DistanceElement temp = _elements[pos1];
            _elements[pos1] = _elements[pos2];
            _elements[pos2] = temp;
        }
        public void HeapifyDown(int pos)
        {
            int l = LeftChild(pos);
            int r = RightChild(pos);
            int minPos;
            if(l != -1 && _elements[l].Distance < _elements[pos].Distance)
            {
                minPos = l;
            }
            else
            {
                minPos = pos;
            }
            if(r!=-1 && _elements[r].Distance < _elements[minPos].Distance)
            {
                minPos = r;
            }
            if(minPos != pos)
            {
                Swap(pos, minPos);
                HeapifyDown(minPos);
            }
        }
        public DistanceElement Delete()
        {
            if (Size == 0) return null;
            DistanceElement temp = _elements[0];
            Swap(0, Size - 1);
            _elements.RemoveAt(Size - 1);
            Size -= 1;
            HeapifyDown(0);
            return temp;
        }
        public void Insert(DistanceElement data)
        {
            _elements.Add(data);
            Size += 1;
            int i = Size - 1;
            while (i != 0)
            {
                int father = Father(i);
                if (_elements[i].Distance < _elements[father].Distance)
                {
                    Swap(i, father);
                    i = father;
                }
                else
                {
                    break;
                }
            }
        }
        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }
        public int Capacity
        {
            get { return _capacity; }
        }
    }
}

