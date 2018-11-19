using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class meal_plans
    {
        public int id { get; set; }
        public string alias { get; set; }
        public string meal_plan_name { get; set; }
        public string description { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }
    }
}
