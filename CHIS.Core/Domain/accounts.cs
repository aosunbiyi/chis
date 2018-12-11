using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class accounts
    {
        public accounts()
        {
            laundry_guest_laundry_transactions = new HashSet<laundry_guest_laundry_transactions>();
            reservations = new HashSet<reservations>();
        }

        public int id { get; set; }
        public int account_type_id { get; set; }
        public int? hotel_representative_id { get; set; }
        public string alias { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string account_number { get; set; }
        public decimal? credit_limit { get; set; }
        public decimal? opening_balance { get; set; }
        public decimal? payment_term { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string postal_code { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public string credit_card_type { get; set; }
        public string card_holder { get; set; }
        public string card_number { get; set; }
        public DateTime? exp_date { get; set; }
        public string group_name { get; set; }
        public string reg_number { get; set; }
        public string reg_number1 { get; set; }
        public string reg_number2 { get; set; }
        public DateTime? created_on { get; set; }
        public string created_by { get; set; }
        public string remark { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public account_types account_type_ { get; set; }
        public hotel_representatives hotel_representative_ { get; set; }
        public ICollection<laundry_guest_laundry_transactions> laundry_guest_laundry_transactions { get; set; }
        public ICollection<reservations> reservations { get; set; }
    }
}
