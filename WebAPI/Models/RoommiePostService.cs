using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class RoommiePostService
    {
        public int IdroommieService { get; set; }
        public int IdroommiePost { get; set; }
        public int Idservice { get; set; }

        public virtual RoommiePost IdroommiePostNavigation { get; set; } = null!;
        public virtual Service IdserviceNavigation { get; set; } = null!;
    }
}
