using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class RentPost
    {
        public RentPost()
        {
            Favorites = new HashSet<Favorite>();
            Images = new HashSet<Image>();
            RentPostServices = new HashSet<RentPostService>();
            RentRules = new HashSet<RentRule>();
            ReportRentPosts = new HashSet<ReportRentPost>();
            SpecificationRentPos = new HashSet<SpecificationRentPo>();
        }

        public int IdrentPost { get; set; }
        public Guid Uid { get; set; }
        public decimal Price { get; set; }
        public int State { get; set; }
        public DateTime DateCreated { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Coordinates { get; set; } = null!;

        public virtual UserCr UidNavigation { get; set; } = null!;
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<RentPostService> RentPostServices { get; set; }
        public virtual ICollection<RentRule> RentRules { get; set; }
        public virtual ICollection<ReportRentPost> ReportRentPosts { get; set; }
        public virtual ICollection<SpecificationRentPo> SpecificationRentPos { get; set; }
    }
}
