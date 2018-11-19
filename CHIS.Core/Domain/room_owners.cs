using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class room_owners
    {
        public room_owners()
        {
            rooms = new HashSet<rooms>();
        }

        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string description { get; set; }
        public string room_plan { get; set; }
        public decimal? amount { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public ICollection<rooms> rooms { get; set; }
    }
}
