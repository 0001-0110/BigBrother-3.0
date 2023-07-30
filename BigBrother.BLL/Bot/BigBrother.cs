using BigBrother.BLL.Bot.Commands;
using Discord;
using Discord.WebSocket;
using InversionOfControl;

namespace BigBrother.BLL.Bot
{
    internal class BigBrother
	{
		private readonly DiscordSocketClient client;
		private readonly CommandHandlerCollection commandHandlerCollection;

		private bool isRunning = false;

		public BigBrother(IDependencyInjector injector)
		{
			// TODO We may not need all intents
			client = new DiscordSocketClient(
				new DiscordSocketConfig() { GatewayIntents = GatewayIntents.All });
			commandHandlerCollection = injector.Instantiate<CommandHandlerCollection>()!;

			client.Ready += Client_Ready;
			client.SlashCommandExecuted += Client_SlashCommandExecuted;
		}

		private async Task Client_Ready()
		{
			await client.SetStatusAsync(UserStatus.Online);
			await client.SetGameAsync("you", type: ActivityType.Watching);

			// Technically, it is not necessary to do it again every time the program is run,
			// But it does not craete any problems either, so for now I'll do it like that
			
			commandHandlerCollection.BuildSlashCommands(client);
		}

		private async Task Client_SlashCommandExecuted(SocketSlashCommand command)
		{
			await commandHandlerCollection.ExecuteCommand(command);
		}

		private async Task Connect()
		{
			// TODO Read token from config file
			await client.LoginAsync(TokenType.Bot, "MTAwNjU5Njg3ODY2Nzg5NDkyNQ.G1pBzi.9JdHcyv6XWo5oxNpsaOX2vKh33nQfpQXkqrQXs");
			await client.StartAsync();
		}

		private async Task Disconnect()
		{
			await client.SetStatusAsync(UserStatus.Offline);
			await client.StopAsync();
			await client.LogoutAsync();
		}

		public async Task<int> Run()
		{
			isRunning = true;

			try
			{
				await Connect();

				while (isRunning)
					// TODO Raw value
					await Task.Delay(5000);
			}
			catch (Exception exception)
			{
				// TODO Log exception
				return exception.HResult;
			}

			await Disconnect();

			return 0;
		}
	}
}
