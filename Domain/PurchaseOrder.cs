using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain;

public class PurchaseOrder : Auditable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdPurchaseOrder { get; set; }

    [Required]
    [MaxLength(100)]
    public string OrderNumber { get; set; }

    [Required]
    public DateTime OrderDate { get; set; }

    [Required]
    public DateTime ReqShipDate { get; set; }

    [Required]
    [MaxLength(100)]
    public string CustomerPO { get; set; }

    [MaxLength(100)]
    public string CustomerName { get; set; }

    [MaxLength(500)]
    public string Comments { get; set; }

    public ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; }
    public ICollection<TrackingStatusLog> TrackingStatusLog { get; }
    public ICollection<PurchaseOrderStatusLog> PurchaseOrderStatusLogs { get; }
}