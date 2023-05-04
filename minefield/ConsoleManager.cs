namespace minefield
{
	public class ConsoleManager : ConsoleManagerBase
	{
		public override void Clear()
		{
			Console.Clear();
		}

		public override string ReadLine()
		{
			return Console.ReadLine()!.ToUpper();
		}

		public override void WriteLine(string value)
		{
			Console.WriteLine(value);
		}

		public override void WriteLine()
		{
			Console.WriteLine();
		}

		public override void Write(string value)
		{
			Console.Write(value);
		}
	}
}