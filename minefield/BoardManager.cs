namespace minefield
{
	public class BoardManager : IBoardManager
	{
		private readonly IConsoleManager _consoleManager;

		public BoardManager(IConsoleManager consoleManager)
		{
			_consoleManager = consoleManager;
		}

		public void Display(char[,] matrix, string message, int liveCount)
		{
			var rows = matrix.GetLength(0);
			var cols = matrix.GetLength(1);

			_consoleManager.Write("  ");
			for (int col = 0; col < Constants.Colums.Length; col++)
			{
				_consoleManager.Write(Constants.Colums[col] + " ");
			}
			_consoleManager.WriteLine();
			for (int item = 0; item < rows; item++)
			{
				_consoleManager.Write(Constants.Rows[item] + " ");
				for (int col1 = 0; col1 < cols; col1++)
				{
					_consoleManager.Write(matrix[item, col1] + " ");
				}
				_consoleManager.WriteLine();
			}

			_consoleManager.WriteLine($"You have {liveCount} live(s)");
			if (!string.IsNullOrWhiteSpace(message))
				_consoleManager.WriteLine(message);

			if (liveCount > 0)
				_consoleManager.WriteLine($"Enter row and column : ");
			else
				_consoleManager.WriteLine("Game over. Would you like to play again ? (Y/N)");
		}
	}
}