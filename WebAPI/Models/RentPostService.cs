using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public partial class RentPostService
    {
        public int IdrentService { get; set; }
        public int IdrentPost { get; set; }
        public int Idservice { get; set; }

        [JsonIgnore]
        public virtual RentPost IdrentPostNavigation { get; set; } = null!;
        [JsonIgnore]
        public virtual Service IdserviceNavigation { get; set; } = null!;
    }
}
