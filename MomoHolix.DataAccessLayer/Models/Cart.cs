using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MomoHolix.DataAccessLayer.Models
{
    public partial class Cart
    {
        public decimal CartId { get; set; }
        public decimal? CustId { get; set; }
        public string MenuId { get; set; }
        public decimal ItemQty { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal TotalPrice { get; set; }

        [JsonIgnore]
        public virtual Customer Cust { get; set; }
        [JsonIgnore]
        public virtual Menu Menu { get; set; }
    }
}
