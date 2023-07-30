using Discord;
using Discord.WebSocket;
using InversionOfControl;

namespace BigBrother.BLL.Bot.Commands.QuoteCommand
{
	internal class QuoteCommandHandler : CommandHandler
	{
		public QuoteCommandHandler(IDependencyInjector injector) : base(injector, "Quote")
		{
			
		}

		public override Task HandleCommand(SocketSlashCommand command)
		{
			throw new NotImplementedException();
		}
	}
}
