using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public virtual UserCr UidNavigation { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Favorite> Favorites { get; set; }
        [JsonIgnore]
        public virtual ICollection<Image> Images { get; set; }
        [JsonIgnore]
        public virtual ICollection<RentPostService> RentPostServices { get; set; }
        [JsonIgnore]
        public virtual ICollection<RentRule> RentRules { get; set; }
        [JsonIgnore]
        public virtual ICollection<ReportRentPost> ReportRentPosts { get; set; }
        [JsonIgnore]
        public virtual ICollection<SpecificationRentPost> SpecificationRentPosts { get; set; }
    }
}
