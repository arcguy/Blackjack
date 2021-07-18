using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace cards
{
    public partial class Form1 : Form
    {
        //Creating the initial deck
        List<Card> Deck = new List<Card>();
        List<Card> mainDeck = new List<Card>();
        int playerScore = 0;
        int dealerScore = 0;
        double money = 100;
        Random r = new Random();
        double bet = 0;
        int round = 1;

        public Form1()
        {
            InitializeComponent();

            for (int i = 1; i < 14; i++)
            {
                string value = "";
                if (i == 1)
                    value = "Ace";
                else if (i == 11)
                    value = "Jack";
                else if (i == 12)
                    value = "Queen";
                else if (i == 13)
                    value = "King";
                else
                    value = i.ToString();
                mainDeck.Add(new Card("Spades", value, i));
                mainDeck.Add(new Card("Clubs", value, i));
                mainDeck.Add(new Card("Diamonds", value, i));
                mainDeck.Add(new Card("Hearts", value, i));
            }

            Initialize();
            labelMoney.Text = "Money: $" + money.ToString();
        }

        private void buttonHit_Click(object sender, EventArgs e)
        {
            Draw("player", 1);
            if (playerScore >= 21)
                CheckWin();
        }

        private void buttonStand_Click(object sender, EventArgs e)
        {
            Draw("dealer", 1);

            while (dealerScore < 17)
            {
                Draw("dealer", 1);
                Thread.Sleep(r.Next(100, 1000));
                listBoxDealer.Update();
                labelDealerScore.Update();
            }
            CheckWin();
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            Initialize();
            bet = 0;
            round++;
        }

        private void Initialize()
        {
            //set buttons to be enabled or not
            buttonHit.Enabled = false;
            buttonStand.Enabled = false;
            buttonRestart.Enabled = false;
            buttonConfirmBet.Enabled = true;
            textBoxBet.Enabled = true;
            //clear the listboxes and reset labels and scores
            playerScore = 0;
            dealerScore = 0;
            listBoxDealer.Items.Clear();
            listBoxPlayer.Items.Clear();
            labelDealerScore.ResetText();
            labelPlayerScore.ResetText();
            labelDisplay.Text = "";
            
            //create the deck
            Deck.Clear();
            //for (int i = 1; i < 14; i++)
            //{
            //    string value = "";
            //    if (i == 1)
            //        value = "Ace";
            //    else if (i == 11)
            //        value = "Jack";
            //    else if (i == 12)
            //        value = "Queen";
            //    else if (i == 13)
            //        value = "King";
            //    else
            //        value = i.ToString();
            //    Deck.Add(new Card("Spades", value, i));
            //    Deck.Add(new Card("Clubs", value, i));
            //    Deck.Add(new Card("Diamonds", value, i));
            //    Deck.Add(new Card("Hearts", value, i));
            //}
            Deck.AddRange(mainDeck);
            labelRound.Text = "Round " + round;
            //Initial draw
            //Draw("player", 2);
            //Draw("dealer", 1);
        }

        /// <summary>
        /// Draws a specified number of cards for the specified player
        /// </summary>
        /// <param name="user">Who is drawing cards</param>
        /// <param name="draws">How many cards to draw</param>
        private void Draw(string user, int draws)
        {
            for (int i = 0; i < draws; i++)
            {
                if (user == "player")
                {
                    Card draw = Deck[r.Next(Deck.Count)];
                    if (draw.GetValue() == "Ace")
                        playerScore += draw.GetBlackjackValue(playerScore);
                    else
                        playerScore += draw.GetBlackjackValue();
                    listBoxPlayer.Items.Add(draw.ToString());
                    Deck.Remove(draw);
                    labelPlayerScore.Text = "Player Score: " + playerScore;
                }
                else
                {
                    Card draw = Deck[r.Next(Deck.Count)];
                    if (draw.GetValue() == "Ace")
                        dealerScore += draw.GetBlackjackValue(playerScore);
                    else
                        dealerScore += draw.GetBlackjackValue();
                    listBoxDealer.Items.Add(draw.ToString());
                    Deck.Remove(draw);
                    labelDealerScore.Text = "Dealer Score: " + dealerScore;
                }
            }          
        }

        private void CheckWin()
        {
            string winstate = "";
            if (playerScore == 21)
            {
                if (dealerScore > 21)
                {
                    winstate = "Blackjack";
                }
                else if (dealerScore == 21)
                    winstate = "Draw";
                else
                    winstate = "Blackjack";
            }
            else if (playerScore < 21)
            {
                if (dealerScore <= 21)
                {
                    if (playerScore > dealerScore)
                    {
                        winstate = "Win";
                    }
                    else if (playerScore == dealerScore)
                        winstate = "Draw";
                    else
                        winstate = "Loss";
                }
                else
                    winstate = "Win";
            }
            else
                winstate = "Loss";

            labelDisplay.Text = winstate;
            if (winstate == "Draw")
                money += bet;
            else if (winstate == "Win")
                money += bet * 2;
            else if (winstate == "Blackjack")
                money += bet * 2.5;

            DisableControls();
            UpdateMoney();
        }
        
        private void DisableControls()
        {
            buttonHit.Enabled = false;
            buttonStand.Enabled = false;
            buttonRestart.Enabled = true;
        }

        private void buttonConfirmBet_Click(object sender, EventArgs e)
        {
            try
            {
                bet = double.Parse(textBoxBet.Text);
                if (bet > money)
                {
                    MessageBox.Show("You cannot bet more money than you have");
                }
                else
                {
                    money -= bet;
                    UpdateMoney();
                    buttonConfirmBet.Enabled = false;
                    textBoxBet.Enabled = false;
                    buttonHit.Enabled = true;
                    buttonStand.Enabled = true;
                    //Initial draw
                    Draw("player", 2);
                    Draw("dealer", 1);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); 
            }
        }

        private void UpdateMoney()
        {
            labelMoney.Text = "Money: $" + money;
        }
    }
}
