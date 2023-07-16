using Discord;
using Discord.WebSocket;

namespace BigBrother.BLL.Bot.Commands
{
	internal interface ICommandHandler
	{
		public Task Init();

		public SlashCommandBuilder GetModuleCommandBuilder();

		public Task HandleCommand(SocketSlashCommand command);
	}
}
