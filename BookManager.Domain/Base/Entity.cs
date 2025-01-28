using System.ComponentModel.DataAnnotations;
using BookManager.Domain.Interfaces.Entities;

namespace BookManager.Domain.Base;

public abstract class Entity : IEntity
{
    [Required]
    public long Id { get; set; }
    
    [Required]
    public Guid Identifier { get; set; }

    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}