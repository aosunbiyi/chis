using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class laundry_items_laundry_services
    {
        public int laundry_item_id { get; set; }
        public int laundry_service_id { get; set; }

        public laundry_items laundry_item_ { get; set; }
        public laundry_services laundry_service_ { get; set; }
    }
}
