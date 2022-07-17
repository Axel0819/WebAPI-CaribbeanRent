using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class RentPost
    {
        public RentPost()
        {
            Favorites = new HashSet<Favorite>();
            RentPostServices = new HashSet<RentPostService>();
            RentRules = new HashSet<RentRule>();
            ReportRentPosts = new HashSet<ReportRentPost>();
            SpecificationRentPosts = new HashSet<SpecificationRentPost>();
        }

        public int IdrentPost { get; set; }
        public int Uid { get; set; }
        public decimal Price { get; set; }
        public int State { get; set; }
        public DateTime DateCreated { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Coordinates { get; set; } = null!;

        public virtual UserCr UidNavigation { get; set; } = null!;
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<RentPostService> RentPostServices { get; set; }
        public virtual ICollection<RentRule> RentRules { get; set; }
        public virtual ICollection<ReportRentPost> ReportRentPosts { get; set; }
        public virtual ICollection<SpecificationRentPost> SpecificationRentPosts { get; set; }
    }
}
