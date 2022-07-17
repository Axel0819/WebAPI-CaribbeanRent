using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class ReportRentPost
    {
        public int Idreport { get; set; }
        public int IdrentPost { get; set; }
        public int Uidfrom { get; set; }
        public DateTime DateCreated { get; set; }
        public string Description { get; set; } = null!;

        public virtual RentPost IdrentPostNavigation { get; set; } = null!;
    }
}
