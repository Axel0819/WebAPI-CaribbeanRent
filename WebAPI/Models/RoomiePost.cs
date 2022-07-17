using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class RoomiePost
    {
        public RoomiePost()
        {
            RoomiePostServices = new HashSet<RoomiePostService>();
        }

        public int IdroomiePost { get; set; }
        public int Uid { get; set; }
        public int Room { get; set; }
        public string Ubication { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public string Description { get; set; } = null!;

        public virtual UserCr UidNavigation { get; set; } = null!;
        public virtual ICollection<RoomiePostService> RoomiePostServices { get; set; }
    }
}
