using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class hotel_representatives
    {
        public hotel_representatives()
        {
            accounts = new HashSet<accounts>();
        }

        public int id { get; set; }
        public string alias { get; set; }
        public string hotel_representative_name { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public ICollection<accounts> accounts { get; set; }
    }
}
