using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoubleBuffer
{
	public class DoubleBuffer<T>
    {
        public DoubleBuffer(T buffer0, T buffer1)
        {
            mDoubleBuffer = new T[2];
            mDoubleBuffer[0] = buffer0;
            mDoubleBuffer[1] = buffer1;
        }

        public T FrontBuffer
        {
            get { return mDoubleBuffer[mCurrentIndex]; }
            set { mDoubleBuffer[mCurrentIndex] = value; }
        }

        public T BackBuffer
        {
            get { return mDoubleBuffer[mCurrentIndex ^ 1]; }
            set { mDoubleBuffer[mCurrentIndex ^ 1] = value; }
        }

        public void Swap()
        {
            mCurrentIndex ^= 1;
        }

        private int mCurrentIndex;
        private T[] mDoubleBuffer;
    }
}
