namespace Interface;

interface IControl
{
    void Paint();
}

interface ITextBox : IControl
{
    void SetText(string text);
}

interface IListBox : IControl
{
    void SetItems(string[] items);
}

interface IComboBox : ITextBox, IListBox { }

interface IDataBound
{
    void Bind();
}

public class EditBox : IControl, IDataBound
{
    public void Paint() { }
    public void Bind() { }
}



public class Car : IEquatable<Car>
{
    public string? Make { get; set; }
    public string? Model { get; set; }
    public string? Year { get; set; }

    public bool Equals(Car? other)
    {
        return (this.Make, this.Model, this.Year) == (other?.Make, other?.Model, other?.Year);
    }
}