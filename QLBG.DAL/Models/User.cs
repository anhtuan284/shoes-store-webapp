using System;
using System.Collections.Generic;

#nullable disable

namespace QLBG.DAL.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
