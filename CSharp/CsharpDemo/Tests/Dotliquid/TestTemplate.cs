namespace dotliquid;

using DotLiquid;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Test1()
    {
        Template template = Template.Parse("hi {{name}}");
        var result = template.Render(Hash.FromAnonymousObject(new { name = "tobi" }));
        Console.WriteLine(result);
    }
}