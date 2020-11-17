using System;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
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
        
        public DiscordConfiguration GetDiscordConfiguration()
        {
            return new DiscordConfiguration
            {
                Token = _discordConfigurationJsonWrapper.Token,
                AutoReconnect = true,
                TokenType = TokenType.Bot,
                MinimumLogLevel = LogLevel.Debug
            };
        }

        public CommandsNextConfiguration GetCommandsConfiguration()
        {
            return new CommandsNextConfiguration
            {
                EnableDms = false,
                EnableMentionPrefix = true,
                IgnoreExtraArguments = false,
                StringPrefixes = new[] { _discordConfigurationJsonWrapper.Prefix }
            };
        }

        public InteractivityConfiguration GetInteractivityConfiguration()
        {
            return new InteractivityConfiguration
            {
                Timeout = TimeSpan.FromMinutes(2)
            };
        }
    }
}