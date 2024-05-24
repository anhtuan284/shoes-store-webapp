using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace QLBG.DAL.Models
{
    public partial class User
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
