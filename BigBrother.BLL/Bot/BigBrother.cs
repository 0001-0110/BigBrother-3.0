using BigBrother.BLL.Bot.Services;
using Discord;
using Discord.WebSocket;

namespace BigBrother.BLL.Bot
{
	internal class BigBrother
	{
		private readonly DiscordSocketClient client;
		private readonly CommandHandlerCollection commandHandlerCollection;

		private bool isRunning = false;

		public BigBrother()
		{
			// TODO We may not need all intents
			client = new DiscordSocketClient(
				new DiscordSocketConfig() { GatewayIntents = GatewayIntents.All });
			commandHandlerCollection = new CommandHandlerCollection();

			client.SlashCommandExecuted += Client_SlashCommandExecuted;
		}

		private async Task Client_SlashCommandExecuted(SocketSlashCommand command)
		{
			await commandHandlerCollection.ExecuteCommand(command);
		}

		private async Task Connect()
		{
			// TODO Read token
			await client.LoginAsync(TokenType.Bot, "");
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
