namespace LINQ;

using System.Collections.Generic;
using System.Linq;

[TestClass]
public class UnitTest1
{

    [TestMethod]
    public void Test1()
    {
        var startingDeck = (from s in Suits().LogQuery("Suit Generation")
                           from r in Ranks().LogQuery("Rank Generation")
                           select new { Suit = s, Rank = r }).LogQuery("Starting Deck")
                           .ToArray();

        // Display each card that we've generated and placed in startingDeck in the console
        foreach (var card in startingDeck)
        {
            Console.WriteLine(card);
        }
        
        var shuffle = startingDeck;
        var count = 0;
        do
        {
            shuffle = shuffle.Take(26).LogQuery("Top Half")
                .InterleaveSequenceWith(shuffle.Skip(26).LogQuery("Bottom Half"))
                .LogQuery("Shuffle")
                .ToArray();

            count++;

            foreach (var v in shuffle)
            {
                Console.WriteLine(v);
            }
        } while (!shuffle.SequenceEquals(startingDeck));

        Console.WriteLine(count);
        
    }

    [TestMethod]
    public void Test2()
    {
        var startingDeck = Suits().SelectMany(suit => Ranks().Select(rank => new { Suit = suit, Rank = rank }));
        foreach (var card in startingDeck)
        {
            Console.WriteLine(card);
        }
    }

    // 筛选器
    [TestMethod]
    public void Test3()
    {
        var numbers = new int[]{1, 3, 5, 7, 9};
        var smallNumbers = numbers.Where(n => n < 5);
        foreach (var item in smallNumbers)
        {
            Console.WriteLine(item);
        }
    }

    static IEnumerable<string> Suits()
    {
        yield return "clubs";
        yield return "diamonds";
        yield return "hearts";
        yield return "spades";
    }

    static IEnumerable<string> Ranks()
    {
        yield return "two";
        yield return "three";
        yield return "four";
        yield return "five";
        yield return "six";
        yield return "seven";
        yield return "eight";
        yield return "nine";
        yield return "ten";
        yield return "jack";
        yield return "queen";
        yield return "king";
        yield return "ace";
    }
}

public static class Extensions
{
    public static IEnumerable<T> InterleaveSequenceWith<T>(this IEnumerable<T> first, IEnumerable<T> second)
    {
        var firstIter = first.GetEnumerator();
        var secondIter = second.GetEnumerator();

        while (firstIter.MoveNext() && secondIter.MoveNext())
        {
            yield return firstIter.Current;
            yield return secondIter.Current;
        }
    }

    public static bool SequenceEquals<T>(this IEnumerable<T> first, IEnumerable<T> second)
    {
        var firstIter = first.GetEnumerator();
        var secondIter = second.GetEnumerator();

        while (firstIter.MoveNext() && secondIter.MoveNext())
        {
            if (!firstIter.Current.Equals(secondIter.Current))
            {
                return false;
            }
        }

        return true;
    }


    public static IEnumerable<T> LogQuery<T>
        (this IEnumerable<T> sequence, string tag)
    {
        // File.AppendText creates a new file if the file doesn't exist.
        using (var writer = File.AppendText("debug.log"))
        {
            writer.WriteLine($"Executing Query {tag}");
        }

        return sequence;
    }
}

