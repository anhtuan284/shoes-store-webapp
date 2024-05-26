using System;
using System.Collections.Generic;

#nullable disable

namespace QLBG.DAL.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public byte? Gender { get; set; }
        public string Address { get; set; }

        public virtual User IdNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
