namespace Enum;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestEnum()
    {
        var turnip = SomeRootVegetable.Turnip;

        var spring = Seasons.Spring;
        var startingOnEquinox = Seasons.Spring | Seasons.Autumn;
        var theYear = Seasons.All;
    }
}