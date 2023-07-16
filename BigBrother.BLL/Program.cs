using _BigBrother = BigBrother.BLL.Bot.BigBrother;

namespace BigBrother.BLL
{
	public static class Program
	{
		public static async Task<int> Main()
		{
			// Create a new Instance of the bot
			_BigBrother thing = new();
			// Start the bot
			int exitCode = await thing.Run();
			return exitCode;
		}
	}
}
