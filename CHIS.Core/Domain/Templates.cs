using System;
using System.Collections.Generic;

namespace CHIS.Core.Domain
{
    public partial class templates
    {
        public int id { get; set; }
        public string alias { get; set; }
        public string template_code { get; set; }
        public string template_title { get; set; }
        public string template_body { get; set; }
        public string default_template_body { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }
    }
}
