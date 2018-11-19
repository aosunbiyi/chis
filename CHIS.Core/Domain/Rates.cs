using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class rates
    {
        public rates()
        {
            room_types_rates = new HashSet<room_types_rates>();
        }

        public int id { get; set; }
        public int rate_type_id { get; set; }
        public string rate_name { get; set; }
        public decimal? amount { get; set; }
        public byte? isweekday { get; set; }
        public byte? isspecial { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public byte? isactive { get; set; }
        public decimal? extra_adult { get; set; }
        public decimal? extra_child { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public rate_types rate_type_ { get; set; }
        public ICollection<room_types_rates> room_types_rates { get; set; }
    }
}
