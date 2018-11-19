using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class arrival_departure_infos
    {
        public int id { get; set; }
        public int reservation_id { get; set; }
        public string transaction_type { get; set; }
        public DateTime? pickup_date { get; set; }
        public string pickup_time { get; set; }

        public reservations reservation_ { get; set; }
    }
}
