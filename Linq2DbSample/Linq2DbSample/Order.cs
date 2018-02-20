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

    public DateTime? RequiredDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public long ShipVia { get; set; }

    public decimal Freight { get; set; }

    public string ShipName { get; set; }

    public string ShipAddress { get; set; }

    public string ShipCity { get; set; }

    public string ShipRegion { get; set; }

    public string ShipPostalCode { get; set; }

    public string ShipCountry { get; set; }

    [Association(ThisKey = nameof(CustomerId), OtherKey = nameof(global::Customer.Id), CanBeNull = false)]
    public Customer Customer { get; set; }

    [Association(ThisKey = nameof(EmployeeId), OtherKey = nameof(global::Employee.Id), CanBeNull = false)]
    public Employee Employee { get; set; }
}