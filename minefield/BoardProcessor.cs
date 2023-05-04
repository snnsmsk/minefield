namespace minefield
{
	public class BoardProcessor : IBoardProcessor
	{
		public bool[,] GameBoard { get; set; }
		public char[,] DisplayBoard { get; set; }

		public void ResetGame()
		{
			int rows = Constants.Rows.Length;
			int cols = Constants.Colums.Length;

			GameBoard = new bool[rows, cols];
			Random rand = new();
			int mineCount = 0;
			while (mineCount < Constants.MinesCount)
			{
				int row = rand.Next(rows);
				int col = rand.Next(cols);
				if (!GameBoard[row, col])
				{
					GameBoard[row, col] = true;
					mineCount++;
				}
			}

			DisplayBoard = new char[rows, cols];
			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < cols; col++)
				{
					DisplayBoard[row, col] = '-';
				}
			}
		}

		public bool ProcessMove(string move)
		{
			int col = int.Parse(move[1].ToString());
			int row = Constants.Rows.IndexOf(move[0]);

			if (GameBoard[row, col])
			{
				return false;
			}
			else
			{
				int adjacentMines = 0;
				for (int i = -1; i <= 1; i++)
				{
					for (int j = -1; j <= 1; j++)
					{
						if (i == 0 && j == 0) continue;
						int adjacentRow = row + i;
						int adjacentCol = col + j;
						if (adjacentRow >= 0 && adjacentRow < Constants.Rows.Length && adjacentCol >= 0 && adjacentCol < Constants.Colums.Length)
						{
							if (GameBoard[adjacentRow, adjacentCol])
							{
								adjacentMines++;
							}
						}
					}
				}
				DisplayBoard[row, col] = adjacentMines.ToString()[0];
			}

			return true;
		}

		public bool ValidateInput(string move)
		{
			if (move.Length != 2)
				return false;

			if (!Constants.Rows.Contains(move[0]))
				return false;

			if (!Constants.Colums.Contains(move[1]))
				return false;

			return true;
		}
	}
}