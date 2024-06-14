namespace Enumerator;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Test1()
    {
        var iter = EnumerableDemo.GetSingleDigitNumbers();
        foreach (var a in iter)
        {
            Console.WriteLine(a);
        }
    }

    // 编译器会将foreach转换为Enumerator的使用方式
    // 同步的Enumerator
    public void Test1_1()
    {
        var enumerable = EnumerableDemo.GetSingleDigitNumbers();
        var enumerator = enumerable.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                Console.WriteLine(item.ToString());
            }
        }
        finally
        {
            // dispose of enumerator
        }
    }

    // 异步的Enumerable
    [TestMethod]
    public async Task Test2()
    {
        var iter = EnumerableDemo.GetSingleDigitNumbersAsync();
        await foreach (var a in iter)
        {
            Console.WriteLine(a);
        }
    }

    // 异步的Enumerator
    [TestMethod]
    public async Task Test2_2()
    {
        var enumerable = EnumerableDemo.GetSingleDigitNumbersAsync();
        var enumerator = enumerable.GetAsyncEnumerator();
        try
        {
            while (await enumerator.MoveNextAsync())
            {
                var item = enumerator.Current;
                Console.WriteLine(item.ToString());
            }
        }
        finally
        {
            // dispose of async enumerator.
        }
    }
}