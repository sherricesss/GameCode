using System.Collections;
using System;

namespace EventSystem
{
	public class StateMachine<D, S> where D : class where S : StateMachine<D, S>.StateBase
    {
        public StateMachine(D owner, S nullState)
        {
            NullState = nullState;
            mOwner = owner;
            mCurrentState = NullState;
            mNewState = NullState;
            mCanChangeState = true;

            OnEnterStateCallback = null;
            OnExitStateCallback = null;
        }

        public Action<S> OnEnterStateCallback;
        public Action<S> OnExitStateCallback;

        private D mOwner;

        private S mCurrentState;
        private S mNewState;
        private bool mCanChangeState;
        public S CurrentState
        {
            set
            {
                mNewState = value;
                if (mCanChangeState)
                {
                    mCanChangeState = false;
                    while (mNewState != NullState)
                    {
                        if (OnExitStateCallback != null) OnExitStateCallback(mCurrentState);
                        mCurrentState.OnExit(mOwner);
                        mCurrentState = mNewState;
                        mNewState = NullState;
                        mCurrentState.OnEnter(mOwner);
                        if(OnEnterStateCallback != null) OnEnterStateCallback(mCurrentState);
                    }
                    mCanChangeState = true;
                }
            }
            get { return mCurrentState; }
        }

        public abstract class StateBase
        {
            public virtual void OnEnter(D button) { }
            public virtual void OnExit(D button) { }
        }


        public S NullState { get; private set; }
    }
}

