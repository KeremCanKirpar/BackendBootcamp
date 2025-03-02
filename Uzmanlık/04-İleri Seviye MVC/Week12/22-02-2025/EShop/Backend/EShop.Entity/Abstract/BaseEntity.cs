using System;

namespace EShop.Entity.Abstract;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; }
}
