using LinqToDB.Mapping;

class OrderDetail
{
    [PrimaryKey]
    [NotNull]
    public string Id { get; set; }

    [NotNull]
    public long OrderId { get; set; }

    [NotNull]
    public long ProductId { get; set; }

    [NotNull]
    public decimal UnitPrice { get; set; }

    [NotNull]
    public long Quantity { get; set; }

    [NotNull]
    public double Discount { get; set; }

    [Association(ThisKey = nameof(OrderId), OtherKey = nameof(global::Order.Id), CanBeNull = false)]
    public Order Order { get; set; }

    [Association(ThisKey = nameof(ProductId), OtherKey = nameof(global::Product.Id), CanBeNull = false)]
    public Product Product { get; set; }
}