using LinqToDB.Mapping;

public class Category
{
    [PrimaryKey]
    [NotNull]
    public long Id { get; set; }

    public string CategoryName { get; set; }

    public string Description { get; set; }
}