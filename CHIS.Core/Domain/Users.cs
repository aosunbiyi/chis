using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class users
    {
        public users()
        {
            users_roles = new HashSet<users_roles>();
        }

        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public byte? active { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public ICollection<users_roles> users_roles { get; set; }
    }
}
