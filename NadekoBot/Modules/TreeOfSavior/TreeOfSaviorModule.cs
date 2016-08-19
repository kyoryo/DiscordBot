using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Modules;

namespace NadekoBot.Modules.TreeOfSavior
{
    internal class TreeOfSaviorModule : DiscordModule
    {
        public override string Prefix { get; } = NadekoBot.Config.CommandPrefixes.TreeOfSavior;
        public override void Install(ModuleManager manager)
        {
            throw new NotImplementedException();
        }
    }
}
