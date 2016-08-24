using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Modules;
using NadekoBot.Modules.Permissions.Classes;
using Discord.Commands;
using NadekoBot.Classes;

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
                x.CreateCommand(Prefix + "tosbase")
                    .Description("Display top 5 tosbase items from your query")
                    .Parameter("query", ParameterType.Unparsed)
                    .Do(async e =>
                    {
                        var query = e.GetArg("query")?.Trim() ?? "";
                        var links = await Task.WhenAll(SearchHelper.GetTosBaseItemLink(query)).ConfigureAwait(false);
                        
                        if (links.All(l => l == null))
                        {
                            await e.Channel.SendMessage("`No results.`");
                            return;
                        }
                        //redundant
                        foreach (var li in links)
                        {
                            foreach (var l in li)
                            {
                                var _links = l;
                                await e.Channel.SendMessage(_links).ConfigureAwait(false);
                            }
                        }
                        //await e.Channel.SendMessage(String.Join("\n", links)).ConfigureAwait(false);
                    });
            });
            manager.CreateCommands("", x =>
            {
                x.AddCheck(PermissionChecker.Instance);
                x.CreateCommand(Prefix + "tosneetattributes")
                    .Alias(Prefix + "tna")
                    .Description("Display top 5(WIP) tosneet attributes from your query")
                    .Parameter("query", ParameterType.Unparsed)
                    .Do(async e =>
                    {

                        var query = e.GetArg("query")?.Trim() ?? "";
                        var links = await Task.WhenAll(SearchHelper.GetTosNeetAttributesLink(query)).ConfigureAwait(false);

                        if (links.All(l => l == null))
                        {
                            await e.Channel.SendMessage("`No results.`");
                            return;
                        }

                        await e.Channel.SendMessage(String.Join("\n", links)).ConfigureAwait(false);

                    });
            });
            //throw new NotImplementedException();
        }
    }
}
