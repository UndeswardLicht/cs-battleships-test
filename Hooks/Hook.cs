using TechTalk.SpecFlow;
using AQB = Aquality.Selenium.Browsers;
using AQBS = Aquality.Selenium.Browsers.AqualityServices;
using Battleship.Utils;

namespace Battleship.Hooks
{
    [Binding]
    internal class Hook
    {
        protected AQB.Browser browser = AQBS.Browser;
        protected static readonly string url = "http://ru.battleship-game.org/";

        [BeforeScenario]
        public void Setup()
        {

            browser.Maximize();
            browser.GoTo(url);
            browser.WaitForPageToLoad();
        }

        [AfterScenario]
        public void TearDown()
        {

            browser.Quit();
            Store.CleanStore();
        }
    }
}
