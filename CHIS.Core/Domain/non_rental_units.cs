using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class non_rental_units
    {
        public int id { get; set; }
        public string alias { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal? amount { get; set; }
        public decimal? min_deposit { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }
    }
}
