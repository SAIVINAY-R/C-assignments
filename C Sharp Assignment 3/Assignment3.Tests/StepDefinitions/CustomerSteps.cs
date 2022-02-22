using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Sharp_Assignment_3;

namespace Assignment3.Tests.StepDefinitions
{
    [Binding, Scope(Feature = "Placing an Order")]
    internal class CustomerSteps
    {
        ItemList menu;
        Customer customer;
        int result;
        [Given(@"I am a customer")]
        public void GivenIAmACustomer()
        {
            menu = new ItemList();
            customer = new Customer(menu);
        }

        [When(@"the items are available and user selects an item '([^']*)'")]
        public void WhenTheItemsAreAvailableAndUserSelectsAnItem(string p0)
        {
            menu["Chapathi"] = 35;
            menu["Dosa"] = 20;
            result = customer.PlaceAnOrder(int.Parse(p0), new RestaurantManager(menu));
        }

        [Then(@"the result should be '([^']*)'")]
        public void ThenTheResultShouldBe(string p0)
        {
            int expected = Convert.ToInt16(p0);
            Assert.Equal(expected, result);
        }

        [When(@"items are not available")]
        public void WhenItemsAreNotAvailable()
        {
            result = customer.PlaceAnOrder(-202, new RestaurantManager(menu));
        }

    }
}
