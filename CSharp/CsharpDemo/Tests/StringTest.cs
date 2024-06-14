namespace String;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Test1()
    {
        string.IsNullOrEmpty("");
    }

    [TestMethod]
    public void Test2()
    {
        var a = string.Concat("world", "hello", "a", "b", "c", "d", "e");
        Console.WriteLine(a);
    }
}