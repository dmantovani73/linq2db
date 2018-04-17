using LinqToDB.Mapping;

public class Person
{
    [PrimaryKey]
    [NotNull]
    [Identity]
    public int Id { get; set; }

    [NotNull]
    public string FirstName { get; set; }

    [NotNull]
    public string LastName { get; set; }

    public int? Age { get; set; }
}