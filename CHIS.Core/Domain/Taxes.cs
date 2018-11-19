using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class taxes
    {
        public int id { get; set; }
        public string tax_name { get; set; }
        public int? duration { get; set; }
        public byte? charge_on_extra_adult { get; set; }
        public byte? charge_on_extra_child { get; set; }
        public DateTime? start_day { get; set; }
        public string format { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }
    }
}
