using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class email_accounts
    {
        public int id { get; set; }
        public string sender_name { get; set; }
        public string email_address { get; set; }
        public string mail_server { get; set; }
        public string mail_server_port { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public byte? login_using_ssl { get; set; }
        public byte? use_proxysettings { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }
    }
}
