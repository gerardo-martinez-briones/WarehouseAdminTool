using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain;

public class PurchaseOrderDetail : Auditable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdPurchaseOrderDetail { get; set; }

    [Required]
    public int IdPurchaseOrder { get; set; }

    [MaxLength(100)]
    public string SKU { get; set; } = null;

    [MaxLength(100)]
    public string ItemNumber { get; set; } = null;

    [MaxLength(500)]
    public string ItemDescription { get; set; } = null;

    [MaxLength(50)]
    public string Unit { get; set; } = null;

    [Required]
    public int Ordered { get; set; }

    [Required]
    [ForeignKey(nameof(IdPurchaseOrder))]
    public PurchaseOrder PurchaseOrder { get; set; }
}