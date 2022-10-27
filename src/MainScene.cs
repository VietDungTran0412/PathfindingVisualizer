﻿using System;
using SplashKitSDK;
using System.Collections.Generic;
namespace CustomProgram
{
    public class MainScene:IScene
    {
        private INodeCollection _collection;
        private GraphTraversal _graphTraversal;
        private bool _running;
        private IOnClick _click;
        private Counter _count;
        public MainScene(IOnClick click)
        {
            _collection = new Grid(new GraphBuilder());
            _graphTraversal = new GraphTraversal(_collection);
            _running = false;
            _click = click;
            _count = new Counter(5,5);
        }
        public INodeCollection NodeCollection
        {
            get { return _collection; }
        }
        public Color GetBackgroundColor()
        {
            return Color.Black;
        }
        public GraphTraversal GraphTraversal
        {
            get { return _graphTraversal; }
            set { _graphTraversal = value; }
        }
        public void Display()
        {
            _collection.UpdateEvent(_running);
            if(SplashKit.KeyDown(KeyCode.QKey) && _collection.Builder.DestinationQ.Count == 2)
            {
                _running = true;
            }
            if (SplashKit.KeyDown(KeyCode.RKey)) _graphTraversal.RemoveAll();
            if (SplashKit.KeyTyped(KeyCode.EqualsKey)) _count.DecreaseLimit();
            if (SplashKit.KeyTyped(KeyCode.MinusKey)) _count.IncreaseLimit();
            if (_running)
            {
                if (_count.Tick == 0)
                {
                    GraphTraversal.FindPath();
                    _count.Reset();
                }
                _count.Decrease();
            }
            if(_collection.Builder.DestinationQ.Count == 0 || _graphTraversal.IsEnd())
            {
                _running = false;
            }
            if (SplashKit.KeyDown(KeyCode.EscapeKey))
            {
                _click.Notify();
            }
        }
    }
}

