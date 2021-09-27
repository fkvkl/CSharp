using DemoBlaze.Drivers;
using DemoBlaze.Pages;
using DemoBlaze.Properties;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace DemoBlaze.Steps
{
    [Binding]
    public sealed class ShoppingStepDefs
    {

        HomePage homePage = new HomePage(Driver.Get());


        [Given(@"User is on the Home Page")]
        public void GivenUserIsOnTheHomePage()
        {
            Driver.Get().Navigate().GoToUrl(Resources.Url);
        }

        [When(@"User adds ""(.*)"" from ""(.*)""")]
        public void WhenUserAddsFrom(string product, string menu)
        {
            homePage.OpenMenu(menu).Click();
            homePage.SelectProduct(product).Click();
            homePage.addToChart.Click();
            Driver.Get().SwitchTo().Alert().Accept();
            homePage.home.Click();
        }

        [When(@"User removes ""(.*)"" from cart")]
        public void WhenUserRemovesFromCart(string p0)
        {
            
        }

        [When(@"User places order and captures and logs purchase ID and Amount")]
        public void WhenUserPlacesOrderAndCapturesAndLogsPurchaseIDAndAmount()
        {
           
        }

        [Then(@"User verifies purchase amount equals expected")]
        public void ThenUserVerifiesPurchaseAmountEqualsExpected()
        {
            
        }

    }
}
