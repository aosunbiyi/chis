using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class rooms
    {
        public rooms()
        {
            reserved_rooms = new HashSet<reserved_rooms>();
            room_images = new HashSet<room_images>();
            rooms_amenities = new HashSet<rooms_amenities>();
            rooms_week_days = new HashSet<rooms_week_days>();
        }

        public int id { get; set; }
        public int room_type_id { get; set; }
        public int floor_id { get; set; }
        public string alias { get; set; }
        public int? sort_key { get; set; }
        public string room_name { get; set; }
        public int? room_owner_id { get; set; }
        public string phone_extension { get; set; }
        public string data_extension { get; set; }
        public string keycard_alias { get; set; }
        public string power_code { get; set; }
        public string remark { get; set; }
        public byte? inactive { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public floors floor_ { get; set; }
        public room_owners room_owner_ { get; set; }
        public room_types room_type_ { get; set; }
        public ICollection<reserved_rooms> reserved_rooms { get; set; }
        public ICollection<room_images> room_images { get; set; }
        public ICollection<rooms_amenities> rooms_amenities { get; set; }
        public ICollection<rooms_week_days> rooms_week_days { get; set; }
    }
}
