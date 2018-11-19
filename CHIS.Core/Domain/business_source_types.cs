using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class business_source_types
    {
        public business_source_types()
        {
            business_sources = new HashSet<business_sources>();
        }

        public int id { get; set; }
        public string alias { get; set; }
        public string business_source_type_name { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public ICollection<business_sources> business_sources { get; set; }
    }
}
