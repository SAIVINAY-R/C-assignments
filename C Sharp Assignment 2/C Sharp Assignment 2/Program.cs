using C_Sharp_Assignment_2;

Console.Write("Enter the Program number to execute i.e 1,2 : ");
var programNumber = int.Parse(Console.ReadLine());

switch (programNumber)
{
case 1:
        var calculator = new Calculator();
        int choice = 1;

        while (choice < 5 && choice > 0)
        {
            Console.WriteLine("\n1 to add two integers");
            Console.WriteLine("2 to add three integers");
            Console.WriteLine("3 to add two floating point numbers");
            Console.WriteLine("4 to get the Result");
            Console.Write("Enter your choice : ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter 2 Integers : ");
                    var number1 = int.Parse(Console.ReadLine());
                    var number2 = int.Parse(Console.ReadLine());
                    calculator.Add(number1, number2);
                    break;
                case 2:
                    Console.WriteLine("Enter 2 Integers : ");
                    var number3 = int.Parse(Console.ReadLine());
                    var number4 = int.Parse(Console.ReadLine());
                    var number5 = int.Parse(Console.ReadLine());
                    calculator.Add(number3, number4, number5);
                    break;
                case 3:
                    Console.WriteLine("Enter 2 Integers : ");
                    var number6 = float.Parse(Console.ReadLine());
                    var number7 = float.Parse(Console.ReadLine());
                    calculator.Add(number6, number7);
                    break;
                case 4:
                    Console.WriteLine("The Result is {0}", calculator.GetResult());
                    break;
            }
        }
        break;
    case 2:
        var advanceCalculator = new AdvancedCalculator();
        int choice2 = 1;

        while (choice2 < 6 && choice2 > 0)
        {
            Console.WriteLine("\n1 to add two integers");
            Console.WriteLine("2 to add three integers");
            Console.WriteLine("3 to add two floating point numbers");
            Console.WriteLine("4 to find the Power");
            Console.WriteLine("5 to get the Result");
            Console.Write("Enter your choice : ");
            choice2 = int.Parse(Console.ReadLine());

            switch (choice2)
            {
                case 1:
                    Console.WriteLine("Enter 2 Integers : ");
                    var number1 = int.Parse(Console.ReadLine());
                    var number2 = int.Parse(Console.ReadLine());
                    advanceCalculator.Add(number1, number2);
                    break;
                case 2:
                    Console.WriteLine("Enter 2 Integers : ");
                    var number3 = int.Parse(Console.ReadLine());
                    var number4 = int.Parse(Console.ReadLine());
                    var number5 = int.Parse(Console.ReadLine());
                    advanceCalculator.Add(number3, number4, number5);
                    break;
                case 3:
                    Console.WriteLine("Enter 2 Integers : ");
                    var number6 = float.Parse(Console.ReadLine());
                    var number7 = float.Parse(Console.ReadLine());
                    advanceCalculator.Add(number6, number7);
                    break;
                case 4:
                    Console.WriteLine("Enter 2 Numbers : ");
                    var @base = float.Parse(Console.ReadLine());
                    var exponent = float.Parse(Console.ReadLine());
                    advanceCalculator.Power(@base, exponent);
                    break;
                case 5:
                    Console.WriteLine("The Result is {0}", advanceCalculator.GetResult());
                    break;
            }
        }

        break;
}