using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;

namespace Battleship.Pages
{
    internal class MainPage : Aquality.Selenium.Forms.Form
    {
        private static ILabel square(int x, int y) => ElementFactory.GetLabel(
            By.XPath($"//*[@class ='battlefield battlefield__rival']//*[contains(@class, 'battlefield-cell__empty')]//div[@data-y='{y}' and @data-x='{x}']"), "label for square");
        private ILabel playButton = ElementFactory.GetLabel(
            By.XPath("//*[contains(@class, 'battlefield-gap')]//*[contains(@class, 'battlefield-start-button')]"),"button 'Play'");
        private ILabel continueToSiteButton = ElementFactory.GetLabel(
            By.XPath("//*[@id='proceed-button']"), "'Continue to site' button");
        private ILabel placeShipsRandomly = ElementFactory.GetLabel(
            By.XPath("//*//li[contains(@class, 'placeships-variant placeships-variant__randomly')]"), "'Place ships randomly' button");
        private ILabel selectRandomOpponent = ElementFactory.GetLabel(
            By.XPath("//*[contains(@class,'battlefield-start-choose_rival-variants')]//*[contains(text(), 'случайный')]"), "'Select random opponent' button");
        //TODO delete  selecting a known opponent later
        private ILabel selectKnownOpponent = ElementFactory.GetLabel(
            By.XPath("//*[contains(@class,'battlefield-start-choose_rival-variants')]//*[contains(text(), 'знакомый')]"), "'Select random opponent' button");
        private ILabel gameLostLabel = ElementFactory.GetLabel(
            By.XPath("//*[@class='notifications']//*[contains(@class, 'game-over-lose') and not(contains(@class, 'none'))]"), "game lost label");       
        private ILabel gameWonLabel = ElementFactory.GetLabel(
            By.XPath("//*[@class='notifications']//*[contains(@class, 'game-over-win') and not(contains(@class, 'none'))]"), "game lost label");       
        private ILabel myMoveLabel = ElementFactory.GetLabel(
            By.XPath("//*[@class='notifications']//*[contains(@class, 'move-on') and not(contains(@class, 'none'))]"), "my move label");
        private ILabel opponentLeftLabel= ElementFactory.GetLabel(
            By.XPath("//*[@class='notifications']//*[contains(@class, 'rival-leave') and not(contains(@class, 'none'))]"), "opponent left label");
        private ILabel gameErrorLabel = ElementFactory.GetLabel(
            By.XPath("//*[@class='notifications']//*[contains(@class, 'game-error') and not(contains(@class, 'none'))]"), "game error label");
        private ILabel serverErrorLabel = ElementFactory.GetLabel(
            By.XPath("//*[@class='notifications']//*[contains(@class, 'server-error') and not(contains(@class, 'none'))]"), "server error label");
        private ILabel waitingForOpponentLabel= ElementFactory.GetLabel(
            By.XPath("//*[@class='notifications']//*[contains(@class, 'wating-for-rival') and not(contains(@class, 'none'))]"), "waiting for opponent label");
        
        
        private Random random = new Random();
        public MainPage() : base(By.XPath("//*[header]//*[h1]//*[contains(text(), 'Морской бой')]"), "Battleships main page")
        {
        }

        public void StartGame()
        {
            playButton.Click();
        }

        public void ContinueToSite()
        {
            continueToSiteButton.Click();
        }

        public void PlaceShipsRandom()
        {
            placeShipsRandomly.Click();
        }

        public void SelectOponentRandom()
        {
            selectRandomOpponent.Click();
        }

        public void SelectOponentFriend()
        {
            selectKnownOpponent.Click();
        }

        public static void PlayInSquare(int x, int y)
        {
            square(x, y).Click();
        }

        public bool WaitForYourNextMove()
        {
            return myMoveLabel.State.WaitForExist();
        }

        public void WaitForOpponentToAppear()
        {
            waitingForOpponentLabel.State.WaitForNotExist();
        }

        //true if cannot find such notifications => nothing happened, game continues
        //false if such notifs aren't found => something happened, game might be over
        public bool GameContinues()
        {
            return !(serverErrorLabel.State.IsDisplayed 
                || gameErrorLabel.State.IsDisplayed
                || opponentLeftLabel.State.IsDisplayed
                || gameLostLabel.State.IsDisplayed
                || gameWonLabel.State.IsDisplayed);
        }

        //Since no real algorithm needed  - play randomly in existing empty squares
        public void WinningAlgorithm()
        {
            //while (GameContinues())
            //{
                int x = random.Next(0, 10);
                int y = random.Next(0, 10);

                while (!square(x,y).State.IsExist)
                {
                    x = random.Next(0, 10);
                    y = random.Next(0, 10);
                }
                PlayInSquare(x, y);
//            }
        }

       public bool WasGameWon()
        {
            return gameWonLabel.State.IsDisplayed;
        }
    }
}
