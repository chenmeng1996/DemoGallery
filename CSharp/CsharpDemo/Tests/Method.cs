namespace Method;

class MethodParamExample
{
    // 通过ref关键字，可以传递值类型的引用
    public static void Swap(ref int x, ref int y)
    {
        int temp = x;
        x = y;
        y = temp;
    }

    // in关键字：只读的引用
    public static void InTest(in BigStruct x)
    {
        Console.WriteLine(x);
    }

    // 通过out关键字，传递引用（可以是值类型和引用类型）。将方法的返回结果直接写入到引用。
    public static void Divide(int x, int y, out int result, out int remainder)
    {
        result = x / y;
        remainder = x % y;
    }

    // 通过params关键字，传递数量可变的参数。
    public static void Write(string name, params object[] hobbies)
    {
        Console.WriteLine(name);
        Console.WriteLine(hobbies);
    }
}

struct BigStruct
{
    public int a;
    public string b;
}