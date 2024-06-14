namespace Sugar;

public class Product
{
    public string Color {get; set;}

    public float Price {get; set;}
}

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Test1()
    {
        var limit = 3;
        int[] source = {0, 1, 2};
        var query = from item in source
                    where item <= limit
                    select item;
    }

    [TestMethod]
    // 匿名类
    public void Test2()
    {
        // 直接指定字段的匿名类
        var v = new {Amount = 108, Message = "Hello"};
        Console.WriteLine(v.Amount + v.Message);

        // 使用已有类的字段，生成的匿名类
        var products = new Product[2];
        var productQuery = 
            from prod in products
            select new {prod.Color, prod.Price};
        foreach (var p in productQuery)
        {
            Console.WriteLine("Color={0}, Price={1}", p.Color, p.Price);
        }

        // 匿名类数组
        var anonArray = new[] { new { name = "apple", diam = 4 }, new { name = "grape", diam = 1 }};
    }
}

