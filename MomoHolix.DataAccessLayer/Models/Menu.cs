using System;
using System.Collections.Generic;

namespace MomoHolix.DataAccessLayer.Models
{
    public partial class Menu
    {
        public Menu()
        {
            Cart = new HashSet<Cart>();
        }

        public string MenuId { get; set; }
        public string CatId { get; set; }
        public string MenuItems { get; set; }
        public string Description { get; set; }
        public decimal ItemPrice { get; set; }
        public string Type { get; set; }
        public string Spiciness { get; set; }
        public decimal? QtyAvailable { get; set; }

        public virtual Category Cat { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
    }
}
