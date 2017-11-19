//#define ENABLE_NO_LISTENER_WARNING_MESSAGE

namespace EventSystem
{
    public class EventSystem
    {
        private Dictionary<int, Item> mListenerDictionary;
        public EventSystem()
        {
            mListenerDictionary = new Dictionary<int, Item>();
        }

        public void AddListener(EventListenerBase listener, int updateRate = 1)
        {
            Item item = null;
            if(mListenerDictionary.ContainsKey(listener.Tag))
            {
                item = mListenerDictionary[listener.Tag];
            }
            else
            {
                item = new Item(updateRate);
                mListenerDictionary.Add(listener.Tag, item);
            }
            item.AddListenner(listener);
        }

        public void RemoveListener(EventListenerBase listener)
        {
            if(mListenerDictionary.ContainsKey(listener.Tag))
            {
                Item item = mListenerDictionary[listener.Tag];
                item.RemoveListener(listener);
            }
        }

        public void TriggerEvnet(EventBase e, EEventCallType type = EEventCallType.Update)
        {
            if (mListenerDictionary.ContainsKey(e.Tag))
            {
                Item item = mListenerDictionary[e.Tag];
                item.AddEvent(e, type);
            }
#if ENABLE_NO_LISTENER_WARNING_MESSAGE
            else
            {
                //UnityEngine.Debug.LogWarning("there is no listener for " + e.Tag);
            }
#endif
        }

        public void Update()
        {
            foreach (var pair in mListenerDictionary)
            {
                pair.Value.Update();
            }
        }

        private class Item
        {
            private List<EventListenerBase> mListenerList;
            private List<EventBase> mEventList;
            public int DefaultUpdateRate;
            public int CurrentUpdateRate;
            private int mUpdateCount;

            public Item(int updateRate)
            {
                DefaultUpdateRate = updateRate;
                CurrentUpdateRate = DefaultUpdateRate;
                mUpdateCount = 0;
                mListenerList = new List<EventListenerBase>();
                mEventList = new List<EventBase>();
            }

            public void AddListenner(EventListenerBase listenner)
            {
                if(!mListenerList.Contains(listenner))
                {
                    mListenerList.Add(listenner);
                }
#if ENABLE_NO_LISTENER_WARNING_MESSAGE
                else
                {
                    //UnityEngine.Debug.LogWarning("there has same listener already been registered");
                }
#endif
            }

            public void RemoveListener(EventListenerBase listener)
            {
                mListenerList.Remove(listener);
            }

            public void AddEvent(EventBase e, EEventCallType type)
            {
                if(type == EEventCallType.Update)
                {
                    mEventList.Add(e);
                }
                else
                {
                    DispatchEvent(e);
                }
            }

            public void Update()
            {
                if(mUpdateCount >= CurrentUpdateRate)
                {
                    mUpdateCount = 0;
                    for(int i = 0; i < mEventList.Count; ++i)
                    {
                        DispatchEvent(mEventList[i]);
                    }
                    mEventList.Clear();
                }
                else
                {
                    ++mUpdateCount;
                }
            }

            private void DispatchEvent(EventBase e)
            {
                for(int i = 0;i < mListenerList.Count; ++i)
                {
                    mListenerList[i].CatchEvent(e);
                }
            }
        }
    }
}
