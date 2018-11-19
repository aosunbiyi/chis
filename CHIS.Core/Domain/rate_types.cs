using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class rate_types
    {
        public rate_types()
        {
            rates = new HashSet<rates>();
        }

        public int id { get; set; }
        public string rate_type_name { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public ICollection<rates> rates { get; set; }
    }
}
