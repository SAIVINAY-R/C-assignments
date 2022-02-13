using C_Sharp_Assignment_2;


while (true)
{
    Console.Write("\nEnter the Program number to execute i.e 1,2 or \"0\" to exit : ");
    var programNumber = int.Parse(Console.ReadLine());

    if (programNumber == 0)
        break;
    Instantiate instance;
    switch (programNumber)
    {
        case 1:
            instance = new Instantiate(new Calculator());
            instance.Calculate(programNumber);
            break;
        case 2:
            instance = new Instantiate(new AdvancedCalculator());
            instance.Calculate(programNumber);
            break;
        default:
            Console.WriteLine("Enter the correct programNumber");
            break;
    }

}