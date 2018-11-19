using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class extra_charge_categories
    {
        public extra_charge_categories()
        {
            extra_charges = new HashSet<extra_charges>();
        }

        public int id { get; set; }
        public string alias { get; set; }
        public string category_name { get; set; }
        public string description { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public ICollection<extra_charges> extra_charges { get; set; }
    }
}
