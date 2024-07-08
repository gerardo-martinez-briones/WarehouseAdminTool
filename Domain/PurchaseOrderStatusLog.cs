using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Domain;

public class PurchaseOrderStatusLog
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdPurchaseOrderStatusLog { get; set; }

    [Required]
    public int IdPurchaseOrder { get; set; }

    [Required]
    public int IdStatus { get; set; }

    [Required]
    public int IdUser { get; set; }

    [MaxLength(500)]
    [AllowNull]
    public string Comments { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Required]
    [ForeignKey(nameof(IdPurchaseOrder))]
    public PurchaseOrder PurchaseOrder { get; set; }

    [Required]
    [ForeignKey(nameof(IdStatus))]
    public Status Status { get; set; }

    [Required]
    [ForeignKey(nameof(IdUser))]
    public User User { get; set; }
}