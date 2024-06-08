using BillManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillManagement.Models
{
    public partial class Dcproduct
    {
        [Key]
        public int DcProductPk { get; set; }
        public string? DcNo { get; set; }
        public int DcFk { get; set; }

        public int ProductFk { get; set; }
        public string? ProductDescription { get; set; }
        public decimal Amount { get; set; }
        public DateTime? Date { get; set; }
        public string? EwayBillNo { get; set; }

        [ForeignKey("DcFk")]
        public virtual Dctable DcFkNavigation { get; set; }
        [ForeignKey("ProductFk")]
        public virtual Product Product { get; set; } = null!;
    }
}
