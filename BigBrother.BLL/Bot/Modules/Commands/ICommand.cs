using Discord;

namespace BigBrother.BLL.Bot.Modules.Commands
{
	internal interface ICommand
	{
		public SlashCommandOptionBuilder GetCommandBuilder();
	}
}
