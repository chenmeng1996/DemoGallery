namespace Reflect;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Test1()
    {
        Type widgetType = typeof(Widget);

        object[] widgetClassAttributes = widgetType.GetCustomAttributes(typeof(HelpAttribute), false);

        if (widgetClassAttributes.Length > 0)
        {
            HelpAttribute attr = (HelpAttribute)widgetClassAttributes[0];
            Console.WriteLine($"Widget class help URL : {attr.Url} - Related topic : {attr.Topic}");
        }

        // System.Reflection.MethodInfo? displayMethod = widgetType.GetMethod(nameof(Widget.Display));
        System.Reflection.MethodInfo displayMethod = widgetType.GetMethod(nameof(Widget.Display)) ?? throw new ArgumentException();

        object[] displayMethodAttributes = displayMethod.GetCustomAttributes(typeof(HelpAttribute), false);

        if (displayMethodAttributes.Length > 0)
        {
            HelpAttribute attr = (HelpAttribute)displayMethodAttributes[0];
            Console.WriteLine($"Display method help URL : {attr.Url} - Related topic : {attr.Topic}");
        }
    }
}