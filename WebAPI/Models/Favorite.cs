using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Favorite
    {
        public int Idfavorite { get; set; }
        public Guid Uid { get; set; }
        public int IdrentPost { get; set; }

        public virtual RentPost IdrentPostNavigation { get; set; } = null!;
        public virtual UserCr UidNavigation { get; set; } = null!;
    }
}
