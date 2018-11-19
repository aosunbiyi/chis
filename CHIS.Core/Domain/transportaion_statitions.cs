using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class transportaion_statitions
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }
    }
}
