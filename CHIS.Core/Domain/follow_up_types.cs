using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class follow_up_types
    {
        public int id { get; set; }
        public string type_name { get; set; }
        public string color { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }
    }
}
