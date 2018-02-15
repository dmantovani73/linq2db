using LinqToDB.Mapping;

class OrderDetail
{
    [PrimaryKey]
    [NotNull]
    public string Id { get; set; }

    [NotNull]
    public long OrderId { get; set; }
}