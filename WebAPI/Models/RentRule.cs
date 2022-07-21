using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public partial class RentRule
    {
        public int IdrentRule { get; set; }
        public int Idrule { get; set; }
        public int IdrentPost { get; set; }

        [JsonIgnore]
        public virtual RentPost IdrentPostNavigation { get; set; } = null!;
        public virtual RuleCr IdruleNavigation { get; set; } = null!;
    }
}
