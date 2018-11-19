using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class room_types
    {
        public room_types()
        {
            room_types_rates = new HashSet<room_types_rates>();
            rooms = new HashSet<rooms>();
        }

        public int id { get; set; }
        public string room_type_name { get; set; }
        public string alias { get; set; }
        public int? sort_key { get; set; }
        public string description { get; set; }
        public int? max_adult { get; set; }
        public int? max_child { get; set; }
        public string back_color { get; set; }
        public byte? inactive { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public ICollection<room_types_rates> room_types_rates { get; set; }
        public ICollection<rooms> rooms { get; set; }
    }
}
