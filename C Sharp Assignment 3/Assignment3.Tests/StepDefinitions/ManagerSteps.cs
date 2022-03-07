using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Sharp_Assignment_3;

namespace Assignment3.Tests.StepDefinitions
{
    [Binding]
    internal class ManagerSteps
    {
        RestaurantManager manager;
        ItemList menu;
        Customer customer;
        dynamic result;
        dynamic expectedResult;
        [Given(@"I am a manager")]
        public void GivenIAmAManager()
        {
            menu = new();
            customer = new(menu);
            manager = new(menu);
        }

        [When(@"I select the Add Item To Menu and Enter item name '([^']*)' and price '([^']*)'")]
        public void WhenISelectTheAddItemToMenuAndEnterItemNameAndPrice(string p0, string p1)
        {
            menu["Dosa"] = 20;
            result = manager.AddItemToMenu(p0, int.Parse(p1));
        }

        [Then(@"the result should be true")]
        public void ThenTheResultShouldBeTrue()
        {
            Assert.True(result);
        }

        [Then(@"the result should be false")]
        public void ThenTheResultShouldBeFalse()
        {
            Assert.False(result);
        }

        [When(@"the order list is not empty and selected Get Last five Orders")]
        public void WhenTheOrderListIsNotEmptyAndSelectedGetLastFiveOrders()
        {
            menu["Idly"] = 15;
            customer.PlaceAnOrder(1, manager);
            result = manager.GetLast5Orders();
        }

        [Then(@"the result should be '([^']*)'")]
        public void ThenTheResultShouldBe(string p0)
        {
            if (p0 == "empty list")
            {
                Assert.Null(result);
            }
            else if (p0 == "list of last 5 orders")
            {
                Assert.True(result is List<string>);
            }
            else if (p0 == "list of items below the given price")
            {
                Assert.True(result is IDictionary<string, int>);
            }
            else
            {
                Assert.Equal(result, expectedResult);
            }
        }

        [When(@"the order list is empty and selected Get Last five Orders")]
        public void WhenTheOrderListIsEmptyAndSelectedGetLastFiveOrders()
        {
            result = manager.GetLast5Orders();
        }

        [When(@"the order list is not empty and selected get most popular item")]
        public void WhenTheOrderListIsNotEmptyAndSelectedGetMostPopularItem()
        {
            menu["Poori"] = 15;
            customer.PlaceAnOrder(1, manager);
            expectedResult = "Poori";
            result = manager.GetTheMostPopularItem();
        }

        [When(@"the order list is empty and selected get most popular item")]
        public void WhenTheOrderListIsEmptyAndSelectedGetMostPopularItem()
        {
            expectedResult = "No past orders in the Order History";
            result = manager.GetTheMostPopularItem();
        }
        [When(@"the order list is not empty and selected the Get the item with highest revenu")]
        public void WhenTheOrderListIsNotEmptyAndSelectedTheGetTheItemWithHighestRevenu()
        {
            menu["Poori"] = 15;
            customer.PlaceAnOrder(1, manager);
            expectedResult = "Poori";
            result = manager.GetTheItemWithHighestRevenue();
        }

        [When(@"the order list is empty and selected the Get the item with highest revenu")]
        public void WhenTheOrderListIsEmptyAndSelectedTheGetTheItemWithHighestRevenu()
        {
            expectedResult = "No past orders in the Order History";
            result = manager.GetTheItemWithHighestRevenue();
        }
        [When(@"their is no item below the given price '([^']*)'")]
        public void WhenTheirIsNoItemBelowTheGivenPrice(string p0)
        {
            result = manager.GetItemsBelowThePrice(int.Parse(p0));
        }

        [When(@"their are items below the given price '([^']*)'")]
        public void WhenTheirAreItemsBelowTheGivenPrice(string p0)
        {
            menu["Dosa"] = 10;
            result = manager.GetItemsBelowThePrice(int.Parse(p0));
        }
    }
}
