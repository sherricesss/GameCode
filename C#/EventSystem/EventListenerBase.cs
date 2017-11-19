namespace EventSystem
{
    public abstract class EventListenerBase
    {
        public abstract int Tag { get; }
        public abstract void CatchEvent(EventBase e);
    }
}
