using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class laundry_hotel_services
    {
        public laundry_hotel_services()
        {
            laundry_guest_laundry_transactions = new HashSet<laundry_guest_laundry_transactions>();
            laundry_hotel_laundry_transactions = new HashSet<laundry_hotel_laundry_transactions>();
        }

        public int id { get; set; }
        public string service_name { get; set; }
        public string description { get; set; }
        public decimal? extra_charges { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public ICollection<laundry_guest_laundry_transactions> laundry_guest_laundry_transactions { get; set; }
        public ICollection<laundry_hotel_laundry_transactions> laundry_hotel_laundry_transactions { get; set; }
    }
}
