using C_Sharp_Assignment_3;

ItemList menu = new ItemList();
RestaurantManager manager = new(menu);
Customer customer = new(menu);

while (true)
{
    Console.WriteLine("\nSelect user type (Or close the application to exit): ");
    Console.WriteLine("\t1. Customer");
    Console.WriteLine("\t2. Restaurant Manager\n");
    Console.Write(">> ");
    try
    {
        int userType = int.Parse(Console.ReadLine());

        switch (userType)
        {
            case 1:
                int itemNumber;
                if (menu.Count() == 0)
                {
                   itemNumber = -1;
                }
                else
                {
                    Console.WriteLine("\nSelect an item to place order:");
                    menu.PrintItemsInList();
                    Console.Write("\n>> ");
                    itemNumber = int.Parse(Console.ReadLine());
                }
                customer.PlaceAnOrder(itemNumber, manager);
                break;
            case 2:
                Console.WriteLine("\n\t1. Add item to menu");
                Console.WriteLine("\t2. Get last 5 orders");
                Console.WriteLine("\t3. Get the most popular item");
                Console.WriteLine("\t4. Get the item with highest revenue");
                Console.WriteLine("\t5. Get items below the price");
                Console.Write("\n>> ");

                var queryType = int.Parse(Console.ReadLine());

                switch (queryType)
                {
                    case 1:
                        Console.WriteLine("\nEnter item name:");
                        Console.Write(">> ");
                        var itemName = Console.ReadLine();
                        Console.WriteLine("\nEnter item price:");
                        Console.Write(">> ");
                        int itemPrice = int.Parse(Console.ReadLine());
                        manager.AddItemToMenu(itemName, itemPrice);
                        break;
                    case 2:
                        var last5orders = manager.GetLast5Orders();
                        if (last5orders != null)
                        {
                            foreach (var item in last5orders)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine(manager.GetTheMostPopularItem());
                        break;
                    case 4:
                        Console.WriteLine(manager.GetTheItemWithHighestRevenue());
                        break;
                    case 5:
                        Console.WriteLine("\nEnter the price:");
                        Console.Write(">> ");
                        int price = int.Parse(Console.ReadLine());
                        var items = manager.GetItemsBelowThePrice(price);
                        if (items != null)
                        {
                            foreach (var item in items)
                            {
                                Console.WriteLine(item.Key + " - " + item.Value);
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("\nEnter a valid Query Type");
                        break;
                }
                break;
            default:
                Console.WriteLine("\nEnter valid user type");
                break;

        }

    }
    catch (Exception)
    {
        Console.WriteLine("Invalid Input");
    }

}