namespace Async;

public class AsyncDemo
{
    // async声明是异步方法。
    // await通知编译器异步等待结果完成
    public static async Task<int> RetrieveDocsHomePage()
    {
        var client = new HttpClient();
        byte[] content = await client.GetByteArrayAsync("https://docs.microsoft.com/");

        Console.WriteLine($"{nameof(RetrieveDocsHomePage)}: Finished downloading.");
        return content.Length;
    }


    public static void Method1()
    {
        Task.Delay(3000).Wait();
        Console.WriteLine(" Method 1");
    }

    public static void Method2()
    {
        Task.Delay(3000).Wait();
        Console.WriteLine(" Method 2");
    }

    public static async Task AsyncMethod1()
    {
        await Task.Delay(3000);
        Console.WriteLine(" Method 1");
    }


    public static async Task<int> AsyncMethod2()
    {
        await Task.Delay(3000);
        Console.WriteLine(" Method 2");
        return 2;
    }

    public static async Task<int> AsyncMethod2_1(int a)
    {
        await Task.Delay(3000);
        Console.WriteLine(" Method 2-1");
        return a + 1;
    }

    public static int AsyncMethod2_2(int a)
    {
        Task.Delay(3000).Wait();
        Console.WriteLine(" Method 2-2");
        return a + 2;
    }

    // 当前线程遇到耗时的cpu计算时，可以启动一个新线程计算，并异步等待结果。
    public static async Task AsyncCPUIntensiveMethod()
    {
        // 虽然有新线程运行，但是这里有await，所以这段代码还是阻塞的。
        // 如果当前线程await该异步方法，会导致当前线程阻塞。
        var res = await Task.Run(() =>
                {
                    var total = 0;
                    // cpu耗时的计算
                    for (int i = 0; i < 10000; i++)
                    {
                        total++;
                    }
                    return total;
                });
        Console.WriteLine(res);
    }
}