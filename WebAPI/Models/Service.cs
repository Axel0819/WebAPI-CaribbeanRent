using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public partial class Service
    {
        public Service()
        {
            RentPostServices = new HashSet<RentPostService>();
            RoomiePostServices = new HashSet<RoomiePostService>();
        }

        public int Idservice { get; set; }
        public string Name { get; set; } = null!;
        public int? State { get; set; }

        [JsonIgnore]
        public virtual ICollection<RentPostService> RentPostServices { get; set; }
        [JsonIgnore]
        public virtual ICollection<RoomiePostService> RoomiePostServices { get; set; }
    }
}
