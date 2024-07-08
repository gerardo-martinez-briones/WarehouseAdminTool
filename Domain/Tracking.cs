using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Tracking
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdTracking { get; set; }

    [Required]
    public int IdPurchaseOrderDetail { get; set; }

    [Required]
    [MaxLength(50)]
    public string HostName { get; set; }

    [Required]
    [MaxLength(50)]
    public string OrderNumber { get; set; }

    [MaxLength(100)]
    public string SKU { get; set; }

    [MaxLength(100)]
    public string ItemNumber { get; set; }

    [Required]
    public byte PalletNumber { get; set; }

    [Required]
    public byte BedNumber { get; set; }

    [Required]
    public int CreatedBy { get; set; }

    [Required]
    public int ReviewedBy { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Required]
    [ForeignKey(nameof(IdPurchaseOrderDetail))]
    public PurchaseOrderDetail PurchaseOrderDetail { get; set; }
}