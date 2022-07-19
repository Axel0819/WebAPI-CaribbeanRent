using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public partial class Image
    {
        public int Idimage { get; set; }
        public int IdrentPost { get; set; }
        public string Urlimage { get; set; } = null!;

        [JsonIgnore]
        public virtual RentPost IdrentPostNavigation { get; set; } = null!;
    }
}
