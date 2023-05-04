namespace minefield
{
	public class GameManager : IGameManager
	{
		private readonly IBoardProcessor _boardProcessor;
		private readonly IBoardManager _boardManager;
		private readonly IConsoleManager _consoleManager;
		private readonly IRunner _runner;
		private bool _moveon;

		public GameManager(IBoardManager boardManager, IBoardProcessor boardProcessor,
			IConsoleManager consoleManager, IRunner runner)
		{
			_boardProcessor = boardProcessor;
			_boardManager = boardManager;
			_consoleManager = consoleManager;
			_runner = runner;
		}

		public void Run()
		{
			InitializeGame();
			while (_runner.Running())
			{
				GameLoop();
			}
		}

		public void GameLoop()
		{
			_consoleManager.Clear();
			_boardManager!.Display(_boardProcessor!.DisplayBoard, _runner.GetMessage(), _runner.GetLiveCount());
			_runner.SetMessage(string.Empty);

			var input = _consoleManager.ReadLine();

			if (_boardProcessor.ValidateInput(input))
			{
				_moveon = _boardProcessor.ProcessMove(input);
				if (!_moveon)
				{
					_runner.SetLiveCount(_runner.GetLiveCount() - 1);
					_runner.SetMessage($"You hit a mine on {input}");
				}

				_moveon = true;
				if (_runner.GetLiveCount() < 1)
				{
					_consoleManager.Clear();
					_boardManager!.Display(_boardProcessor!.DisplayBoard, _runner.GetMessage(), _runner.GetLiveCount());

					bool askToContinue = true;
					while (askToContinue)
					{
						var yesOrNo = _consoleManager.ReadLine();
						if (yesOrNo == "Y")
						{
							InitializeGame();
							askToContinue = false;
						}
						else if (yesOrNo == "N")
						{
							askToContinue = false;
							_moveon = false;
						}
						else
						{
							_consoleManager.Clear();
							_boardManager!.Display(_boardProcessor!.DisplayBoard, _runner.GetMessage(),
								_runner.GetLiveCount());

							askToContinue = true;
						}
					}
				}
			}
			else
			{
				_runner.SetMessage("Invalid command, command should be like A2");
			}

			_runner.SetRunner(_moveon);
		}

		private void InitializeGame()
		{
			_moveon = true;
			_runner.SetLiveCount(Constants.LiveCount);
			_runner.SetMessage(string.Empty);
			_runner.SetRunner(true);
			_boardProcessor.ResetGame();
		}
	}
}