using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class room_types_rates
    {
        public int room_type_id { get; set; }
        public int rate_id { get; set; }

        public rates rate_ { get; set; }
        public room_types room_type_ { get; set; }
    }
}
