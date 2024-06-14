namespace Class;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestParentClass()
    {
        Point a = new(10, 20);
        Point b = new Point3D(10, 20, 30);
    }
}