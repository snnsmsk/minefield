namespace minefield
{
	public class Runner : IRunner
	{
		public bool Run { get; set; }
		public int LiveCount { get; set; }
		public string Message { get; set; }

		public void SetRunner(bool run)
		{
			Run = run;
		}

		public void SetLiveCount(int count)
		{
			LiveCount = count;
		}

		public int GetLiveCount()
		{
			return LiveCount;
		}

		public void SetMessage(string message)
		{
			Message = message;
		}

		public string GetMessage()
		{
			return Message;
		}

		public bool Running()
		{
			return Run;
		}
	}
}