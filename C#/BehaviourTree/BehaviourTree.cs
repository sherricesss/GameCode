using System.Collections.Generic;
using System;

namespace BehaviourTree
{
    public sealed class BehaviourTree : Node
    {
        public BehaviourTree()
        {
            _SharedData = new Dictionary<int, object>();
        }
        public void Run()
        {
            Run(this);
        }
        public T GetTarget<T>()
        {
            return (T)Target;
        }

        protected override ENodeReturn OnUpdate(BehaviourTree tree)
        {
            ENodeReturn rt = RootNode.Run(tree);
            return rt;
        }

        public void AddSharedData(int key, object value)
        {
            if(_SharedData.ContainsKey(key))
            {
                _SharedData[key] = value;
            }
            else
            {
                _SharedData.Add(key, value);
            }
        }

        public Node RootNode { get; set; }
        public object Target { get; set; }
        public Dictionary<int, object> _SharedData { get; private set; }
    }
}
