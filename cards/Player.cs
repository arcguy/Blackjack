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
        double money;
        double bet;
        int score;
        List<Card> drawnCards = new List<Card>();
        MetroLabel scoreLabel;
        MetroLabel moneyLabel;
        MetroListView displayBox;
        string name;

        public Player(string n, MetroLabel dl, MetroListView mlv) 
        {
            this.name = n;
            this.scoreLabel = dl;
            this.displayBox = mlv;
            this.money = 100;
            this.bet = 0;
        }

        public Player(string n, MetroLabel dl, MetroListView mlv, MetroLabel ml)
        {
            this.name = n;
            this.scoreLabel = dl;
            this.displayBox = mlv;
            this.moneyLabel = ml;
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
            moneyLabel.Text = "Money: $" + this.money.ToString();
        }

        public int GetScore()
        {
            return this.score;
        }

        public void UpdateScore(int updateAmount)
        {
            this.score += updateAmount;
            UpdateScoreDisplay();
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

        private void UpdateScoreDisplay()
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

        public void Reset()
        {
            this.bet = 0;
            this.score = 0;
            scoreLabel.Text = "Score: 0";
            drawnCards.Clear();
            displayBox.Clear();
        }
    }
}
