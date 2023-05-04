using Xunit;

namespace minefield.test
{
	public class BoardProcessorTests
	{
		[Fact]
		public void ResetGame_ShouldSetAllDisplayBoardCellsToDash()
		{
			// Arrange
			var processor = new BoardProcessor();

			// Act
			processor.ResetGame();

			// Assert
			for (int row = 0; row < Constants.Rows.Length; row++)
			{
				for (int col = 0; col < Constants.Colums.Length; col++)
				{
					Assert.Equal('-', processor.DisplayBoard[row, col]);
				}
			}
		}

		[Theory]
		[InlineData("A0", true)]
		[InlineData("A1", false)]
		public void ProcessMove_ShouldReturnExpectedResult(string move, bool expected)
		{
			// Arrange
			var processor = new BoardProcessor();
			processor.ResetGame();
			processor.GameBoard[0, 0] = false;
			processor.GameBoard[0, 1] = true;

			// Act
			var result = processor.ProcessMove(move);

			// Assert
			Assert.Equal(expected, result);
		}

		[Theory]
		[InlineData("A1", true)]
		[InlineData("B2", true)]
		[InlineData("C3", true)]
		[InlineData("C10", false)]
		[InlineData("1A", false)]
		[InlineData("AA", false)]
		[InlineData("A", false)]
		[InlineData("1", false)]
		[InlineData("", false)]
		public void ValidateInput_ShouldReturnExpectedResult(string input, bool expected)
		{
			// Arrange
			var processor = new BoardProcessor();

			// Act
			var result = processor.ValidateInput(input);

			// Assert
			Assert.Equal(expected, result);
		}
	}
}