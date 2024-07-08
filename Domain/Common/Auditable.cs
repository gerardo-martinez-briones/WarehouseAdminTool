using System.ComponentModel.DataAnnotations;

namespace Domain.Common;

public abstract class Auditable
{
    public bool IsActive { get; set; } = true;

    [Required]
    public int CreatedBy { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public Nullable<int> EditedBy { get; set; }
    
    public Nullable<DateTime> EditedAt { get; set; }
}