using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class business_sources
    {
        public business_sources()
        {
            reservations = new HashSet<reservations>();
        }

        public int id { get; set; }
        public int business_source_types_id { get; set; }
        public string alias { get; set; }
        public string business_source_name { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public business_source_types business_source_types_ { get; set; }
        public ICollection<reservations> reservations { get; set; }
    }
}
