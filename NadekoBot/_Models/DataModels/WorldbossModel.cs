using NadekoBot.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadekoBot._Models.DataModels
{
    class WorldbossModel : IDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public WBTypes Type { get; set; }
        public enum WBTypes {
            fieldboss,
            worldboss
        }
    }
    
}
