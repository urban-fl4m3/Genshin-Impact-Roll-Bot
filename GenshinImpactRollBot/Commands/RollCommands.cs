using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using GenshinImpactRollBot.Gacha;

namespace GenshinImpactRollBot.Commands
{
    public class RollCommands : BaseCommandModule
    {
        private StringBuilder _sb
        {
            get { return _sbInstance ??= new StringBuilder(); }    
        }
        private StringBuilder _sbInstance;
        
        [Command(CommandsName.RollCommandName)]
        [Description("Сыграть в гачу 1 раз.")]
        public async Task Roll(CommandContext context)
        {
            var msgChannel = context.Channel;
            var rollResult = GachaManager.Roll();
            
            var sendMessageTask = msgChannel.SendMessageAsync($"{context.Message.Author.Mention} заролил {rollResult.Name}");

            await sendMessageTask.ConfigureAwait(false);
        }
        
        [Command(CommandsName.Roll10CommandName)]
        [Description("Сыграть в гачу 10 раз.")]
        public async Task Roll10(CommandContext context)
        {
            var msgChannel = context.Channel;

            for (var i = 0; i < 10; i++)
            {
                if (i != 0)
                {
                    _sb.Append(" / ");
                }
                
                var gachaResult = GachaManager.Roll();
                _sb.Append($"{gachaResult.Name}");
            }

            var message = _sb.ToString();
            var sendMessageTask = msgChannel.SendMessageAsync($"{context.Message.Author.Mention} заролил {message}");

            _sb.Clear();
            
            await sendMessageTask.ConfigureAwait(false);
        }
    }
}