namespace Enumerator;

public class EnumerableDemo
{

    // 迭代器
    public static IEnumerable<int> GetSingleDigitNumbers()
    {
        int index = 0;
        while (index < 10)
            yield return index++;

        yield return 50;

        index = 100;
        while (index < 110)
            yield return index++;
    }


    // 异步迭代器
    public static async IAsyncEnumerable<int> GetSingleDigitNumbersAsync()
    {
        int index = 0;
        while (index < 10)
            yield return index++;
        
        await Task.Delay(500);

        yield return 50;

        index = 100;
        while (index < 110)
            yield return index++;
    }
}