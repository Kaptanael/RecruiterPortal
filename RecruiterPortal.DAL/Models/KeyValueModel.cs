using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterPortalDAL.Models
{
    public class KeyValueModel
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public bool Checked { get; set; } = false;
    }
}
