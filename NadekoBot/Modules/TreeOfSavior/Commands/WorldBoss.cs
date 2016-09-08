using Discord;
using Discord.Commands;
using NadekoBot._Models.DataModels;
using NadekoBot.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace NadekoBot.Modules.TreeOfSavior.Commands
{
    class WorldBoss : DiscordCommand
    {
        Regex regexRemind = new Regex(@"^(?:(?<months>\d)mo)?(?:(?<weeks>\d)w)?(?:(?<days>\d{1,2})d)?(?:(?<hours>\d{1,2})h)?(?:(?<minutes>\d{1,2})m)?$",
                                RegexOptions.Compiled | RegexOptions.Multiline);
        Regex regex = new Regex(@"^(?:(?<hours>\d{1,2}))(?:(?<minutes>\d{1,2}))(?<convention>(?i)am|pm)?$", RegexOptions.Compiled | RegexOptions.Multiline);
        //Regex regex = new Regex(@"^(?:(?<hours>\d{1,2}))(?:(?<minutes>\d{1,2}))$", RegexOptions.Compiled | RegexOptions.Multiline);
        List<Timer> reminders = new List<Timer>();
        public WorldBoss(DiscordModule module) : base(module)
        {
            var remList = DbHandler.Instance.GetAllRows<TOSWorldBossModel>();

            reminders = remList.Select(StartNewReminder).ToList();
        }
        IDictionary<string, Func<TOSWorldBossModel, string>> replacements = new Dictionary<string, Func<TOSWorldBossModel, string>>
        {
            { "%message%" , (r) => r.Message },
            { "%user%", (r) => $"<@!{r.UserId}>" },
            { "%target%", (r) =>  r.IsPrivate ? "Direct Message" : $"<#{r.ChannelId}>"}
        };
        private Timer StartNewReminder(TOSWorldBossModel r)
        {
            var now = DateTime.Now;
            return null;
        }
        internal override void Init(CommandGroupBuilder command)
        {
            command.CreateCommand(Module.Prefix + "wb")
                .Description("register a boss timer and remind you when closed to ETA")
                .Parameter("boss", ParameterType.Required) //bossname
                .Parameter("channel", ParameterType.Required) //channel at
                .Parameter("status", ParameterType.Required) //current status, in or dead
                .Parameter("time", ParameterType.Required) //dead time or entering time
                .Parameter("nextlocation", ParameterType.Optional) //upcoming spawn place
                .Do(async e =>
                {
                    //contoh command !wbi necro 1 in 0522
                    Channel channel = e.Channel; //current discord channel
                    var bossname = e.GetArg("boss");
                    var bosschannel = e.GetArg("channel");
                    var bossstatus = e.GetArg("status");
                    var bosstime = e.GetArg("time");
                    var bossnextlocation = e.GetArg("nextlocation");

                    var match = regex.Match(bosstime);
                    if (match.Length == 0)
                    {
                        await e.Channel.SendMessage("Not a valid time format").ConfigureAwait(false);
                        return;
                    }
                    var nameandvalue = new Dictionary<string, int>();

                    foreach (var groupName in regex.GetGroupNames())
                    {
                        if (groupName == "0") continue;
                        var hours = match.Groups["hours"];
                        var minutes = match.Groups["minutes"];
                        var tt = match.Groups["convention"];

                        await e.Channel.SendMessage($"`{hours}`:`{minutes}` `{tt}`").ConfigureAwait(false);
                    }
                    
                    //foreach (var groupName in regex.GetGroupNames())
                    //{

                    //    if (groupName == "0") continue;
                    //    var value = 0;
                    //    int.TryParse(match.Groups[groupName].Value, out value);

                    //    if (string.IsNullOrEmpty(match.Groups[groupName].Value))
                    //    {
                    //        nameandvalue[groupName] = 0;
                    //        continue;
                    //    }else if (value < 1)
                    //    {
                    //        await e.Channel.SendMessage($"Invalid {groupName} value.").ConfigureAwait(false);
                    //        return;
                    //    }

                    //}


                    //if (string.IsNullOrEmpty())
                    //{
                    //    nameandvalue[groupName] = 0;
                    //    continue;
                    //}


                    //await e.Channel.SendMessage($"⏰ok").ConfigureAwait(false);

                    //ETA minimum for {bossname} on {where} channel {id}
                    //await e.Channel.SendMessage($"⏰ I will remind \"{channel.Name}\" to \"{e.GetArg("message").ToString()}\" in {output}. ({time:d.M.yyyy.} at {time:HH:mm})").ConfigureAwait(false);
                });
        }
    }
}
