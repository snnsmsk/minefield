namespace minefield
{
	public interface IBoardProcessor
	{
		bool[,] GameBoard { get; set; }
		char[,] DisplayBoard { get; set; }

		bool ProcessMove(string move);

		void ResetGame();

		bool ValidateInput(string move);
	}
}