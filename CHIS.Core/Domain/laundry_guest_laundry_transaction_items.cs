using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class laundry_guest_laundry_transaction_items
    {
        public int id { get; set; }
        public int laundry_guest_laundry_transaction_id { get; set; }
        public int laundry_item_id { get; set; }
        public int? quantity { get; set; }
        public decimal? charges { get; set; }
        public decimal? total_charges { get; set; }
        public string status { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public laundry_guest_laundry_transactions laundry_guest_laundry_transaction_ { get; set; }
        public laundry_items laundry_item_ { get; set; }
    }
}
