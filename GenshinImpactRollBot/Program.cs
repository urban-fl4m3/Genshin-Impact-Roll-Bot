namespace GenshinImpactRollBot
{
    public class Program
    {
        private static void Main()
        {
            var installer = new BotInstaller();
            installer.RunAsync().GetAwaiter().GetResult();
        }
    }
}
