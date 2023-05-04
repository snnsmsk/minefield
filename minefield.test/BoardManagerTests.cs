namespace minefield.test
{
	using System;
	using Xunit;

	public class BoardManagerTests
	{
		[Fact]
		public void Display_Should_Print_Board_And_Message()
		{
			// Arrange
			var consoleManager = new TestConsoleManager();

			var boardManager = new BoardManager(consoleManager);
			var matrix = new char[,]
			{
			{'-', '-', '-','-', '-', '-', '-', '-', '-', '-'},
			{'-', '-', '-','-', '-', '-', '-', '-', '-', '-'},
			{'-', '-', '-','-', '-', '-', '-', '-', '-', '-'},
			{'-', '-', '-','-', '-', '-', '-', '-', '-', '-'},
			{'-', '-', '-','-', '-', '-', '-', '-', '-', '-'},
			{'-', '-', '-','-', '-', '-', '-', '-', '-', '-'},
			{'-', '-', '-','-', '-', '-', '-', '-', '-', '-'},
			{'-', '-', '-','-', '-', '-', '-', '-', '-', '-'},
			{'-', '-', '-','-', '-', '-', '-', '-', '-', '-'},
			{'-', '-', '-','-', '-', '-', '-', '-', '-', '-'},
			};

			var message = "Test message";
			var liveCount = 2;
			var expectedOutput =
				"  0 1 2 3 4 5 6 7 8 9 \r\n" +
				"A - - - - - - - - - - \r\n" +
				"B - - - - - - - - - - \r\n" +
				"C - - - - - - - - - - \r\n" +
				"D - - - - - - - - - - \r\n" +
				"E - - - - - - - - - - \r\n" +
				"F - - - - - - - - - - \r\n" +
				"G - - - - - - - - - - \r\n" +
				"H - - - - - - - - - - \r\n" +
				"I - - - - - - - - - - \r\n" +
				"J - - - - - - - - - - \r\n" +
				"You have 2 live(s)\r\n" +
				"Test message\r\n" +
				"Enter row and column : \r\n";

			// Act
			boardManager.Display(matrix, message, liveCount);

			// Assert
			var output = consoleManager.GetOutput();
			Assert.Equal(expectedOutput, output);
		}
	}

	public class TestConsoleManager : IConsoleManager
	{
		private readonly StringWriter _output;

		public TestConsoleManager()
		{
			_output = new StringWriter();
			Console.SetOut(_output);
		}

		public string GetOutput()
		{
			return _output.ToString();
		}

		public void Clear()
		{
			Console.Clear();
		}

		public string ReadLine()
		{
			throw new NotImplementedException();
		}

		public void WriteLine(string value)
		{
			Console.WriteLine(value);
		}

		public void WriteLine()
		{
			Console.WriteLine();
		}

		public void Write(string value)
		{
			Console.Write(value);
		}
	}
}