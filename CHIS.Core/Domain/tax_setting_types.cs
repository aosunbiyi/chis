using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class tax_setting_types
    {
        public tax_setting_types()
        {
            tax_settings = new HashSet<tax_settings>();
        }

        public int id { get; set; }
        public string tax_setting_name { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public ICollection<tax_settings> tax_settings { get; set; }
    }
}
