using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class transportations
    {
        public int id { get; set; }
        public int transportation_type_id { get; set; }
        public string name { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public transportation_types transportation_type_ { get; set; }
    }
}
