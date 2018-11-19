using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class configurations
    {
        public int id { get; set; }
        public DateTime? start_date { get; set; }
        public string country_name { get; set; }
        public string country_alias { get; set; }
        public string curr_sign { get; set; }
        public string state_name { get; set; }
        public string zip { get; set; }
        public int? financial_period_from_day { get; set; }
        public string financial_period_from_month { get; set; }
        public int? financial_period_to_day { get; set; }
        public string financial_period_to_month { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }
    }
}
