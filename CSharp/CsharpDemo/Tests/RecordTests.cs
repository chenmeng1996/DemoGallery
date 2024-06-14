namespace Record;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    // record 值相等 性质
    public void Test1()
    {
        var phoneNumbers = new string[2];
        Person person1 = new("Nancy", "Davolio", phoneNumbers);
        Person person2 = new("Nancy", "Davolio", phoneNumbers);
        Console.WriteLine(person1 == person2); // output: True

        person1.PhoneNumbers[0] = "555-1234";
        Console.WriteLine(person1 == person2); // output: True

        Console.WriteLine(ReferenceEquals(person1, person2)); // output: False
    }

    [TestMethod]
    // with表达式 复制不可变对象和更改其中一个属性
    public void Test2()
    {
        Person2 person1 = new("Nancy", "Davolio") {PhoneNumbers = new string[1]};
        Console.WriteLine(person1);

        Person2 person2 = person1 with {FirstName = "John"};
        Console.WriteLine(person2);
        Console.WriteLine(person1 == person2); // output: False

        person2 = person1 with {PhoneNumbers = new string[1]};
        Console.WriteLine(person2);
        Console.WriteLine(person1 == person2); // output: False

        person2 = person1 with {};
        Console.WriteLine(person1 == person2);
    }
}