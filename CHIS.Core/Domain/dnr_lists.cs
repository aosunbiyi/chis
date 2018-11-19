using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class dnr_lists
    {
        public int id { get; set; }
        public string alias { get; set; }
        public string dnr_name { get; set; }
        public string description { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }
    }
}
