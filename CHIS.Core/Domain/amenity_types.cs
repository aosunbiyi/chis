using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class amenity_types
    {
        public int id { get; set; }
        public string amenity_type_name { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }
    }
}
