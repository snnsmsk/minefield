namespace minefield
{
	public abstract class ConsoleManagerBase : IConsoleManager
	{
		public abstract void Clear();

		public abstract string ReadLine();

		public abstract void WriteLine(string value);

		public abstract void WriteLine();

		public abstract void Write(string value);
	}
}