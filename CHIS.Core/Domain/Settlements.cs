using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class settlements
    {
        public int id { get; set; }
        public int settlement_type_id { get; set; }
        public string settlement_name { get; set; }
        public string prefix { get; set; }
        public string suffix { get; set; }
        public string card_holder_name { get; set; }
        public string card_name { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public settlement_types settlement_type_ { get; set; }
    }
}
