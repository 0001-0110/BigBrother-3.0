using Discord;

namespace BigBrother.BLL.Bot.Commands.SubCommands
{
	internal interface ISubCommandHandler
	{
		public SlashCommandOptionBuilder GetCommandBuilder();
	}
}
