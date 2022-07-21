using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public partial class Favorite
    {
        public int Idfavorite { get; set; }
        public int Uid { get; set; }
        public int IdrentPost { get; set; }

        [JsonIgnore]
        public virtual RentPost IdrentPostNavigation { get; set; } = null!;
        [JsonIgnore]
        public virtual UserCr UidNavigation { get; set; } = null!;
    }
}
