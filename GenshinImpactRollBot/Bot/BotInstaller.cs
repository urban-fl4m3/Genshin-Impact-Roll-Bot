using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using GenshinImpactRollBot.Client;
using GenshinImpactRollBot.Commands;
using GenshinImpactRollBot.Common;
using GenshinImpactRollBot.Gacha;
using Microsoft.Extensions.Logging;
using JsonReader = GenshinImpactRollBot.Client.JsonReader;

namespace GenshinImpactRollBot
{
    public class BotInstaller
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }
        public InteractivityExtension Interactivity { get; private set; }

        public async Task RunAsync()
        {
            var configurationTaskPath = JsonReader.PathToGenericObject<DiscordConfigurationJsonWrapper>(
                Paths.DiscordConfigPath, false, false);

            var jsonConfig = await configurationTaskPath.ConfigureAwait(false);
            
            var configurationManager = new ConfigurationManager(jsonConfig);

            var discordConfig = configurationManager.GetDiscordConfiguration();
            var commandsConfig = configurationManager.GetCommandsConfiguration();
            var interactivityConfig = configurationManager.GetInteractivityConfiguration();
            
            Client = new DiscordClient(discordConfig);
            Client.Ready += OnClientReady;

            Interactivity = Client.UseInteractivity(interactivityConfig);
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