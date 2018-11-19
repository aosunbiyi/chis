using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class week_days
    {
        public week_days()
        {
            rooms_week_days = new HashSet<rooms_week_days>();
        }

        public int id { get; set; }
        public string day_name { get; set; }
        public byte? isweekday { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public ICollection<rooms_week_days> rooms_week_days { get; set; }
    }
}
