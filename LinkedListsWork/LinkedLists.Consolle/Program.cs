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
        case "4":
            Console.Write("Enter value: ");
            value = Console.ReadLine() ?? string.Empty;
            list.SortDescending(value);
            break;
        case "7":
            Console.Write("Enter value: ");
            value = Console.ReadLine() ?? string.Empty;
            Console.WriteLine(list.Exists(value) ? "¡Exists!" : "¡Doesn't exist!");
            break;
        case "0":
            Console.WriteLine("Exiting...");
            break;
        default:
            Console.WriteLine("Invalid option. Try again.");
            break;
    }
}while (option != "0");

string Menu()
{
    Console.WriteLine("1. Add. ");
    Console.WriteLine("2. Show list forward. ");
    Console.WriteLine("3. Show list backward. ");
    Console.WriteLine("4. Sort descending. ");
    Console.WriteLine("7. Exists. ");
    Console.WriteLine("0. Exit. ");
    Console.Write("Enter your option: ");
    return Console.ReadLine() ?? string.Empty;
}