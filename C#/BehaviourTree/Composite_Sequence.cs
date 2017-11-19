using System.Collections.Generic;
using System;

namespace BehaviourTree
{
    public sealed class Composite_Sequence : Composite
    {
        protected override void OnEnter(BehaviourTree tree)
        {
            mCurrentNodeIndex = 0;
        }
        protected override void OnExit(BehaviourTree tree)
        {
            mCurrentNodeIndex = 0;
        }

        private int mCurrentNodeIndex;

        protected override ENodeReturn OnUpdate(BehaviourTree tree)
        {
            ENodeReturn result = ENodeReturn.Success;
            while(mCurrentNodeIndex < NodeList.Count)
            {
                result = NodeList[mCurrentNodeIndex].Run(tree);
                if(ENodeReturn.Success != result)
                {
                    break;
                }
                else
                {
                    mCurrentNodeIndex++;
                }
            }
//             if(mCurrentNodeIndex >= NodeList.Count)
//             {
//                 result = ENodeReturn.Success;
//             }
//             else
//             {
//                 result = NodeList[mCurrentNodeIndex].Run(tree);
//                 if(ENodeReturn.Success == result)
//                 {
//                     mCurrentNodeIndex++;
//                     result = ENodeReturn.Running;
//                 }
//             }
            return result;
        }
    }
}
