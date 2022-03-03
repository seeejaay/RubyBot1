using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;
using System;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.Entities;

namespace RubyBot1.commands
{
    public class FunCommands : BaseCommandModule
    {
        [Command("ping")]
        public async Task ping(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
        }

        [Command("Multiply")]
        public async Task Multiply(CommandContext ctx, int num1, int num2)
        {

            await ctx.Channel.SendMessageAsync((num1 * num2).ToString());
        }

        [Command("blamejet")]
        public async Task Response(CommandContext ctx) 
        {
           

            await ctx.Channel.SendMessageAsync("blame's Ruby");
        }

        [Command("responsemo")]
        public async Task Responseemo(CommandContext ctx)
        {
            var intereactivity = ctx.Client.GetInteractivity();

            var message = await intereactivity.WaitForReactionAsync(x => x.Channel == ctx.Channel).ConfigureAwait(false);

            await ctx.Channel.SendMessageAsync(message.Result.Emoji);
        }

        [Command("Avatar")]

        public async Task Avatar(CommandContext ctx)
        {
            var intereactivity = ctx.Client.GetInteractivity();

            var message = await intereactivity.WaitForMessageAsync(y => y.Channel == ctx.Channel).ConfigureAwait(false);

            await ctx.Channel.SendMessageAsync(message.Result.Author.AvatarUrl);
        }

        [Command("mention")]

        public async Task GreetCommand(CommandContext ctx, DiscordMember member)
        {
            await ctx.RespondAsync($"What do you want? {member.Mention}");
        }

        [Command("pushup")]
        public async Task pushup(CommandContext ctx)
        {


            await ctx.Channel.SendMessageAsync("Push Up");
        }


    }
}

