using SimpleList;
using System.ComponentModel.Design;

var list = new DoubleLinkedList<string>();
var option = string.Empty;
var value = string.Empty;

do
{
    option = Menu();
    switch (option)
    {
        case "1":
            Console.Write("Enter value: ");
            value = Console.ReadLine() ?? string.Empty;
            list.Add(value);
            break;
        case "2":
            Console.WriteLine(list.ToString());
            break;
        case "3":
            Console.WriteLine(list.ToStringReverse());
            break;
        default:
            Console.WriteLine("Invalid option. Try again.");
            break;
    }
}while (option != "0");

string Menu()
{
    Console.WriteLine("1. Add");
    Console.WriteLine("2. Show list forward: ");
    Console.WriteLine("3. Show list backward: ");
    Console.Write("Enter your option: ");
    return Console.ReadLine() ?? string.Empty;
}