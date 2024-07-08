using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain;

public class Status : Auditable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdStatus { get; set; }

    [Required]
    [MaxLength(100)]
    public string StatusName { get; set; }

    [Required]
    [MaxLength(500)]
    public string Description { get; set; } = null;

    public ICollection<PurchaseOrderStatusLog> PurchaseOrderStatusLogs { get; }
}