using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class notices
    {
        public int id { get; set; }
        public string notice_title { get; set; }
        public string notice_body { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }
    }
}
