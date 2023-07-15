﻿using _BigBrother = BigBrother.BLL.Bot.BigBrother;

namespace BigBrother.BLL
{
	public static class Program
	{
		public static async Task<int> Main(string[] args)
		{
			// Create a new Instance of the bot
			_BigBrother thing = new();
			// Start the bot
			int exitCode = thing.Run();
			return exitCode;
		}
	}
}
