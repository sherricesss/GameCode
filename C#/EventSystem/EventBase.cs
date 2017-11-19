namespace EventSystem
{
	public abstract class EventBase
	{
		public abstract int Tag { get; }
		public abstract int EventCode { get; }
		public abstract EventArgumentBase Argument { get; }
	}
}
