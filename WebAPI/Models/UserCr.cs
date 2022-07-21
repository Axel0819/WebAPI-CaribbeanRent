using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public partial class UserCr
    {
        public UserCr()
        {
            Contacts = new HashSet<Contact>();
            Favorites = new HashSet<Favorite>();
            InfoUsers = new HashSet<InfoUser>();
            RentPosts = new HashSet<RentPost>();
            RoomiePosts = new HashSet<RoomiePost>();
        }

        public int Uid { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Role { get; set; }
        public int State { get; set; }


        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<InfoUser> InfoUsers { get; set; }
        public virtual ICollection<RentPost> RentPosts { get; set; }
        public virtual ICollection<RoomiePost> RoomiePosts { get; set; }
    }
}
