namespace BigBrother.BLL
{
	public static class Program
	{
		public static async Task<int> Main()
		{
			// Create a new Instance of the bot
			Bot.BigBrother bigBrother = new();
			// Start the bot
			int exitCode = await bigBrother.Run();
			return exitCode;
		}
	}
}
