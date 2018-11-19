using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class roles
    {
        public roles()
        {
            users_roles = new HashSet<users_roles>();
        }

        public int id { get; set; }
        public string role_name { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public ICollection<users_roles> users_roles { get; set; }
    }
}
