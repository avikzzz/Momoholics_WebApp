using System;
using System.Collections.Generic;

namespace MomoHolix.DataAccessLayer.Models
{
    public partial class Sales
    {
        public decimal SalesId { get; set; }
        public decimal? CustId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime? Date { get; set; }
        public decimal? QtyOrdered { get; set; }
    }
}
