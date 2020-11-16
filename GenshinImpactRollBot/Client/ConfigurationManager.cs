using DSharpPlus;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.Logging;

namespace GenshinImpactRollBot.Client
{
    public class ConfigurationManager
    {
        private readonly DiscordConfigurationJsonWrapper _discordConfigurationJsonWrapper;
        
        public ConfigurationManager(DiscordConfigurationJsonWrapper discordConfigurationJsonWrapper)
        {
            _discordConfigurationJsonWrapper = discordConfigurationJsonWrapper;
        }
        
        public DiscordConfiguration ToDiscordConfiguration()
        {
            return new DiscordConfiguration
            {
                Token = _discordConfigurationJsonWrapper.Token,
                AutoReconnect = true,
                TokenType = TokenType.Bot,
                MinimumLogLevel = LogLevel.Debug
            };
        }

        public CommandsNextConfiguration ToCommandsNextConfiguration()
        {
            return new CommandsNextConfiguration
            {
                EnableDms = false,
                EnableMentionPrefix = true,
                IgnoreExtraArguments = false,
                StringPrefixes = new[] { _discordConfigurationJsonWrapper.Prefix }
            };
        }
    }
}