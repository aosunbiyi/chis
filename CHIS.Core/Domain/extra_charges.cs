using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class extra_charges
    {
        public int id { get; set; }
        public string alias { get; set; }
        public string extra_charge_name { get; set; }
        public string description { get; set; }
        public int extra_charge_category_id { get; set; }
        public decimal? rate { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public extra_charge_categories extra_charge_category_ { get; set; }
    }
}
