using System.Collections.Generic;
using System;

namespace BehaviourTree
{
    public sealed class Decorator_RepeatUntilFail : Decorator
    {
        protected override ENodeReturn OnUpdate(BehaviourTree tree)
        {
            ENodeReturn result = ChildNode.Run(tree);
            if(result == ENodeReturn.Success) result = ENodeReturn.Running;
            return result;
        }
    }
}
