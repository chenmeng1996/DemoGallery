class AsyncDemo
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("begin");
        await Task.Run(() =>
                       {
                           Console.WriteLine("inside");
                           Thread.Sleep(5000);
                       });
        Console.WriteLine("end");
        while (true)
        {
            Thread.Sleep(1000);
            Console.WriteLine("Wait 1 second");
        }
    }
}