using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class invoice_settings
    {
        public int id { get; set; }
        public string invoice_variable_name { get; set; }
        public string number_type { get; set; }
        public string prefix { get; set; }
        public int? start_from { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }
    }
}
