using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class RentPostService
    {
        public int IdrentService { get; set; }
        public int IdrentPost { get; set; }
        public int Idservice { get; set; }

        public virtual RentPost IdrentPostNavigation { get; set; } = null!;
        public virtual Service IdserviceNavigation { get; set; } = null!;
    }
}
