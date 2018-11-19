using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class card_type_prefixes
    {
        public int id { get; set; }
        public string prefix { get; set; }
        public string credit_card_type { get; set; }
        public int? settlement_type_id { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public settlement_types settlement_type_ { get; set; }
    }
}
