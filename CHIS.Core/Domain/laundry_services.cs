using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class laundry_services
    {
        public laundry_services()
        {
            laundry_guest_laundry_transactions = new HashSet<laundry_guest_laundry_transactions>();
            laundry_hotel_laundry_transactions = new HashSet<laundry_hotel_laundry_transactions>();
            laundry_items_laundry_services = new HashSet<laundry_items_laundry_services>();
        }

        public int id { get; set; }
        public string service_name { get; set; }
        public string service_image { get; set; }
        public string description { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public ICollection<laundry_guest_laundry_transactions> laundry_guest_laundry_transactions { get; set; }
        public ICollection<laundry_hotel_laundry_transactions> laundry_hotel_laundry_transactions { get; set; }
        public ICollection<laundry_items_laundry_services> laundry_items_laundry_services { get; set; }
    }
}
