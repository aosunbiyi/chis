using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class exchange_rates
    {
        public int id { get; set; }
        public string country_name { get; set; }
        public byte? active { get; set; }
        public int? decimal_place { get; set; }
        public string currency_name { get; set; }
        public string currency_symbol { get; set; }
        public string symbol_placement { get; set; }
        public decimal? exchange_rate { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }
    }
}
