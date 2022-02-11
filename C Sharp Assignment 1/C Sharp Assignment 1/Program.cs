using C_Sharp_Assignment_1;

Console.Write("Enter the Program Number : ");
var programNumber = Console.ReadLine();

switch (int.Parse(programNumber))
{
    case 1 :
        var sumOfNumbers = new SumOfNumbers();
        sumOfNumbers.Sum();
        break;
    case 2 :
        var maximumOfNumbers = new MaximumOfNumbers();
        maximumOfNumbers.FindMaximum();
        break;
    case 3 :
        var smallestOfNumbers = new SmallestOfNumbers();
        smallestOfNumbers.FindThreeSmallNumbers();
        break;
    case 4 :
        var descendingOrder = new DescendingOrder();
        descendingOrder.FindDescendingOrder();
        break;
    default :
        Console.WriteLine("Enter Correct Program Number");
        break;
}
