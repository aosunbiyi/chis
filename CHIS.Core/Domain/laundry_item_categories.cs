using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class laundry_item_categories
    {
        public laundry_item_categories()
        {
            laundry_items = new HashSet<laundry_items>();
        }

        public int id { get; set; }
        public string category_name { get; set; }
        public string description { get; set; }
        public string category_image { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public ICollection<laundry_items> laundry_items { get; set; }
    }
}
