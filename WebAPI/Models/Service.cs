using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Service
    {
        public Service()
        {
            RentPostServices = new HashSet<RentPostService>();
            RoommiePostServices = new HashSet<RoommiePostService>();
        }

        public int Idservice { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<RentPostService> RentPostServices { get; set; }
        public virtual ICollection<RoommiePostService> RoommiePostServices { get; set; }
    }
}
