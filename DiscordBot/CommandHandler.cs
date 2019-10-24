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
    public class CommandHandler
    {

        private readonly DiscordSocketClient m_client;
        private readonly CommandService m_commands;
        private SocketUserMessage m_sampleMessage;
        public event ScriptActivationHandler OnToggleScript;

        // Retrieve client and CommandService instance via ctor, dependency injection (?)
        public CommandHandler(DiscordSocketClient pClient, CommandService pCommands)
        {
            m_client = pClient;
            m_commands = pCommands;
        }

        public async Task InstallCommandsAsync()
        {
            // Hook the MessageReceived event into our command handler
            m_client.MessageReceived += HandleCommandAsync;

            // Here we discover all of the command modules in the entry 
            // assembly and load them. Starting from Discord.NET 2.0, a
            // service provider is required to be passed into the
            // module registration method to inject the 
            // required dependencies.
            //
            // If you do not use Dependency Injection, pass null.
            // See Dependency Injection guide for more information.
            await m_commands.AddModulesAsync(assembly: Assembly.GetEntryAssembly(),
                                            services: null);
        }

        private async Task HandleCommandAsync(SocketMessage pMessageParam)
        {
            // Don't process the command if it was a system message
            SocketUserMessage message = pMessageParam as SocketUserMessage;
            if (message == null)
                return;

            // Create a number to track where the prefix ends and the command begins
            int argPos = 0;

            // Determine if the message is a command based on the prefix and make sure no bots trigger commands
            if (!(message.HasCharPrefix('!', ref argPos) ||
                message.HasMentionPrefix(m_client.CurrentUser, ref argPos)) ||
                message.Author.IsBot)
                return;

            if (message.Channel.Id != 636397720227282974 && message.Author.Id != 225829051162558464) // bot-info channel on Awesome
                return;

            if (m_sampleMessage == null)
                m_sampleMessage = message;

            if(message.Content.Contains("toggleScript"))
            {
                await SystemMessageToChannel("Toggling script...");
                if (OnToggleScript != null)
                {
                    OnToggleScript(this, new CustomEventArgs("User " + message.Author.Username + " toggled the current script."));
                }
            }

            // Create a WebSocket-based command context based on the message
            SocketCommandContext context = new SocketCommandContext(m_client, message);

            // Execute the command with the command context we just
            // created, along with the service provider for precondition checks.
            await m_commands.ExecuteAsync(
                context: context,
                argPos: argPos,
                services: null);
        }

        /*public async Task SystemHandleCommandAsync(string pCommand)
        {
            SocketUserMessage message = m_sampleMessage;

            if (message == null)
                info_socket?.Invoke("Le bot n'a pas encore été activé.");

            // Create a number to track where the prefix ends and the command begins
            int argPos = 0;

            // Create a WebSocket-based command context based on the message
            SocketCommandContext context = new SocketCommandContext(m_client, message);

            context.Channel.SendMessageAsync

            // Execute the command with the command context we just
            // created, along with the service provider for precondition checks.
            await m_commands.ExecuteAsync(
                context: context,
                argPos: argPos,
                services: null);
        }*/

        public async Task SystemMessageToChannel(string pMess)
        {
            SocketUserMessage message = m_sampleMessage;

            if (message == null)
                throw new Exception("Bot pas activé!");

            // Create a number to track where the prefix ends and the command begins
            int argPos = 0;

            // Create a WebSocket-based command context based on the message
            SocketCommandContext context = new SocketCommandContext(m_client, message);

            await context.Channel.SendMessageAsync(pMess);
            
        }

        public async Task SystemDM(string pMess)
        {
            SocketUserMessage message = m_sampleMessage;

            if (message == null)
                throw new Exception("Bot pas activé!");

            // Create a number to track where the prefix ends and the command begins
            int argPos = 0;

            // Create a WebSocket-based command context based on the message
            SocketCommandContext context = new SocketCommandContext(m_client, message);

            await context.Channel.SendMessageAsync(pMess);
            await Program.m_bot.Client.GetUser(225829051162558464).SendMessageAsync(pMess);
        }      
    }
}
