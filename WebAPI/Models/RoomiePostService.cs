using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public partial class RoomiePostService
    {
        public int IdroomieService { get; set; }
        public int IdroomiePost { get; set; }
        public int Idservice { get; set; }

        [JsonIgnore]
        public virtual RoomiePost IdroomiePostNavigation { get; set; } = null!;
        [JsonIgnore]
        public virtual Service IdserviceNavigation { get; set; } = null!;
    }
}
