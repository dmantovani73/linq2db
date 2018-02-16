using LinqToDB.Mapping;
using System;

class Order
{
    [PrimaryKey]
    [NotNull]
    public long Id { get; set; }

    public string CustomerId { get; set; }

    public long EmployeeId { get; set; }

    public DateTime OrderDate { get; set; }
}