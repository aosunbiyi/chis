using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class revenue_breakdowns
    {
        public int id { get; set; }
        public string alias { get; set; }
        public int? sort_key { get; set; }
        public string breakdown_name { get; set; }
        public string description { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }
    }
}
