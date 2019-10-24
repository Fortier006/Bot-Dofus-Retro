using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace Bot_Dofus_1._29._1.DiscordBot
{
    public class Bot
    {
        private const string TOKEN = "NjM2MzQ2NDc2MDUzNzkwNzMw.Xa-5GA.Q6bU9zfQaziXFMz-c1WlvDEUF-0";
        private DiscordSocketClient m_client;
        private Discord.Commands.CommandService m_service;
        private CommandHandler m_handler;
        private bool m_logEnabled = true;

        public CommandHandler CommandHandler
        {
            get { return m_handler; }
        }

        public DiscordSocketClient Client
        {
            get { return m_client; }
        }

        public Discord.Commands.CommandService CommandService
        {
            get { return m_service; }
        }

        public bool LogEnabled
        {
            get { return m_logEnabled; }
            set { m_logEnabled = value; }
        }

        public Bot()
        {
            this.MainAsync().GetAwaiter().GetResult();
        }

        public async Task MainAsync()
        {
            m_client = new DiscordSocketClient();
            // Attaching the logger function to our client.
            m_client.Log += Log;
            m_client.Ready += GreetUser;

            // Login with the bot. Ideally, the client should be a singleton, and the token should be secured somewhere else. But this will do.
            await m_client.LoginAsync(TokenType.Bot, TOKEN);
            await m_client.StartAsync();

            m_service = new Discord.Commands.CommandService();

            CommandHandler cmdh = new CommandHandler(m_client, m_service);

            this.m_handler = cmdh;

            await cmdh.InstallCommandsAsync();
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        public async Task GreetUser()
        {
            await Program.m_bot.Client.GetUser(225829051162558464).SendMessageAsync("Blip bloop, I am online. Please activate me using !activate.");
        }
    }
}
