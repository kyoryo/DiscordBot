using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Modules;
using NadekoBot.Modules.Permissions.Classes;
using Discord.Commands;

namespace NadekoBot.Modules.TreeOfSavior
{
    internal class TreeOfSaviorModule : DiscordModule
    {
        public override string Prefix { get; } = NadekoBot.Config.CommandPrefixes.TreeOfSavior;
        public override void Install(ModuleManager manager)
        {
            manager.CreateCommands("", x =>
            {
                x.AddCheck(PermissionChecker.Instance);
                x.CreateCommand(Prefix + "tosbase items")
                    .Description("Display list of items from tosbase")
                    .Parameter("query", ParameterType.Unparsed)
                    .Do(async e =>
                    {
                        var tag 
                    })
            });
            throw new NotImplementedException();
        }
    }
}
