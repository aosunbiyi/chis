using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class rooms_week_days
    {
        public int room_id { get; set; }
        public int week_day_id { get; set; }

        public rooms room_ { get; set; }
        public week_days week_day_ { get; set; }
    }
}
