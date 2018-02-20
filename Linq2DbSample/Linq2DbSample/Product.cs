using LinqToDB.Mapping;

class Product
{
    [PrimaryKey]
    [NotNull]
    public long Id { get; set; }

    public string ProductName { get; set; }

    [NotNull]
    public long SupplierId { get; set; }

    [NotNull]
    public long CategoryId { get; set; }

    public string QuantityPerUnit { get; set; }

    [NotNull]
    public decimal UnitPrice { get; set; }

    [NotNull]
    public long UnitsInStock { get; set; }

    [NotNull]
    public long UnitsOnOrder { get; set; }

    [NotNull]
    public long ReorderLevel { get; set; }

    [NotNull]
    public long Discontinued { get; set; }

    [Association(ThisKey = nameof(SupplierId), OtherKey = nameof(global::Supplier.Id), CanBeNull = false)]
    public Supplier Supplier { get; set; }

    [Association(ThisKey = nameof(CategoryId), OtherKey = nameof(global::Category.Id), CanBeNull = false)]
    public Category Category { get; set; }
}