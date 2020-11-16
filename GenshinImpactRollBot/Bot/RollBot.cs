using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using GenshinImpactRollBot.Client;
using GenshinImpactRollBot.Common;
using Microsoft.Extensions.Logging;
using JsonReader = GenshinImpactRollBot.Client.JsonReader;

namespace GenshinImpactRollBot
{
    public class RollBot
    {
        public DiscordClient Client { get; private set; }

        public async Task RunAsync()
        {
            var botConfigurationTask = JsonReader.PathToGenericObject<DiscordConfigurationJsonWrapper>(
                Paths.DiscordConfigPath, false, false);

            var jsonConfig = await botConfigurationTask.ConfigureAwait(false);
            
            var config = new DiscordConfiguration
            {
                Token = jsonConfig.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug
            };
            
            Client = new DiscordClient(config);
            Client.Ready += OnClientReady;

            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new[] { jsonConfig.Prefix },
                EnableMentionPrefix = true,
                EnableDms = false
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