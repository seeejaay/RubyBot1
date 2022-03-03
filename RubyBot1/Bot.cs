using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RubyBot1.commands;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace RubyBot1
{
    public class Bot
    {
        public InteractivityExtension Interactivity { get; private set; }
        public CommandsNextExtension Commands { get; private set; }
        public DiscordClient Client { get; private set; }
       

        public async Task RunAsync() 
        {
            var json = string.Empty;

            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync().ConfigureAwait(false);

            var configJson = JsonConvert.DeserializeObject<Configjson>(json);

            var config = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug,
            };

          
            Client = new DiscordClient(config);

            Client.Ready += Client_Ready; ;


            Client.UseInteractivity(new InteractivityConfiguration
            {
                Timeout = TimeSpan.FromMinutes(2)
            });



            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configJson.Prefix },
                EnableDms = false,
                EnableMentionPrefix = true,
                CaseSensitive = false,
                DmHelp =false,
                UseDefaultCommandHandler = true
            };

            Commands = Client.UseCommandsNext(commandsConfig);

             Commands.RegisterCommands<FunCommands>();


            await Client.ConnectAsync();

            await Task.Delay(-1);
    }

        private Task Client_Ready(DiscordClient sender, ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }

        

        
    }
}
