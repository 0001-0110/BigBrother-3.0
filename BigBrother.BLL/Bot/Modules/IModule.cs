using Discord;
using Discord.WebSocket;

namespace Bot.Modules
{
    internal interface IModule
    {
        public Task Init();

        public SlashCommandBuilder GetModuleCommandBuilder();

        // The method to call when this module is called
        // TODO might not be the correct return type
        public Task HandleCommand(SocketSlashCommand command);
    }
}
