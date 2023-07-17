using BigBrother.BLL.Bot.Commands.SubCommands;
using Discord;
using Discord.WebSocket;

namespace BigBrother.BLL.Bot.Commands
{
    internal abstract class CommandHandler : ICommandHandler
    {
        public readonly string commandName;

		public string CommandName { get { return commandName; } }

        private readonly IEnumerable<ISubCommandHandler> subCommandHandlers;

        public CommandHandler(string name, params ISubCommandHandler[] subCommandHandlers) 
        {
            commandName = name;
            this.subCommandHandlers = subCommandHandlers;
        }

        public abstract Task Init();

        public abstract SlashCommandBuilder GetModuleCommandBuilder();

        public abstract Task HandleCommand(SocketSlashCommand command);
    }
}
