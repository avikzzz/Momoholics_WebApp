using System;
using System.Collections.Generic;

namespace MomoHolix.DataAccessLayer.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Cart = new HashSet<Cart>();
        }

        public decimal CustId { get; set; }
        public string CustName { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string CustAddress { get; set; }
        public decimal PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public decimal? Balance { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
    }
}
