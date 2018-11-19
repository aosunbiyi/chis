using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class property_details
    {
        public int id { get; set; }
        public string property_name { get; set; }
        public string beneficiary_name { get; set; }
        public string property_type { get; set; }
        public string property_grade { get; set; }
        public string registration_number { get; set; }
        public string logo { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string res_phone { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }
    }
}
