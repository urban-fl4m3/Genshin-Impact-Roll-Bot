using System.IO;

namespace GenshinImpactRollBot.Common
{
    public static class Paths
    {
        private static readonly string WorkingDirectory = Directory.GetCurrentDirectory();
        private static readonly string ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent?.FullName;
        

        public static readonly string DiscordConfigPath = Path.Combine(ProjectDirectory, Names.DiscordConfigName);
    }
}