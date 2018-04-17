using LinqToDB.Data;
using Newtonsoft.Json;
using System;
using System.IO;

public static class ObjectDumper
{
    static readonly TextWriter DefaultTextWriter = Console.Out;

    public static void Dump<T>(this T obj, Formatting formatting = Formatting.Indented, TextWriter writer = null)
    {
        writer = writer ?? DefaultTextWriter;

        writer.WriteLine(JsonConvert.SerializeObject(obj, formatting));
    }

    public static void DumpQuery<T>(this DataConnection db, T query, Formatting formatting = Formatting.Indented, TextWriter writer = null, bool dumpLastQuery = true)
    {
        writer = writer ?? DefaultTextWriter;

        query.Dump(formatting, writer);

        if (dumpLastQuery)
        {
            writer.WriteLine();
            writer.WriteLine(db.LastQuery);
        }
    }
}