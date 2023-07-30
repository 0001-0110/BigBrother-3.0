using Discord;
using Discord.WebSocket;

namespace BigBrother.BLL.Bot.Commands
{
	internal interface ICommandHandler
	{
		public string CommandName { get; }

		public SlashCommandBuilder GetModuleCommandBuilder();

		public Task HandleCommand(SocketSlashCommand command);
	}
}
