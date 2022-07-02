using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Image
    {
        public Guid Idimage { get; set; }
        public int IdrentPost { get; set; }
        public string Urlimage { get; set; } = null!;

        public virtual RentPost IdrentPostNavigation { get; set; } = null!;
    }
}
