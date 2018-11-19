using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class reservation_transaction
    {
        public int id { get; set; }
        public int reservation_id { get; set; }
        public int reserved_room_id { get; set; }
        public decimal? rate { get; set; }
        public decimal? total { get; set; }
        public decimal? total_reservation { get; set; }
        public decimal? total_adult { get; set; }
        public decimal? total_children { get; set; }
        public decimal? paid { get; set; }
        public decimal? balance { get; set; }
        public DateTime? transaction_date { get; set; }
        public string status { get; set; }
        public string payment_method { get; set; }
        public string room_name { get; set; }
        public string room_Type { get; set; }
        public string rate_type { get; set; }
        public string rate_name { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public reservations reservation_ { get; set; }
        public reserved_rooms reserved_room_ { get; set; }
    }
}
