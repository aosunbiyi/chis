using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class room_images
    {
        public int id { get; set; }
        public int room_id { get; set; }
        public string image_url { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public rooms room_ { get; set; }
    }
}
