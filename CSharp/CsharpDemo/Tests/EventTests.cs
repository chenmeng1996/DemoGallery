namespace Event;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Test1()
    {
        var fileLister = new FileSearcher();
        int filesFound = 0;

        // 定义委托（回调函数）
        EventHandler<FileFoundArgs> onFileFound = (sender, eventArgs) =>
        {
            Console.WriteLine(eventArgs.FoundFile);
            filesFound++;
            // 通过修改eventArgs参数，来与事件发送者通信。
            eventArgs.CancelRequested = true;
        };

        // 发现文件后的回调
        fileLister.FileFound += onFileFound;
        // 每找一个文件夹后的回调
        fileLister.DirectoryChanged += (sender, eventArgs) =>
        {
            Console.Write($"Entering '{eventArgs.CurrentSearchDirectory}'.");
            Console.WriteLine($" {eventArgs.CompletedDirs} of {eventArgs.TotalDirs}");
        };
        fileLister.Search("/Users/admin/src/csharp-demo/CsharpDemo", "*.cs", true);
    }
}