using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class laundry_packaging_types
    {
        public laundry_packaging_types()
        {
            laundry_guest_laundry_transactions = new HashSet<laundry_guest_laundry_transactions>();
            laundry_hotel_laundry_transactions = new HashSet<laundry_hotel_laundry_transactions>();
        }

        public int id { get; set; }
        public string packaging_name { get; set; }
        public string packaging_image { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public ICollection<laundry_guest_laundry_transactions> laundry_guest_laundry_transactions { get; set; }
        public ICollection<laundry_hotel_laundry_transactions> laundry_hotel_laundry_transactions { get; set; }
    }
}
