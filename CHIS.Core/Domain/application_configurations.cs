using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class application_configurations
    {
        public int id { get; set; }
        public string application_name { get; set; }
        public string application_logo { get; set; }
        public string login_banner { get; set; }
        public string application_theme { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }
    }
}
