using BigBrother.BLL.Bot.Commands.SubCommands;
using Discord;
using Discord.WebSocket;
using InversionOfControl;
using System.Reflection;

namespace BigBrother.BLL.Bot.Commands
{
	internal abstract class CommandHandler : RestrictedAccessHandler, ICommandHandler
	{
		private readonly string commandName;
		protected readonly string? description;

		public string CommandName { get { return commandName; } }

		private readonly IEnumerable<ISubCommandHandler> subCommandHandlers;

		public CommandHandler(IDependencyInjector injector, string name)
		{
			commandName = name;

			// Get all sub command handlers corresponding to this command handler
			Type selfType = GetType();
			subCommandHandlers = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.GetCustomAttribute<SubCommandHandlerAttribute>()?.CommandHandlerType == selfType).Select(type => (ISubCommandHandler)injector.Instantiate(type)!);
		}

		public SlashCommandBuilder GetModuleCommandBuilder()
		{
			return new SlashCommandBuilder()
				.WithName(commandName.ToLower())
				.WithDescription(description ?? "No description provided")
				.AddOptions(subCommandHandlers.Select(subCommandHandler => subCommandHandler.GetSubCommandBuilder()).ToArray());
		}

		public abstract Task HandleCommand(SocketSlashCommand command);
	}
}
