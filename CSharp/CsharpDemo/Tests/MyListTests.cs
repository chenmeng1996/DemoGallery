namespace MyList;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestEventChange()
    {
        int s_changeCount = 0;
        // 事件触发的回调函数
        void ListChanged(object sender, EventArgs s)
        {
            s_changeCount++;
        }

        var names = new MyList<string>();
        // 订阅事件，需要传递一个委托。
        names.Changed += new EventHandler(ListChanged);
        names.Add("Liz");
        names.Add("Martha");
        names.Add("Beth");
        Console.WriteLine(s_changeCount); // "3"   
    }
}