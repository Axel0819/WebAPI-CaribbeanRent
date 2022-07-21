using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public partial class RuleCr
    {
        public RuleCr()
        {
            RentRules = new HashSet<RentRule>();
        }

        public int Idrule { get; set; }
        public string Name { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<RentRule> RentRules { get; set; }
    }
}
