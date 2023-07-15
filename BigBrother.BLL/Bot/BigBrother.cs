using BigBrother.BLL.Bot.Modules;
using Discord;
using Discord.WebSocket;

namespace BigBrother.BLL.Bot
{
	internal class BigBrother
	{
		private readonly DiscordSocketClient client;

		private readonly IEnumerable<IModule> modules;

		public BigBrother()
		{
			// TODO We may not need all intents
			client = new DiscordSocketClient(
				new DiscordSocketConfig() { GatewayIntents = GatewayIntents.All });

			client.SlashCommandExecuted += Client_SlashCommandExecuted;

			modules = new List<IModule>();
		}

		private Task Client_SlashCommandExecuted(SocketSlashCommand arg)
		{
			throw new NotImplementedException();
		}

		private async void BuildSlashCommands()
		{
			foreach (var module in modules)
			{
				await client.CreateGlobalApplicationCommandAsync(module.GetModuleCommandBuilder().Build());
			}
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

		public int Run()
		{
			return 0;
		}
	}
}
