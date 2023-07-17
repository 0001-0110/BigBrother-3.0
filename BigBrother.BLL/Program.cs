using InversionOfControl;

namespace BigBrother.BLL
{
	public static class Program
	{
		public static async Task<int> Main()
		{
			// Add all mappings here
			IDependencyInjector injector = new DependencyInjector();

			// Create a new Instance of the bot
			if (injector.Instantiate<Bot.BigBrother>() is Bot.BigBrother bigBrother)
			{
				// Start the bot
				int exitCode = await bigBrother.Run();
				return exitCode;
			}

			// Could not instantiate the bot (probably a missing mapping in the injector)
			return -1;
		}
	}
}
