using System.Collections.Generic;
using System;

namespace BehaviourTree
{
    public sealed class Decorator_Failer : Decorator
    {
        protected override ENodeReturn OnUpdate(BehaviourTree tree)
        {
            ENodeReturn result = ChildNode.Run(tree);
            if(result != ENodeReturn.Running) result = ENodeReturn.Failure;
            return result;
        }
    }
}
