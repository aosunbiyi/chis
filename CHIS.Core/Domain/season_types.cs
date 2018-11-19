using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class season_types
    {
        public season_types()
        {
            seasons = new HashSet<seasons>();
        }

        public int id { get; set; }
        public string alias { get; set; }
        public string season_type_name { get; set; }
        public string deacription { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public ICollection<seasons> seasons { get; set; }
    }
}
