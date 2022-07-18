using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public partial class Contact
    {
        public int Idcontact { get; set; }
        public int Uid { get; set; }
        public string Contact1 { get; set; } = null!;

        [JsonIgnore]
        public virtual UserCr UidNavigation { get; set; } = null!;
    }
}
