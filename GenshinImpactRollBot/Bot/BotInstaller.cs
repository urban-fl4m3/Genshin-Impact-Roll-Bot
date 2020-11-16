using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using GenshinImpactRollBot.Client;
using GenshinImpactRollBot.Commands;
using GenshinImpactRollBot.Common;
using Microsoft.Extensions.Logging;
using JsonReader = GenshinImpactRollBot.Client.JsonReader;

namespace GenshinImpactRollBot
{
    public class BotInstaller
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }

        public async Task RunAsync()
        {
            var configurationTaskPath = JsonReader.PathToGenericObject<DiscordConfigurationJsonWrapper>(
                Paths.DiscordConfigPath, false, false);

            var jsonConfig = await configurationTaskPath.ConfigureAwait(false);
            
            var configurationManager = new ConfigurationManager(jsonConfig);

            var discordConfig = configurationManager.ToDiscordConfiguration();
            var commandsConfig = configurationManager.ToCommandsNextConfiguration();
            
            Client = new DiscordClient(discordConfig);
            Client.Ready += OnClientReady;
            
            Commands = Client.UseCommandsNext(commandsConfig);
            Commands.RegisterCommands<RollCommands>();
            
            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private Task OnClientReady(DiscordClient sender, ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}