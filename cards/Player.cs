using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;

namespace cards
{
    public class Player
    {
        string name;
        double money;
        double bet;
        int score;
        List<Card> drawnCards = new List<Card>();      

        public Player(string n) 
        {
            this.name = n;
            this.money = 100;
            this.bet = 0;
        }

        public double GetMoney()
        {
            return this.money;      
        }

        public void UpdateMoney(double changeAmount)
        {
            this.money += changeAmount;
        }

        public int GetScore()
        {
            return this.score;
        }

        public void UpdateScore(int updateAmount)
        {
            this.score += updateAmount;
        }

        public void AddToDrawnCards(Card c)
        {
            this.drawnCards.Add(c);
        }

        public List<Card> GetDrawnCards()
        {
            return this.drawnCards;
        }

        public void SetBet(double betAmount)
        {
            this.bet = betAmount;
        }

        public double GetBet()
        {
            return this.bet;
        }

        public void UpdateScoreDisplay(MetroLabel scoreLabel, MetroListView displayBox)
        {
            displayBox.BeginUpdate();
            displayBox.Clear();
            displayBox.Columns.Add(name);
            displayBox.View = View.Details;
            foreach (Card c in drawnCards)
                displayBox.Items.Add(c.ToString());
            displayBox.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            displayBox.EndUpdate();
            scoreLabel.Text = this.name + " Score: " + this.score;
        }

        public void ResetDisplay(MetroLabel scoreLabel, MetroListView displayBox)
        {
            
            scoreLabel.Text = "Score: 0";
            drawnCards.Clear();
            displayBox.Clear();
        }

        public void Reset()
        {
            this.bet = 0;
            this.score = 0;
        }

        public string GetName()
        {
            return this.name;
        }

        public void UpdateMoneyDisplay(MetroLabel moneyLabel)
        {
            moneyLabel.Text = "Money: $" + this.GetMoney().ToString();
        }
    }
}
