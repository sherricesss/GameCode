using System.Collections.Generic;

namespace BehaviourTree
{
    public enum ENodeReturn
    {
        Running = 0,
        Success = 1,
        Failure = 2,
    }

    public abstract class Node
    {
        public Node()
        {
            mIsRunning = false;
        }
        private bool mIsRunning;
        public ENodeReturn Run(BehaviourTree tree)
        {
            if(!mIsRunning)
            {
                OnEnter(tree);
                mIsRunning = true;
            }
            ENodeReturn result = OnUpdate(tree);
            if(result != ENodeReturn.Running)
            {
                OnExit(tree);
                mIsRunning = false;
            }
            return result;
        }
        protected virtual void OnEnter(BehaviourTree tree) { }
        protected virtual void OnExit(BehaviourTree tree) { }
        protected abstract ENodeReturn OnUpdate(BehaviourTree tree);
    }
}
