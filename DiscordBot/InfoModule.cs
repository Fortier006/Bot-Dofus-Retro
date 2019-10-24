using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using System.Reflection;

namespace Bot_Dofus_1._29._1.DiscordBot
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        // ~say hello world -> hello world
        [Command("say")]
        [Summary("Echoes a message.")]
        public Task SayAsync([Remainder] [Summary("The text to echo")] string echo)
            => ReplyAsync(echo);

        // ReplyAsync is a method on ModuleBase 

        [Command("activate")]
        [Summary("Activates the bot.")]
        public Task ActivateAsync()
            => ReplyAsync("I am now fully operational. Ready to farm!");

        [Command("log")]
        [Summary("Toggles on or off the logging function of the bot, to tell you what the bot is doing.")]
        public Task LogAsync()
        {
            if (Program.m_bot.LogEnabled)
                Program.m_bot.LogEnabled = false;
            else
                Program.m_bot.LogEnabled = true;

            string state = Program.m_bot.LogEnabled ? "on" : "off";
            return ReplyAsync("The logging function is now " + state + ".");
        }
    }
}
