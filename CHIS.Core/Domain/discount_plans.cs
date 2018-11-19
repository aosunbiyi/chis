using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class discount_plans
    {
        public discount_plans()
        {
            reservations = new HashSet<reservations>();
        }

        public int id { get; set; }
        public string plan_name { get; set; }
        public string plan_category { get; set; }
        public string note { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public ICollection<reservations> reservations { get; set; }
    }
}
