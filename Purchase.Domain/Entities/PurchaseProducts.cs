using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Purchase.Domain.Entities
{
    [Table("PurchaseProducts")]
    public class PurchaseProducts : BaseEntity
    {
        public virtual Purchases Purchases { get; set; } = new Purchases();

        [ForeignKey(nameof(Purchases)), Required(ErrorMessage = "Purchase Id is required")]
        public Guid PurchaseId { get; set; }

        [Required(ErrorMessage = "Product Id is required")]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "Product Quantity is required")]
        public long ProductQuantity { get; set; }

        //public long ProductPrice { get; set; }

        public double? ProductTotal { get; set; }

        public Guid? DiscountId { get; set; }

        public double? DiscountedTotal { get; set; }

        public Guid? TaxId { get; set; }

        public double? TaxedTotal { get; set; }
    }
}
