using LinqToDB.Mapping;
using System;

class Order
{
    [PrimaryKey]
    [NotNull]
    public long Id { get; set; }

    public int CustomerId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime OrderDate { get; set; }
}