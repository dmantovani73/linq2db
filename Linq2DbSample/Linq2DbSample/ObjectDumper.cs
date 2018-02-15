using Newtonsoft.Json;
using System;

static class ObjectDumper
{
    public static void Dump<T>(this T obj, Formatting formatting = Formatting.Indented)
    {
        Console.WriteLine(JsonConvert.SerializeObject(obj, formatting));
    }
}