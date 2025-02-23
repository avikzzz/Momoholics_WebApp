using System;
using System.Collections.Generic;

namespace MomoHolix.DataAccessLayer.Models
{
    public partial class Category
    {
        public Category()
        {
            Menu = new HashSet<Menu>();
        }

        public string CatId { get; set; }
        public string CatName { get; set; }

        public virtual ICollection<Menu> Menu { get; set; }
    }
}
