namespace PatternMatch;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    // 声明模式，测试变量类型并将其分配给新变量
    public void Test1()
    {
        int? maybe = 12;
        if (maybe is int number)
        {
            Console.WriteLine($"The nullable int 'maybe' has the value {number}");
        }
        else
        {
            Console.WriteLine("The nullable int 'maybe' doesn't hold a value");
        }
    }

    [TestMethod]
    // 测试null
    public void Test2()
    {
        string? message = "This is not the null string";
        if (message is not null)
        {
            Console.WriteLine(message);
        }
    }

    [TestMethod]
    // 类型测试
    public void Test3()
    {
        T MidPoint<T>(IEnumerable<T> sequence)
        {
            if (sequence is IList<T> list)
            {
                return list[list.Count / 2];
            }
            else if (sequence is null)
            {
                throw new ArgumentNullException(nameof(sequence), "Sequence can't be null.");
            }
            else
            {
                int halfLength = sequence.Count() / 2 - 1;
                if (halfLength < 0) halfLength = 0;
                return sequence.Skip(halfLength).First();
            }
        }
    }

    [TestMethod]
    public void Test4()
    {
        int Perform(string command) =>
            command switch
            {
                "a" => 1,
                "b" => 2,
                _ => 3,
            };
    }
    
    [TestMethod]
    // 关系模式
    public void Test5()
    {
        string WaterState(int tempInFahrenheit) =>
            tempInFahrenheit switch
            {
                (> 32) and (< 212) => "liquid",
                < 32 => "solid",
                > 212 => "gas",
                32 => "solid/liquid transition",
                212 => "liquid / gas transition",
            };
    }

    [TestMethod]
    public void Test6()
    {
        decimal CalculateDiscount(Order order) =>
            order switch
            {
                (Items: > 10, Cost: > 1000.00m) => 0.10m,
                (Items: > 5, Cost: > 500.00m) => 0.05m,
                Order { Cost: > 250.00m } => 0.02m,
                null => throw new ArgumentNullException(nameof(order), "Can't calculate discount on null order"),
                var someObject => 0m, // 与任何值匹配
            };
    }

    [TestMethod]
    // 列表模式
    public void Test7()
    {
        // void MatchElements(int[] array)
        // {
        //     if (array is [0,1])
        //     {
        //         Console.WriteLine("Binary Digits");
        //     }
        //     else if (array is [1,1,2,3,5,8, ..])
        //     {
        //         Console.WriteLine("array looks like a Fibonacci sequence");
        //     }
        //     else
        //     {
        //         Console.WriteLine("Array shape not recognized");
        //     }
        // }
    }
}

record Order(int Items, decimal Cost);