using BillManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BillManagement.Models
{
    public partial class Dctable
    {
        [Key]
        public int DcPk { get; set; }
        public string DcNo { get; set; } = null!;
        public DateTime? Date { get; set; }
        public bool? InvoiceCheck { get; set; }
        public string? EwayBillNo { get; set; }

        public virtual ICollection<Dcproduct> Dcproducts { get; set; }
    }
}
