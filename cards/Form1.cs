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
        int round = 0;

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

        /// <summary>
        /// Draws a card for the player. If they reach a score of 21 or greater the CheckWin method is invoked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHit_Click(object sender, EventArgs e)
        {
            Draw("player", 1);
            if (playerScore >= 21)
            {
                while (dealerScore < 17)
                {
                    Draw("dealer", 1);
                    Thread.Sleep(r.Next(150, 1000));
                    listBoxDealer.Update();
                    labelDealerScore.Update();
                }
                CheckWin();
            }
        }

        /// <summary>
        /// Causes the dealer to begin drawing cards until they have a score of 17 or greater. They must draw at least one card.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStand_Click(object sender, EventArgs e)
        {
            Draw("dealer", 1);

            while (dealerScore < 17)
            {
                Draw("dealer", 1);
                Thread.Sleep(r.Next(150, 1000));
                listBoxDealer.Update();
                labelDealerScore.Update();
            }
            CheckWin();
        }

        /// <summary>
        /// begins the next round
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRestart_Click(object sender, EventArgs e)
        {
            Initialize();
            
        }

        /// <summary>
        /// enables and disables specific buttons for the start of the round. Resets the deck and scores, updates displays.
        /// </summary>
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
            labelDisplay.Text = "Confirm bet to continue";
            bet = 0;
            round++;

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

        /// <summary>
        /// Checks if the player has blackjack and then either wins, loses or draws with the dealer. Money is updated based on win state.
        /// </summary>
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
                        winstate = "Bust";
                }
                else
                    winstate = "Win";
            }
            else
                winstate = "Bust";

            if (winstate == "Draw")
            {
                //money += bet;
                UpdateMoney(bet);
                labelDisplay.Text = winstate + " Bet refunded";
            }
            else if (winstate == "Win")
            {
                //money += bet * 2;
                UpdateMoney(bet * 2);
                labelDisplay.Text = winstate + " 2x bet won";
            }
            else if (winstate == "Blackjack")
            {
                //money += bet * 2.5;
                UpdateMoney(bet * 2.5);
                labelDisplay.Text = winstate + " 2.5x bet won";
            } 
            else
                labelDisplay.Text = winstate + " Bet lost";

            buttonHit.Enabled = false;
            buttonStand.Enabled = false;
            buttonRestart.Enabled = true;
        }

        /// <summary>
        /// Locks in the players bet and then does the initial 2 draws for the player and initial 1 draw for the dealer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConfirmBet_Click(object sender, EventArgs e)
        {
            try
            {
                bet = double.Parse(textBoxBet.Text);
                if (bet > money)
                    MessageBox.Show("You cannot bet more money than you have");
                else if (bet < 1)
                    MessageBox.Show("Bet cannot be less than 1");
                else
                {
                    //money -= bet;
                    UpdateMoney(bet * -1);
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

        /// <summary>
        /// Updates the players money and the label displaying the players current money
        /// </summary>
        /// <param name="updateAmount">The amount to modify the money count by. Can be negative or positive</param>
        private void UpdateMoney(double updateAmount)
        {
            money += updateAmount;
            labelMoney.Text = "Money: $" + money;
            labelDisplay.Text = "Press Hit to draw a card or Stand to end your turn";
        }
    }
}
