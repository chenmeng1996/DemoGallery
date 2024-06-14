namespace TaskTests;

[TestClass]
public class UnitTest1
{
    // 创建Task的几种方法
    [TestMethod]
    public void TestTaskCreate()
    {
        Task<string> task = new Task<string>(() => {
            Thread.Sleep(100);
            return $"task1的线程ID为{Thread.CurrentThread.ManagedThreadId}";
        });
        task.Start();

        Task<string> task2 = Task<string>.Factory.StartNew(() => {
            Thread.Sleep(100);
            return $"task2的线程ID为{Thread.CurrentThread.ManagedThreadId}";
        });

        Task<string> task3 = Task.Run<string>(() => {
            Thread.Sleep(100);
            return $"task3的线程ID为{Thread.CurrentThread.ManagedThreadId}";
        });

        Console.WriteLine("执行主线程！");
        // 如果task还没运行完，会阻塞
        Console.WriteLine(task.Result);
        Console.WriteLine(task2.Result);
        Console.WriteLine(task3.Result);
        
        Thread.Sleep(2000);
    }

    // 主线程等待所有Task完成
    [TestMethod]
    public void TestTaskWaitAll()
    {
        Task task = new Task(() => {
            Thread.Sleep(100);
            Console.WriteLine("task1 done");
        });
        task.Start();

        Task task2 = new Task(() => {
            Thread.Sleep(1000);
            Console.WriteLine("task2 done");
        });
        task2.Start();

        // 等待所有Task执行完后，再执行主线程
        Task.WaitAll(new Task[]{task, task2});
        Console.WriteLine("执行主线程！");
    }

    // 主线程等待任意一个Task完成
    [TestMethod]
    public void TestTaskWaitAny()
    {
        Task task = new Task(() => {
            Thread.Sleep(100);
            Console.WriteLine("task1 done");
        });
        task.Start();

        Task task2 = new Task(() => {
            Thread.Sleep(1000);
            Console.WriteLine("task2 done");
        });
        task2.Start();

        // 等待任意一个Task执行完后，执行主线程
        Task.WaitAny(new Task[]{task, task2});
        Console.WriteLine("执行主线程！");

        Thread.Sleep(1000);
    }

    // 所有Task完成后，启用新的Task继续执行
    [TestMethod]
    public void TestTaskWhenAny()
    {
        Task task = new Task(() => {
            Thread.Sleep(100);
            Console.WriteLine("task1 done");
        });
        task.Start();

        Task task2 = new Task(() => {
            Thread.Sleep(1000);
            Console.WriteLine("task2 done");
        });
        task2.Start();

        // 启用新的Task，等待任意一个Task执行完后，执行后续逻辑
        Task.WhenAll(new Task[]{task, task2}).ContinueWith((t) => {
            Thread.Sleep(100);
            Console.WriteLine("执行后续操作 done");
        });


        Console.WriteLine("主线程不阻塞，继续执行！");

        Thread.Sleep(2000);
    }

    // 取消Task
    [TestMethod]
    public void TestTaskCancel()
    {
        CancellationTokenSource source = new CancellationTokenSource();
        source.Token.Register(() => {
            Console.WriteLine("取消后的回调操作");
        });

        int index = 0;
        Task task = new Task(() => {
            while (!source.IsCancellationRequested)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"第{++index}次执行，线程运行中...");
            }
            Console.WriteLine("已取消");
        });
        task.Start();
        
        // Thread.Sleep(5000);
        // source.Cancel();
        
        // 创建一个新的Task运行，5s后调用source.Cancel()。
        source.CancelAfter(5000);

        Console.WriteLine("主线程不阻塞，继续运行");
        Thread.Sleep(7000);
    }
}