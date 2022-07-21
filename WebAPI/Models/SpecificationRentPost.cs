using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public partial class SpecificationRentPost
    {
        public int IdspecificationRentPost { get; set; }
        public int IdrentPost { get; set; }
        public int NumBedrooms { get; set; }
        public int NumToilets { get; set; }

        [JsonIgnore]
        public virtual RentPost IdrentPostNavigation { get; set; } = null!;
    }
}
