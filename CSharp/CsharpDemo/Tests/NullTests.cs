namespace Null;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestNull()
    {
        // 可为null的int，默认值是null
        int? optionalInt = default; 
        Console.WriteLine(optionalInt); // 无输出
        optionalInt = 5;
        Console.WriteLine(optionalInt);

        // 不能为null的int，默认值是0
        int i = default;
        Console.WriteLine(i); // 0

        // 可为null的string，默认值是null
        string? optionalText = default;
        Console.WriteLine(optionalText); // 无输出
        optionalText = "Hello World.";
        Console.WriteLine(optionalText);

        // 不可为null的string，需要初始化
        string text = "";
        Console.WriteLine(text); // 无输出
        text = "Hello World.";
        Console.WriteLine(text);
    }
}