using Bot.Modules;
using Discord;
using Discord.WebSocket;

namespace Bot
{
    internal class BigBrother
    {
        private DiscordSocketClient client;

        List<IModule> modules;

        public BigBrother()
        {

        }

        private async void BuildSlashCommands()
        {
            foreach (var module in modules)
            {
                await client.CreateGlobalApplicationCommandAsync(module.GetModuleCommandBuilder().Build());
            }
        }

        private async Task Connect()
        {
            // TODO Read token
            await client.LoginAsync(TokenType.Bot, "");
            await client.StartAsync();
        }

        private async Task Disconnect()
        {
            await client.SetStatusAsync(UserStatus.Offline);
            await client.StopAsync();
            await client.LogoutAsync();
        }

        public int Run()
        {
            return 0;
        }
    }
}
