using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class wings
    {
        public wings()
        {
            floors = new HashSet<floors>();
        }

        public int id { get; set; }
        public string wing_name { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public ICollection<floors> floors { get; set; }
    }
}
