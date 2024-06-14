class AsyncDemo1
{
    static async Task Main(string[] args)
    {
        Thread.CurrentThread.ManagedThreadId.Dump("1");
        var client = new HttpClient();
        Thread.CurrentThread.ManagedThreadId.Dump("2");
        // 异步方法封装成Task，提交到线程池运行
        var task = client.GetStringAsync("http://baidu.com");
        Thread.CurrentThread.ManagedThreadId.Dump("3");

        var a = 0;
        for (int i = 0; i < 1_000_000; i++)
        {
            a += i;
        }

        Thread.CurrentThread.ManagedThreadId.Dump("4");
        
        var page = await task;
        Thread.CurrentThread.ManagedThreadId.Dump("5");
    }
}