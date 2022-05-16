using Exercise1.Domain.Common;

namespace Exercise1.Domain.Entities.MasterData;
public class Employee : BaseEntity
{
    public string Firstname { get; set; }
    public string Middlename { get; set; }
    public string Lastname { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Fullname => $"{Firstname} {Middlename} {Lastname}";
}
