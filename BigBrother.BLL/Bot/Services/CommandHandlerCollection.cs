using BigBrother.BLL.Bot.Commands;
using Discord.WebSocket;
using InversionOfControl;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BigBrother.BLL.Bot.Services
{
	internal class CommandHandlerCollection
	{
		private readonly Dictionary<string, ICommandHandler> commandHandlers;

		public CommandHandlerCollection(IDependencyInjector injector)
		{
			commandHandlers = new();

			// TODO Might add a check for a certain attribut to allow easier control over which handlers are active
			foreach (Type? commandHandlerType in Assembly.GetExecutingAssembly().GetTypes().Where(type => type.GetInterfaces().Contains(typeof(ICommandHandler))))
				if (injector.Instantiate(commandHandlerType) is ICommandHandler commandHandler)
					commandHandlers.Add(commandHandler.CommandName, commandHandler);
		}

		private async void BuildSlashCommands(DiscordSocketClient client)
		{
			foreach (ICommandHandler module in commandHandlers.Values)
				await client.CreateGlobalApplicationCommandAsync(module.GetModuleCommandBuilder().Build());
		}

		public async Task ExecuteCommand(SocketSlashCommand command)
		{
			if (!commandHandlers.TryGetValue(command.CommandName, out ICommandHandler? module))
				// TODO handle unrecognized commands
				return;

			await module.HandleCommand(command);
		}
	}
}
