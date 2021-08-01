using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using cards;
using MetroFramework;
using MetroFramework.Controls;

namespace BlackjackTesting
{
    [TestClass]
    public class CardTest
    {
        /// <summary>
        /// Testing whether cards return the correct score values
        /// </summary>
        [TestMethod]
        public void GetCardValueTest()
        {
            Card ace = new Card("Clubs", "Ace", 1);
            Card two = new Card("Clubs", "2", 2);
            Card three = new Card("Clubs", "3", 3);
            Card four = new Card("Clubs", "4", 4);
            Card five = new Card("Clubs", "5", 5);
            Card six = new Card("Clubs", "6", 6);
            Card seven = new Card("Clubs", "7", 7);
            Card eight = new Card("Clubs", "8", 8);
            Card nine = new Card("Clubs", "9", 9);
            Card ten = new Card("Clubs", "10", 10);
            Card jack = new Card("Diamonds", "Jack", 11);
            Card queen = new Card("Hearts", "Queen", 12);
            Card king = new Card("Spades", "King", 13);
            Card error = new Card("kjhf", "gfdkj", 20);

            Assert.AreEqual(11, ace.GetBlackjackValue(5));
            Assert.AreEqual(1, ace.GetBlackjackValue(12));
            Assert.AreEqual(2, two.GetBlackjackValue(10));
            Assert.AreEqual(3, three.GetBlackjackValue(10));
            Assert.AreEqual(4, four.GetBlackjackValue(10));
            Assert.AreEqual(5, five.GetBlackjackValue(10));
            Assert.AreEqual(6, six.GetBlackjackValue(10));
            Assert.AreEqual(7, seven.GetBlackjackValue(10));
            Assert.AreEqual(8, eight.GetBlackjackValue(10));
            Assert.AreEqual(9, nine.GetBlackjackValue(10));
            Assert.AreEqual(10, ten.GetBlackjackValue(10));
            Assert.AreEqual(10, jack.GetBlackjackValue(10));
            Assert.AreEqual(10, queen.GetBlackjackValue(10));
            Assert.AreEqual(10, king.GetBlackjackValue(10));
            Assert.AreEqual(10, error.GetBlackjackValue(10));
        }

        /// <summary>
        /// Testing UpdateMoney and GetMoney methods from the player class and also making sure the 
        /// </summary>
        [TestMethod]
        public void PlayerMoneyTesting()
        {
            Player p1 = new Player("Test");

            Assert.AreEqual(100, p1.GetMoney());

            p1.UpdateMoney(-20);
            Assert.AreEqual(80, p1.GetMoney());

            p1.UpdateMoney(1000);
            Assert.AreEqual(1080, p1.GetMoney());
        }

        /// <summary>
        /// Tests to make sure the correct amounts of money are paid out by the ProcessOutcome() method from the Game class
        /// </summary>
        [TestMethod]
        public void BetTesting()
        {
            Player p1 = new Player("Test");
            MetroLabel l = new MetroLabel();
            MetroButton b = new MetroButton();
            MetroTextBox t = new MetroTextBox();
            MetroListView ls = new MetroListView();
            Game gc = new Game(l, b, b, b, b, t, l, l, ls, ls, l, l);

            p1.SetBet(10);
            gc.ProcessOutcome("Blackjack", p1);
            Assert.AreEqual(125, p1.GetMoney());

            gc.ProcessOutcome("Win", p1);
            Assert.AreEqual(145, p1.GetMoney());

            gc.ProcessOutcome("Draw", p1);
            Assert.AreEqual(155, p1.GetMoney());
        }

        /// <summary>
        /// Testing UpdateScore and GetScore methods from the player class and also the score resetting part of the Reset method.
        /// </summary>
        [TestMethod]
        public void PlayerScoreTesting()
        {
            Player p = new Player("Test");
            Assert.AreEqual(0, p.GetScore());

            p.UpdateScore(5);
            Assert.AreEqual(5, p.GetScore());

            p.UpdateScore(16);
            Assert.AreEqual(21, p.GetScore());

            p.UpdateScore(-10);
            Assert.AreEqual(11, p.GetScore());

            p.Reset();
            Assert.AreEqual(0, p.GetScore());
        }

        /// <summary>
        /// Testing the checkwin method in the Game class
        /// </summary>
        [TestMethod]
        public void CheckwinTesting()
        {
            MetroLabel l = new MetroLabel();
            MetroButton b = new MetroButton();
            MetroTextBox t = new MetroTextBox();
            MetroListView ls = new MetroListView();

            Player p1 = new Player("Test");
            Player dealer = new Player("Dealer");
            Game gc = new Game(l, b, b, b, b, t, l, l, ls, ls, l, l);

            //p1 score: 21, dealer score: 22
            p1.UpdateScore(21);
            dealer.UpdateScore(22);
            Assert.AreEqual(gc.CheckWin(p1, dealer), "Blackjack");

            //p1 score: 21, dealer score: 21
            dealer.UpdateScore(-1);
            Assert.AreEqual(gc.CheckWin(p1, dealer), "Blackjack");

            //p1 score: 20, dealer score: 22
            p1.UpdateScore(-1);
            dealer.UpdateScore(1);
            Assert.AreEqual(gc.CheckWin(p1, dealer), "Win");

            //p1 score: 20, dealer score: 20
            dealer.UpdateScore(-2);
            Assert.AreEqual(gc.CheckWin(p1, dealer), "Draw");

            //p1 score: 22, dealer score: 20
            p1.UpdateScore(2);
            Assert.AreEqual(gc.CheckWin(p1, dealer), "Bust");

            //p1 score: 19, dealer score: 18
            p1.UpdateScore(-3);
            dealer.UpdateScore(-4);
            Assert.AreEqual(gc.CheckWin(p1, dealer), "Win");
        }
    }
}
