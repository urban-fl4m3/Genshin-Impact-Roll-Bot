using System.IO;

namespace GenshinImpactRollBot.Common
{
    public static class Paths
    {
        private static readonly string WorkingDirectory = Directory.GetCurrentDirectory();
        private static readonly string ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent?.FullName;
     
        private static readonly string _picturesDirectory = Path.Combine(ProjectDirectory, "Pictures");   

        public static readonly string DiscordConfigPath = Path.Combine(ProjectDirectory, Names.DiscordConfigName);

        public static readonly string SimpleRollBlue = Path.Combine(_picturesDirectory, Names.SingleRollBluePic);
    }
}