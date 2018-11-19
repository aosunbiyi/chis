using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class settlement_types
    {
        public settlement_types()
        {
            card_type_prefixes = new HashSet<card_type_prefixes>();
            settlements = new HashSet<settlements>();
        }

        public int id { get; set; }
        public string settlement_name { get; set; }
        public byte? can_generate_receipt { get; set; }
        public string prefix { get; set; }
        public string suffix { get; set; }
        public long? start_index { get; set; }
        public long? current_index { get; set; }
        public string alias { get; set; }
        public byte? active { get; set; }
        public string payment_option { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public ICollection<card_type_prefixes> card_type_prefixes { get; set; }
        public ICollection<settlements> settlements { get; set; }
    }
}
