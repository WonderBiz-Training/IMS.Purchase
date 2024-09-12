using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Purchase.Domain.Entities
{
    [Table(nameof(Purchases))]
    [Index(nameof(PurchaseCode), IsUnique = true)]
    public class Purchases : BaseEntity
    {
        [Required(ErrorMessage = "Purchase Code is required")]
        public string PurchaseCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "VendorId is required")]
        public Guid VendorId { get; set; }

        //public long ProductId { get; set; }

        [Required(ErrorMessage = "Purchase Quantity is required")]
        public long PurchaseQuantity { get; set; }

        //public long ProductPrice { get; set; }

        public double? PurchaseTotal { get; set; }

        public Guid? DiscountId { get; set; }

        public double? DiscountedTotal { get; set; }

        public Guid? TaxId { get; set; }

        public double? TaxedTotal { get; set; }

        [Required(ErrorMessage = "Status Id is required")]
        public Guid StatusId { get; set; }

        [Required(ErrorMessage = "Location Id is required")]
        public Guid LocationId { get; set; }

        [Required(ErrorMessage = "Purchase Date and Time is required")]
        public DateTime PurchaseDate { get; set; } = DateTime.Now;

        public virtual List<PurchaseProducts> PurchaseProduct { get; set; } = new List<PurchaseProducts>();
    }
}
