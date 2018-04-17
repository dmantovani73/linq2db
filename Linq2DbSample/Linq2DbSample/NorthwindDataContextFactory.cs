using LinqToDB.DataProvider;

public class NorthwindDataContextFactory : IDataContextFactory<NorthwindDataContext>
{
    readonly IDataProvider dataProvider;

    readonly string connectionString;

    public NorthwindDataContextFactory(IDataProvider dataProvider, string connectionString)
    {
        this.dataProvider = dataProvider;
        this.connectionString = connectionString;
    }

    public NorthwindDataContext Create() => new NorthwindDataContext(dataProvider, connectionString);
}
