using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Profile : Auditable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdProfile { get; set; }

    [Required]
    [MaxLength(50)]
    public string ProfileName { get; set; }

    public ICollection<User> Users { get; }
}