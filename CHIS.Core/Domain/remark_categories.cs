using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class remark_categories
    {
        public remark_categories()
        {
            remarks = new HashSet<remarks>();
        }

        public int id { get; set; }
        public string alias { get; set; }
        public int? sort_key { get; set; }
        public string category_name { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public ICollection<remarks> remarks { get; set; }
    }
}
