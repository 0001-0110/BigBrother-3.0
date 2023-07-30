using Discord;

namespace BigBrother.BLL.Bot.Commands.SubCommands
{
	internal class SubCommandHandler : RestrictedAccessHandler, ISubCommandHandler
	{
		// TODO
		public SubCommandHandler(params string[] args)
		{
			throw new NotImplementedException();
		}

		public SlashCommandOptionBuilder GetSubCommandBuilder()
		{
			throw new NotImplementedException();
		}
	}
}
