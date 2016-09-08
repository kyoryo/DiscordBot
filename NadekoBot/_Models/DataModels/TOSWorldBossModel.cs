using NadekoBot.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadekoBot._Models.DataModels
{
    class TOSWorldBossModel : IDataModel
    {
        public DateTime When { get; set; } //ETA
        public long ChannelId { get; set; }
        public long ServerId { get; set; }
        public long UserId { get; set; }
        public string BossName { get; set; }
        public string BossStatus { get; set; }
        public string BossChannel { get; set; }
        public DateTime Time { get; set; } //condition time: last dead time or new time
        public string Message { get; set; }
        public bool IsPrivate { get; set; }
    }
}
