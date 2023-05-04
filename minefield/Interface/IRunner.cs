namespace minefield
{
	public interface IRunner
	{
		bool Run { get; set; }
		int LiveCount { get; set; }
		string Message { get; set; }

		int GetLiveCount();

		string GetMessage();

		bool Running();

		void SetLiveCount(int count);

		void SetMessage(string message);

		void SetRunner(bool run);
	}
}