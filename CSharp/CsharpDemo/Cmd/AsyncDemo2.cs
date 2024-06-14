class AsyncDemo2
{
    static async Task Main(string[] args)
    {
        // 主线程
        Thread.CurrentThread.ManagedThreadId.Dump("1");
        // 主线程不阻塞的执行异步方法（将异步方法提交给线程池的其他某个线程执行）
        var task = DoSomethingAsync();
        // 主线程
        Thread.CurrentThread.ManagedThreadId.Dump("5");

        var a = 0;
        for (int i = 0; i < 1_000_000; i++)
        {
            a += i;
        }
        // 主线程
        Thread.CurrentThread.ManagedThreadId.Dump("6");
        
        // 阻塞的等待异步任务执行完成，所以交出主线程的控制权
        var page = await task;
        // 线程2。执行完异步方法后，通过回调机制，继续执行await之后的代码
        Thread.CurrentThread.ManagedThreadId.Dump("7");
    }

    static async Task<string> DoSomethingAsync()
    {
        // 主线程
        Thread.CurrentThread.ManagedThreadId.Dump("2");

        // 通过状态机，主线程从调用该异步方法的代码位置继续执行
        await Task.Run(() => {
            // 线程2
            Thread.CurrentThread.ManagedThreadId.Dump("3");
            Thread.Sleep(1000);
            return "hello";
        });
        // 线程2
        Thread.CurrentThread.ManagedThreadId.Dump("4");
        return "done";
    }
}