using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class amenities
    {
        public amenities()
        {
            rooms_amenities = new HashSet<rooms_amenities>();
        }

        public int id { get; set; }
        public int? amenity_type_id { get; set; }
        public string amenity_name { get; set; }
        public string amenity_logo { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public ICollection<rooms_amenities> rooms_amenities { get; set; }
    }
}
