using LinqToDB.Mapping;

class Employee
{
    [PrimaryKey]
    [NotNull]
    public long Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Title { get; set; }

    public string City { get; set; }

    public string Country { get; set; }
}