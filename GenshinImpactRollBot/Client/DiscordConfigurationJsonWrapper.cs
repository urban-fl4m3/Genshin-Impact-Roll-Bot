﻿using GenshinImpactRollBot.Common;
using Newtonsoft.Json;

namespace GenshinImpactRollBot.Client
{
    public class DiscordConfigurationJsonWrapper
    {
        [JsonProperty(Names.TokenName)]
        public string Token { get; private set; }
        
        [JsonProperty(Names.PrefixName)]
        public string Prefix { get; private set; }
        
    }
}