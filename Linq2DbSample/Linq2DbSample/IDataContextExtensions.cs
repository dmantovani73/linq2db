using LinqToDB;

static class IDataContextExtensions
{
    public static void CreateTableIfNotExists<T>(this IDataContext db)
    {
        try
        {
            db.CreateTable<T>();
        }
        catch
        { }
    }

    public static void DeleteAll<T>(this IDataContext db)
        where T : class
    {
        db.GetTable<T>().Delete();
    }
}