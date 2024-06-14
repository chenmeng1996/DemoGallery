namespace ExtendMethod;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Test1()
    {
        string s = "Hello Extension Methods";
        Console.WriteLine(s.WordCount());
    }
}