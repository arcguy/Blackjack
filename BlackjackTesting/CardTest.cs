using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using cards;

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
        /// Testing UpdateMoney and GetMoney methods from the player class
        /// </summary>
        [TestMethod]
        public void PlayerMoneyTesting()
        {
            Player p = new Player("Test");
            Assert.AreEqual(100, p.GetMoney());

            p.UpdateMoney(-20);
            Assert.AreEqual(80, p.GetMoney());

            p.UpdateMoney(1000);
            Assert.AreEqual(1080, p.GetMoney());
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
    }
}
