using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class remarks
    {
        public int id { get; set; }
        public int remark_category_id { get; set; }
        public string alias { get; set; }
        public int? sort_key { get; set; }
        public string reason { get; set; }
        public byte? active { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public remark_categories remark_category_ { get; set; }
    }
}
