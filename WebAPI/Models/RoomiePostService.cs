using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class RoomiePostService
    {
        public int IdroomieService { get; set; }
        public int IdroomiePost { get; set; }
        public int Idservice { get; set; }

        public virtual RoomiePost IdroomiePostNavigation { get; set; } = null!;
        public virtual Service IdserviceNavigation { get; set; } = null!;
    }
}
