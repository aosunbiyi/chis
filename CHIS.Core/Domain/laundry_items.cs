using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class laundry_items
    {
        public laundry_items()
        {
            laundry_guest_laundry_transaction_items = new HashSet<laundry_guest_laundry_transaction_items>();
            laundry_hotel_laundry_transaction_items = new HashSet<laundry_hotel_laundry_transaction_items>();
            laundry_items_laundry_services = new HashSet<laundry_items_laundry_services>();
        }

        public int id { get; set; }
        public string item_name { get; set; }
        public string code { get; set; }
        public int? laundry_item_category_id { get; set; }
        public string item_type { get; set; }
        public decimal? charges { get; set; }
        public string description { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public laundry_item_categories laundry_item_category_ { get; set; }
        public ICollection<laundry_guest_laundry_transaction_items> laundry_guest_laundry_transaction_items { get; set; }
        public ICollection<laundry_hotel_laundry_transaction_items> laundry_hotel_laundry_transaction_items { get; set; }
        public ICollection<laundry_items_laundry_services> laundry_items_laundry_services { get; set; }
    }
}
