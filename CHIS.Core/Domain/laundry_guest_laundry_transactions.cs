using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class laundry_guest_laundry_transactions
    {
        public laundry_guest_laundry_transactions()
        {
            laundry_guest_laundry_transaction_items = new HashSet<laundry_guest_laundry_transaction_items>();
            laundry_hotel_laundry_transaction_items = new HashSet<laundry_hotel_laundry_transaction_items>();
        }

        public int id { get; set; }
        public string code { get; set; }
        public int room_id { get; set; }
        public int account_id { get; set; }
        public DateTime? transaction_date { get; set; }
        public string transaction_time { get; set; }
        public DateTime? delivery_date { get; set; }
        public string delivery_time { get; set; }
        public int laundry_packaging_type_id { get; set; }
        public int laundry_service_id { get; set; }
        public int laundry_hotel_service_id { get; set; }
        public decimal? total_charges { get; set; }
        public string status { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public accounts account_ { get; set; }
        public laundry_hotel_services laundry_hotel_service_ { get; set; }
        public laundry_packaging_types laundry_packaging_type_ { get; set; }
        public laundry_services laundry_service_ { get; set; }
        public rooms room_ { get; set; }
        public ICollection<laundry_guest_laundry_transaction_items> laundry_guest_laundry_transaction_items { get; set; }
        public ICollection<laundry_hotel_laundry_transaction_items> laundry_hotel_laundry_transaction_items { get; set; }
    }
}
