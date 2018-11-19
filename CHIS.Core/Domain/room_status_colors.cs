using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class room_status_colors
    {
        public int id { get; set; }
        public string status_type { get; set; }
        public string status_name { get; set; }
        public string color_name { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }
    }
}
