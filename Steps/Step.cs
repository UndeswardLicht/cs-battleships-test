using Aquality.Selenium.Elements;
using Battleship.Pages;
using NUnit.Framework.Legacy;
using System;
using System.Security.Policy;
using TechTalk.SpecFlow;

namespace Battleship.Steps
{
    [Binding]
    public class Step
    {
        MainPage mainPage = new();

        [When("I continue to the site even though it doesn't have secure connection")]
        public void ContinueToTheSite()
        {
            //mainPage.ContinueToSite();
        }

    	[Then("The site main page is displayed")]
        public void MainPageIsDisplayed()
        {
            ClassicAssert.IsTrue(mainPage.State.IsDisplayed);
        }

        [When("I randomly select the battleships position")]
        public void SelectRandomShipPosition()
        {
            mainPage.PlaceShipsRandom();
        }

        [When("I select a random person to play with")]
        public void SelectRandomOpponent()
        {
//            mainPage.SelectOponentFriend();
            mainPage.SelectOponentRandom();
        }

        [When("I click Play button")]
        public void ClickThePlay()
        {
            mainPage.StartGame();
        }

        [When("I wait for the other person to join")]
        public void WaitForOtherPerson()
        {
            mainPage.WaitForOpponentToAppear();
        }

        [When("I use the algorithm to play the battle")]
        public void UseTheAlgorithm()
        {
            mainPage.WinningAlgorithm();
        }

        [Then("I win")]
        public void CheckTheWin()
        {
            ClassicAssert.IsTrue(mainPage.WasGameWon(), "Game ended but you haven't won");
        }
    }
}
