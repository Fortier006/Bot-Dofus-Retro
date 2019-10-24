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
    public class InteractionModule : ModuleBase<SocketCommandContext>
    {
        public event ScriptActivationHandler OnToggleScript;

        //[Command("toggleScript")]
        //[Summary("Toggles on or off the current script")]
        //public Task ToggleScriptAsync()
        //{
        //    if(OnToggleScript != null)
        //    {
        //        OnToggleScript(this, new CustomEventArgs("User " + this.Context.User.Username + " toggled the current script."));
        //    }

        //    return ReplyAsync("Toggling the script...");
        //}
    }
}
