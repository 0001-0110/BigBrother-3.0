using Discord;
using Discord.WebSocket;

namespace BigBrother.BLL.Bot.Commands.WriterCommand
{
	internal abstract class CommandHandler : ICommandHandler
	{
		public CommandHandler() { }

		public abstract Task Init();

		public abstract SlashCommandBuilder GetModuleCommandBuilder();

		public abstract Task HandleCommand(SocketSlashCommand command);
	}
}
