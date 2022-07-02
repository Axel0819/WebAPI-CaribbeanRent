using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class RentRule
    {
        public int IdrentRule { get; set; }
        public int Idrule { get; set; }
        public int IdrentPost { get; set; }

        public virtual RentPost IdrentPostNavigation { get; set; } = null!;
        public virtual RuleCr IdruleNavigation { get; set; } = null!;
    }
}
