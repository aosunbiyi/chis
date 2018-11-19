using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class users_roles
    {
        public int user_id { get; set; }
        public int role_id { get; set; }

        public roles role_ { get; set; }
        public users user_ { get; set; }
    }
}
