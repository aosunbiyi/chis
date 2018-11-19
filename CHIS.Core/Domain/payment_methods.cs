using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class payment_methods
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }
    }
}
