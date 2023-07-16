using BigBrother.BLL.Bot.Commands;
using Discord.WebSocket;

namespace BigBrother.BLL.Bot.Services
{
	internal class CommandHandlerCollection
	{
		private readonly IReadOnlyDictionary<ulong, ICommandHandler> commandHandlers;

		public CommandHandlerCollection() 
		{
			commandHandlers = new Dictionary<ulong, ICommandHandler>();
		}

		private async void BuildSlashCommands(DiscordSocketClient client)
		{
			foreach (ICommandHandler module in commandHandlers.Values)
				await client.CreateGlobalApplicationCommandAsync(module.GetModuleCommandBuilder().Build());
		}

		public async Task ExecuteCommand(SocketSlashCommand command)
		{
			if (!commandHandlers.TryGetValue(command.CommandId, out ICommandHandler? module))
				// TODO handle unrecognized commands
				return;

			await module.HandleCommand(command);
		}
	}
}
