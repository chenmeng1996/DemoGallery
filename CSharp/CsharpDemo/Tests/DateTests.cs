namespace DateTests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Test1()
    {
        DateTime date = DateTime.Now;
        Console.WriteLine("{0}", date);
        
        int endOfDay = DateTime.DaysInMonth(date.Year, date.Month);
        DateTime endOfDate = new DateTime(date.Year, date.Month, endOfDay);
    }

    [TestMethod]
    public void Test2()
    {
        var dateOffset = DateTimeOffset.Parse("2022-05-15T00:00:00Z");
        Console.WriteLine(dateOffset);
        Console.WriteLine(dateOffset.Day);
        Console.WriteLine(DateTime.DaysInMonth(dateOffset.Year, dateOffset.Month));
    }

    [TestMethod]
    public void Test3()
    {
        var dateTime = DateTimeOffset.Parse("2022-03-27T00:00:00Z").UtcDateTime;
        var date = new DateTimeOffset(dateTime).AddMonths(-1);
        Console.WriteLine(date);
    }

}