using System;

namespace Exercise1.Domain.Common;
public class BaseEntity
{
    public long Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
