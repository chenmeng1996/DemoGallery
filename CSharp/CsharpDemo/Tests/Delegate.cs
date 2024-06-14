namespace Delegate;

// 委托类型表示对具有特定参数列表和返回类型的方法的引用。
// 通过委托，可以将方法视为可分配的变量，并且可以作为参数。
// 委托类似于其他语言的函数指针。
delegate double Function(double x);

class DelegateDeclareExample
{
    // 对任何具有 void 返回类型的委托类型使用 Action 类型。
    public Action<int, string>? d1;
    // 结果的类型始终是所有 Func 声明中的最后一个类型参数。
    public Func<string, int>? d2;
    // 结果是bool。
    public Predicate<string>? d3;
}

class Multiplier
{
    double _factor;

    public Multiplier(double factor) => _factor = factor;

    public double Multiply(double x) => x * _factor;
}

class UseDelegateExample
{
    public static double[] Apply(double[] a, Function f)
    {
        var result = new double[a.Length];
        for (int i = 0; i < a.Length; i++) result[i] = f(a[i]);
        return result;
    }
}

class Logger
{
    // 委托类型的对象
    public static Action<string>? WriteMessage;
    public static Severity LogLevel{get; set;} = Severity.Warning; // 默认日志等级是warning。

    public static void LogMessage(Severity s, string component, string msg)
    {
        if (s < LogLevel)
        {
            return;
        }
        var outputMsg = $"{DateTime.Now}\t{s}\t{component}\t{msg}";
        WriteMessage?.Invoke(outputMsg);
    }
    
}

public enum Severity
{
    Verbose,
    Trace,
    Information,
    Warning,
    Error,
    Critical
}

public static class LoggingMethods
{
    public static void LogToConsole(string message)
    {
        Console.Error.WriteLine(message);
    }
}

public class FileLogger
{
    private readonly string logPath;

    public FileLogger(string path)
    {
        logPath = path;
        Logger.WriteMessage += LogMessage;
    }

    public void DetachLog() => Logger.WriteMessage -= LogMessage;

    private void LogMessage(string msg)
    {
        try
        {
            using (var log = File.AppendText(logPath))
            {
                log.WriteLine(msg);
                log.Flush();
            }
        }
        catch (Exception)
        {

        }
    }
}