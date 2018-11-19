using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class floors
    {
        public floors()
        {
            rooms = new HashSet<rooms>();
        }

        public int id { get; set; }
        public int wing_id { get; set; }
        public string floor_name { get; set; }
        public string alias { get; set; }
        public int? sort_key { get; set; }
        public string description { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public wings wing_ { get; set; }
        public ICollection<rooms> rooms { get; set; }
    }
}
