using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class reservation_payments
    {
        public int id { get; set; }
        public int reservation_id { get; set; }
        public decimal? total_amount { get; set; }
        public decimal? paid { get; set; }
        public decimal? balance { get; set; }
        public DateTime? transaction_date { get; set; }
        public string status { get; set; }
        public string payment_method { get; set; }
        public string transaction_type { get; set; }
        public byte on_discount { get; set; }
        public int discount_type { get; set; }
        public string discount_name { get; set; }
        public decimal discount_value { get; set; }
        public decimal total_amount_with_discount { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public reservations reservation_ { get; set; }
    }
}
