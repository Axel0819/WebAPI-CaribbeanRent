using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Contact
    {
        public Guid Idcontact { get; set; }
        public Guid Uid { get; set; }
        public string Contact1 { get; set; } = null!;

        public virtual UserCr UidNavigation { get; set; } = null!;
    }
}
