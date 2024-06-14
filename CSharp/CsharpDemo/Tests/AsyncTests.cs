using System.Diagnostics;

namespace Async;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public async Task Test1()
    {
        var length = await AsyncDemo.RetrieveDocsHomePage();
        Console.WriteLine(length);
    }

    [TestMethod]
    public void test2()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        AsyncDemo.Method1();
        AsyncDemo.Method2();

        sw.Stop();
        Console.WriteLine("take time {0}", sw.Elapsed.TotalSeconds);
    }

    [TestMethod]
    public async Task test3()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        await AsyncDemo.AsyncMethod1();
        await AsyncDemo.AsyncMethod2();

        sw.Stop();
        Console.WriteLine("take time {0}", sw.Elapsed.TotalSeconds);
    }

    [TestMethod]
    public async Task test4()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        var task1 = AsyncDemo.AsyncMethod1();
        var task2 = AsyncDemo.AsyncMethod2();
        await task1;
        var a = await task2;
        a = await AsyncDemo.AsyncMethod2_1(a);
        a = AsyncDemo.AsyncMethod2_2(a);
        Console.WriteLine("a={0}", a);
        
        sw.Stop();
        Console.WriteLine("take time {0}", sw.Elapsed.TotalSeconds);
    }

    [TestMethod]
    public async Task test5()
    {
        // 启动新线程执行cpu密集的操作，然后不等待结果。这样可以不阻塞当前线程，继续其他操作。
        _ = AsyncDemo.AsyncCPUIntensiveMethod();
        // 继续其他的操作
        Console.WriteLine("go on...");
    }
}