using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class account_types
    {
        public account_types()
        {
            accounts = new HashSet<accounts>();
        }

        public int id { get; set; }
        public string alias { get; set; }
        public string account_type_name { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public ICollection<accounts> accounts { get; set; }
    }
}
