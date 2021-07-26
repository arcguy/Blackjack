using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    public class Player
    {
        double money;
        int score;
        List<Card> drawnCards = new List<Card>();

        public Player(double m)
        {
            this.money = m;
        }

        public double GetMoney()
        {
            return this.money;
        }

        public void ModifyMoney(double changeAmount)
        {
            money += changeAmount;
        }

        public int GetScore()
        {
            return this.score;
        }

        public void ResetScore()
        {
            score = 0;
        }

        public void AddToDrawnCards(Card c)
        {
            drawnCards.Add(c);
        }

        public List<Card> GetDrawnCards()
        {
            return this.drawnCards;
        }
    }
}
