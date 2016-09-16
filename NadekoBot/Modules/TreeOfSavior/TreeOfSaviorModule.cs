using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Modules;
using NadekoBot.Modules.Permissions.Classes;
using Discord.Commands;
using NadekoBot.Classes;
using System.Text.RegularExpressions;
using System.Threading;
using NadekoBot._Models.DataModels;
using NadekoBot.Modules.TreeOfSavior.Commands;

namespace NadekoBot.Modules.TreeOfSavior
{
    internal class TreeOfSaviorModule : DiscordModule
    {
        //public TreeOfSaviorModule()
        //{
        //    commands.Add(new WorldBoss(this));
        //}
        public override string Prefix { get; } = NadekoBot.Config.CommandPrefixes.TreeOfSavior;
        public override void Install(ModuleManager manager)
        {
            manager.CreateCommands("", x =>
            {
                x.AddCheck(PermissionChecker.Instance);
                x.CreateCommand(Prefix + "tosbase")
                    .Alias(Prefix + "tbs")
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
                    .Description("Display top 5 tosneet attributes from your query")
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
                x.CreateCommand(Prefix + "tosneetitems")
                    .Alias(Prefix + "tni")
                    .Description("Display top 5 tosneet items from your query")
                    .Parameter("query", ParameterType.Unparsed)
                    .Do(async e =>
                    {

                        var query = e.GetArg("query")?.Trim() ?? "";
                        var links = await Task.WhenAll(SearchHelper.GetTosNeetItemsLink(query)).ConfigureAwait(false);
                        if (links.All(l => l == null))
                        {
                            await e.Channel.SendMessage("`No results.`");
                            return;
                        }
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
                x.CreateCommand(Prefix + "tosneetzones")
                    .Alias(Prefix + "tnz")
                    .Description("Display top 5 tosneet zones from your query")
                    .Parameter("query", ParameterType.Unparsed)
                    .Do(async e =>
                    {

                        var query = e.GetArg("query")?.Trim() ?? "";
                        var links = await Task.WhenAll(SearchHelper.GetTosNeetZonesLink(query)).ConfigureAwait(false);

                        if (links.All(l => l == null))
                        {
                            await e.Channel.SendMessage("`No results.`");
                            return;
                        }
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
                x.CreateCommand(Prefix + "tosplanner")
                    .Alias(Prefix + "tpl")
                    .Description("Give you a planner link from tos.neet.tv")
                    .Do(async e =>
                    {
                        await e.Channel.SendMessage("https://tos.neet.tv/skill-planner").ConfigureAwait(false);
                    });
            });
            manager.CreateCommands("", x =>
            {
                x.AddCheck(PermissionChecker.Instance);
                x.CreateCommand(Prefix + "tosneetstatuseffect")
                .Alias(Prefix + "tns")
                .Description("")
                .Parameter("query", ParameterType.Unparsed)
                .Do(async e =>
                {
                    var query = e.GetArg("query")?.Trim() ?? "";
                    var links = await Task.WhenAll(SearchHelper.GetTosNeetBuffLink(query)).ConfigureAwait(false);

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
                });
            });
            manager.CreateCommands("", x =>
            {
                x.AddCheck(PermissionChecker.Instance);
                x.CreateCommand(Prefix + "worldbossinfo")
                .Alias(Prefix + "wbi")
                .Description("Gives you world boss informations")
                .Do(async e =>
                {
                    await e.Channel.SendMessage("https://tos.neet.tv/skill-planner").ConfigureAwait(false);
                });
            });
            manager.CreateCommands("", x =>
            {
                x.AddCheck(PermissionChecker.Instance);
                x.CreateCommand(Prefix + "tosneetquests")
                    .Alias(Prefix + "tnq")
                    .Description("Gives you information about quests")
                    .Parameter("query", ParameterType.Unparsed)
                    .Do(async e =>
                    {
                        var query = e.GetArg("query")?.Trim() ?? "";
                        var links = await Task.WhenAll(SearchHelper.GetTosNeetQuests(query)).ConfigureAwait(false);

                        if (links.All(l => l == null))
                        {
                            await e.Channel.SendMessage("`No results.`");
                            return;
                        }
                        if (links.All(l => l.Count() > 3))
                        {
                            await e.Channel.SendMessage("`More than 3 items has been found`");
                        }

                        foreach (var li in links)
                        {
                            foreach (var l in li)
                            {
                                var _links = l;
                                await e.Channel.SendMessage(_links).ConfigureAwait(false);
                            }
                        }
                        await e.Channel.SendMessage("`Please visit https://tos.neet.tv/quests?q=" + query + " for more results`");
                    });
            });
            //throw new NotImplementedException();
            //manager.CreateCommands("", x =>
            //{
            //    x.AddCheck(PermissionChecker.Instance);
            //    x.CreateCommand(Prefix + "worldboss")
            //        .Alias(Prefix + "wb")
            //        .Description("Register any boss event " +
            //                     "argument is ")
            //        .Parameter("boss", ParameterType.Required)
            //        .Parameter("channel", ParameterType.Required)
            //        .Parameter("status", ParameterType.Required)
            //        .Parameter("time",ParameterType.Required)
            //        .Do(async e =>
            //        {
                        
            //        });
            //});
        }
    }
}
