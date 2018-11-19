using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class seasons
    {
        public int id { get; set; }
        public int season_type_id { get; set; }
        public string alias { get; set; }
        public string season_name { get; set; }
        public string deacription { get; set; }
        public int? from_day { get; set; }
        public int? to_day { get; set; }
        public string from_month { get; set; }
        public string to_month { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public season_types season_type_ { get; set; }
    }
}
