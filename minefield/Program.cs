using Microsoft.Extensions.DependencyInjection;

namespace minefield
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var serviceProvider = new ServiceCollection()
				.AddSingleton<IBoardManager, BoardManager>()
				.AddSingleton<IBoardProcessor, BoardProcessor>()
				.AddSingleton<IGameManager, GameManager>()
				.AddSingleton<IConsoleManager, ConsoleManager>()
				.AddSingleton<IRunner, Runner>()
				.BuildServiceProvider();

			var gameManager = serviceProvider.GetService<IGameManager>();
			gameManager!.Run();
		}
	}
}