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
                   itemNumber = -202;
                }
                else
                {
                    Console.WriteLine("\nSelect an item to place order:");
                    menu.PrintItemsInList();
                    Console.Write("\n>> ");
                    itemNumber = int.Parse(Console.ReadLine());
                }
                var result = customer.PlaceAnOrder(itemNumber, manager);
                if(result == -1)
                {
                    Console.WriteLine("\nThere are no items to order!");
                }
                else if (result == 0)
                {
                    Console.WriteLine("\nInvalid Item");
                }
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
                        if (String.IsNullOrWhiteSpace(itemName))
                        {
                            throw new IOException();
                        }
                        Console.WriteLine("\nEnter item price:");
                        Console.Write(">> ");
                        int itemPrice = int.Parse(Console.ReadLine());
                        if (manager.AddItemToMenu(itemName, itemPrice) != true)
                        {
                            Console.WriteLine("Item already exists");
                        }
                        
                        break;
                    case 2:
                        if (manager.GetLast5Orders() == "202 Error")
                        {
                            Console.WriteLine("No past orders in the Order History");
                        } 
                        break;
                    case 3:
                        if(manager.GetTheMostPopularItem() == "203 Error")
                        {
                            Console.WriteLine("No past orders in the Order History");
                        }
                        break;
                    case 4:
                        if(manager.GetTheItemWithHighestRevenue() == "204 Error")
                        {
                            Console.WriteLine("No past orders in the Order History");
                        }
                        break;
                    case 5:
                        Console.WriteLine("\nEnter the price:");
                        Console.Write(">> ");
                        int price = int.Parse(Console.ReadLine());
                        if (manager.GetItemsBelowThePrice(price) == "205 Error")
                        {                   
                            Console.WriteLine("No Item below the price {0}", price);
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
    catch (Exception e)
    {
        Console.WriteLine("Invalid Input {0}", e);
    }

}