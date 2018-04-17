using LinqToDB.Data;

interface IDataContextFactory<T>
    where T : DataConnection
{
    T Create();
}

