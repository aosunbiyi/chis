using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class laundry_hotel_laundry_transactions
    {
        public int id { get; set; }
        public string code { get; set; }
        public DateTime? transaction_date { get; set; }
        public string transaction_time { get; set; }
        public DateTime? delivery_date { get; set; }
        public string delivery_time { get; set; }
        public int laundry_packaging_type_id { get; set; }
        public int laundry_service_id { get; set; }
        public int laundry_hotel_service_id { get; set; }
        public string status { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public laundry_hotel_services laundry_hotel_service_ { get; set; }
        public laundry_packaging_types laundry_packaging_type_ { get; set; }
        public laundry_services laundry_service_ { get; set; }
    }
}
