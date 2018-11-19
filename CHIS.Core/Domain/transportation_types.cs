using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class transportation_types
    {
        public transportation_types()
        {
            transportations = new HashSet<transportations>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public ICollection<transportations> transportations { get; set; }
    }
}
