using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class reserved_rooms
    {
        public reserved_rooms()
        {
            reservation_transaction = new HashSet<reservation_transaction>();
        }

        public int id { get; set; }
        public int reservation_id { get; set; }
        public string serial_number { get; set; }
        public int room_type_id { get; set; }
        public int room_id { get; set; }
        public string room_type_name { get; set; }
        public string room_name { get; set; }
        public string original_owner { get; set; }
        public string transfer_owner { get; set; }
        public string reserved_status { get; set; }
        public DateTime? arrival { get; set; }
        public string arrival_time { get; set; }
        public DateTime? departure { get; set; }
        public string departure_time { get; set; }
        public int? num_of_night { get; set; }
        public int? new_account_id { get; set; }
        public int? discount_plan_id { get; set; }
        public decimal? discount_value { get; set; }
        public decimal? total { get; set; }
        public decimal? paid { get; set; }
        public decimal? balance { get; set; }
        public string status { get; set; }
        public int? num_of_adult { get; set; }
        public int? num_of_children { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public reservations reservation_ { get; set; }
        public rooms room_ { get; set; }
        public ICollection<reservation_transaction> reservation_transaction { get; set; }
    }
}
