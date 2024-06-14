namespace Method;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestRefParam()
    {
        int i = 1, j = 2;
        MethodParamExample.Swap(ref i, ref j);
        Console.WriteLine($"{i} {j}");
    }

    [TestMethod]
    public void TestOutParam()
    {
        MethodParamExample.Divide(3, 2, out int res, out int rem);
        Console.WriteLine($"{res} {rem}");
    }

    [TestMethod]
    public void TestArrayParam()
    {
        MethodParamExample.Write("cm", "play games", "read books");
    }
}