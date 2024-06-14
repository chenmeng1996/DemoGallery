public static class Extension
{
    public static void Dump(this int i, string s)
    {
        Console.WriteLine(i.ToString() + "\t" + s);
    }
}