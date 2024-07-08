using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain;

public class User : Auditable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdUser { get; set; }

    [Required]
    public int IdProfile { get; set; }

    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }

    [Required]
    [MaxLength(100)]
    public string Email { get; set; }

    [Required]
    [MaxLength(50)]
    public string UserName { get; set; }

    [Required]
    [MaxLength(200)]
    public string HashPassword { get; set; }

    [Required]
    [ForeignKey(nameof(IdProfile))]
    public Profile Profile { get; set; }

    public ICollection<PurchaseOrderStatusLog> PurchaseOrderStatusLogs { get; }
}