using BigBrother.BLL.Bot.Modules;
using Discord;
using Discord.WebSocket;

namespace BigBrother.BLL.Bot
{
	internal class BigBrother
	{
		private readonly DiscordSocketClient client;

		private readonly IReadOnlyDictionary<ulong, IModule> modules;

		public BigBrother()
		{
			// TODO We may not need all intents
			client = new DiscordSocketClient(
				new DiscordSocketConfig() { GatewayIntents = GatewayIntents.All });

			client.SlashCommandExecuted += Client_SlashCommandExecuted;

			modules = new Dictionary<ulong, IModule>();
		}

		private async Task Client_SlashCommandExecuted(SocketSlashCommand command)
		{
			if (!modules.TryGetValue(command.CommandId, out IModule? module))
				// TODO handle unrecognized commands
				return;

			await module.HandleCommand(command);
		}

		private async void BuildSlashCommands()
		{
			foreach (IModule module in modules.Values)
				await client.CreateGlobalApplicationCommandAsync(module.GetModuleCommandBuilder().Build());
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
			// TODO This is temporary
			await Task.Yield();
			return 0;
		}
	}
}
