using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain;

public class TrackingStatusLog : Auditable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdTrackingStatusLog { get; set; }

    [Required]
    public int IdPurchaseOrder { get; set; }

    [Required]
    [MaxLength(50)]
    public string HostName { get; set; }

    [Required]
    public int PalletNumber { get; set; } = 1;

    [Required]
    public int BedNumber { get; set; } = 1;
    
    [Required]
    public bool IsCompleted { get; set; } = false;

    [Required]
    [ForeignKey(nameof(IdPurchaseOrder))]
    public PurchaseOrder PurchaseOrder { get; set; }
}