using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace GenshinImpactRollBot.Commands
{
    public class RollCommands : BaseCommandModule
    {
        [Command(CommandsName.RollCommandName)]
        public async Task Roll(CommandContext context)
        {
            var msgChannel = context.Channel;
            var sendMessageTask = msgChannel.SendMessageAsync("Вы заролили рохатку");

            await sendMessageTask.ConfigureAwait(false);
        }
    }
}