namespace Tuple;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Test1()
    {
        (double Sum, int Count) t2 = (4.5, 3);
        Console.WriteLine($"Sum of {t2.Count} elements is {t2.Sum}.");
        //Output:
        //Sum of 3 elements is 4.5.
    }

    [TestMethod]
    public void Test2()
    {
        var (_, _, _, pop1, _, pop2) = QueryCityDataForYears("New York City", 1960, 2010);

        Console.WriteLine($"Population change, 1960 to 2010: {pop2 - pop1:N0}");

        (string, double, int, int, int, int) QueryCityDataForYears(string name, int year1, int year2)
        {
            int population1 = 0, population2 = 0;
            double area = 0;

            if (name == "New York City")
            {
                area = 468.48;
                if (year1 == 1960)
                {
                    population1 = 7781984;
                }
                if (year2 == 2010)
                {
                    population2 = 8175133;
                }
                return (name, area, year1, population1, year2, population2);
            }

            return ("", 0, 0, 0, 0, 0);
        }
        // The example displays the following output:
        //      Population change, 1960 to 2010: 393,149
    }

    [TestMethod]
    public void Test3()
    {
        var p = new Person("John", "Quincy", "Adams", "Boston", "MA");

        // Deconstruct the person object.
        var (fName, _, city, _) = p;
        Console.WriteLine($"Hello {fName} of {city}!");
        // The example displays the following output:
        //      Hello John of Boston!
    }

    [TestMethod]
    public void Test4()
    {
        
    }
}