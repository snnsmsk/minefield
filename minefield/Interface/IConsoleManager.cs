namespace minefield
{
	public interface IConsoleManager
	{
		void WriteLine(string value);

		void WriteLine();

		void Write(string value);

		string ReadLine();

		void Clear();
	}
}