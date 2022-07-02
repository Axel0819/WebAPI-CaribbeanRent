using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class InfoUser
    {
        public Guid IdinfoUser { get; set; }
        public Guid Uid { get; set; }
        public string Name { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Age { get; set; }
        public DateTime DateCreated { get; set; }
        public string UrlPhoto { get; set; } = null!;

        public virtual UserCr UidNavigation { get; set; } = null!;
    }
}
