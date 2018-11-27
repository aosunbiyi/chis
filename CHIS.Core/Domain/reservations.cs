using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class reservations
    {
        public reservations()
        {
            arrival_departure_infos = new HashSet<arrival_departure_infos>();
            reservation_payments = new HashSet<reservation_payments>();
            reservation_transaction = new HashSet<reservation_transaction>();
            reserved_rooms = new HashSet<reserved_rooms>();
        }

        public int id { get; set; }
        public string reservation_number { get; set; }
        public string code { get; set; }
        public DateTime? arrival { get; set; }
        public string arrival_time { get; set; }
        public DateTime? departure { get; set; }
        public string departure_time { get; set; }
        public int? num_of_night { get; set; }
        public int? num_of_adult { get; set; }
        public int? num_of_children { get; set; }
        public int account_id { get; set; }
        public string book_by { get; set; }
        public DateTime? book_on { get; set; }
        public int? business_source_id { get; set; }
        public decimal? total_booking { get; set; }
        public decimal? amount_paid { get; set; }
        public decimal? balance { get; set; }
        public string reservation_status { get; set; }
        public string account_number { get; set; }
        public byte? apply_discount { get; set; }
        public string bank_name { get; set; }
        public string branch_name { get; set; }
        public string cheque { get; set; }
        public string discount_code { get; set; }
        public int? discount_plan { get; set; }
        public decimal? discount_value { get; set; }
        public decimal discount_amount { get; set; }
        public string payment_status { get; set; }
        public int last_payment_id { get; set; }
        public decimal total_amount_with_discount { get; set; }
        public decimal total_balance_with_discount { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public accounts account_ { get; set; }
        public business_sources business_source_ { get; set; }
        public discount_plans discount_planNavigation { get; set; }
        public ICollection<arrival_departure_infos> arrival_departure_infos { get; set; }
        public ICollection<reservation_payments> reservation_payments { get; set; }
        public ICollection<reservation_transaction> reservation_transaction { get; set; }
        public ICollection<reserved_rooms> reserved_rooms { get; set; }
    }
}
