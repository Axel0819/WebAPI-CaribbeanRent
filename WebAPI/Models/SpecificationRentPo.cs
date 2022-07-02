using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class SpecificationRentPo
    {
        public int IdspecificationRentPos { get; set; }
        public int IdrentPost { get; set; }
        public int NumBedrooms { get; set; }
        public int NumToilets { get; set; }
        public decimal Price { get; set; }

        public virtual RentPost IdrentPostNavigation { get; set; } = null!;
    }
}
