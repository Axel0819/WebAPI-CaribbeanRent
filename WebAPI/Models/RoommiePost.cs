using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class RoommiePost
    {
        public RoommiePost()
        {
            RoommiePostServices = new HashSet<RoommiePostService>();
        }

        public int IdroommiePost { get; set; }
        public Guid Uid { get; set; }
        public int Room { get; set; }
        public string Ubication { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public string Description { get; set; } = null!;

        public virtual UserCr UidNavigation { get; set; } = null!;
        public virtual ICollection<RoommiePostService> RoommiePostServices { get; set; }
    }
}
