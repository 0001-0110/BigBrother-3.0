using Discord.WebSocket;

namespace BigBrother.BLL.Bot.Commands
{
	internal class RestrictedAccessHandler
	{
		protected readonly Permission minimumPermissionRequired = Permission.Standard;

		protected async Task<bool> IsUserAuthorized(SocketUser user)
		{
			return await IsUserAuthorized(user.Id);
		}

		protected async Task<bool> IsUserAuthorized(ulong userId)
		{
			throw new NotImplementedException();
		}
	}
}
