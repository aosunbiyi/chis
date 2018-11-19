using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class reservation_log_entries
    {
        public int id { get; set; }
        public int reservation_id { get; set; }
        public int reserved_room_id { get; set; }
        public string action { get; set; }
        public DateTime? log_date { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }
    }
}
