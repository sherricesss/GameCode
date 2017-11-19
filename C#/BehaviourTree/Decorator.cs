using System.Collections.Generic;
using System;

namespace BehaviourTree
{
    public abstract class Decorator : Node
    {
        public Node ChildNode { get; set; }
    }
}
