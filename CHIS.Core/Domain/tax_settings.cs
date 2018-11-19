using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class tax_settings
    {
        public int id { get; set; }
        public int tax_setting_type_id { get; set; }
        public decimal? amount { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public tax_setting_types tax_setting_type_ { get; set; }
    }
}
