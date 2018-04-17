using LinqToDB.Data;

public interface IDataContextFactory<T>
    where T : DataConnection
{
    T Create();
}

