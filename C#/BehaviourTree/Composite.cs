using System.Collections.Generic;
using System;

namespace BehaviourTree
{
    public abstract class Composite : Node
    {
        public Composite()
        {
            NodeList = new List<Node>();
        }

        public List<Node> NodeList { get; private set; }
    }
}
