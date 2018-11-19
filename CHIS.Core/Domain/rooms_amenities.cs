using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class rooms_amenities
    {
        public int room_id { get; set; }
        public int amenity_id { get; set; }

        public amenities amenity_ { get; set; }
        public rooms room_ { get; set; }
    }
}
