using System.Collections;

var arr = new BitArray(9);

Console.WriteLine(arr[5].GetType());
Console.WriteLine(arr[5].ToString() ?? "Nothing");

Console.ReadKey();

Array array = new object[10];

ICollection<object>? collection = array as ICollection<object>;

object[] arrayForClone = new object[10];

array.SetValue(99, 0);
array.SetValue(new object(), 1);
array.SetValue("Hi", 2);

collection?.CopyTo(arrayForClone, 0);

Console.WriteLine((collection!.ToArray())[0] ?? "Nothing");
Console.WriteLine(arrayForClone[0] ?? "Nothing");

array.SetValue("number", 0);

Console.WriteLine(arrayForClone[0] ?? "Nothing");

//Console.WriteLine(array.GetValue(0) ?? "Nothing");



//Console.WriteLine(array.GetValue(0) ?? "Nothing");
//Console.WriteLine(array.GetValue(1) ?? "Nothing");
//Console.WriteLine(array.GetValue(2) ?? "Nothing");

//object? obj = new DemoClass();

//Console.WriteLine("****");
//Console.WriteLine(array.GetValue(1) ?? "Nothing");
//Console.WriteLine(obj);

Console.ReadKey();

class DemoClass(int value, string? name)
{
    public DemoClass() : this(0, null) { }

    public int Value { get; set; } = value;
    public string? Name { get; set; } = name;

    public override string ToString() => $"Value = {Value}, Name = {Name ?? "Nothing"}";
}