using System.IO;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using GenshinImpactRollBot.Client;
using GenshinImpactRollBot.Common;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using JsonReader = GenshinImpactRollBot.Client.JsonReader;

namespace GenshinImpactRollBot
{
    public class RollBot
    {
        public DiscordClient Client { get; private set; }

        public async Task RunAsync()
        {
            var botConfigurationTask = JsonReader.PathToGenericObject<DiscordWrapConfiguration>(
                Paths.DiscordConfigPath, false, false);

            var botConfiguration = await botConfigurationTask.ConfigureAwait(false);
            
            var config = new DiscordConfiguration
            {
                Token = botConfiguration.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug
            };
            
            Client = new DiscordClient(config);
            Client.Ready += OnClientReady;

            var commandsConfig = new CommandsNextConfiguration
            {

            };

            Client.UseCommandsNext(commandsConfig);

            await Client.ConnectAsync();
            await Task.Delay(1);
            
        }

        private Task OnClientReady(DiscordClient sender, ReadyEventArgs e)
        {
            return null;
        }
    }
}