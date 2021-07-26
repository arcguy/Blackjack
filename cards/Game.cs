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
using MetroFramework;
using MetroFramework.Forms;

/// <summary>
/// TODO
/// implement rounds
/// scoreboard
/// loss when out of $$$
/// testing
/// </summary>

namespace cards
{
    public partial class FormBlackjack : MetroForm
    {
        List<Card> Deck = new List<Card>(); //the deck that gets drawn from
        List<Card> mainDeck = new List<Card>(); //the initial deck that is used to reset the deck
        int playerScore = 0;
        int dealerScore = 0;
        double money = 100;
        Random r = new Random();
        double bet = 0;
        int round = 0;

        Player player1 = new Player(100);

        public FormBlackjack()
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
            metroLabelMoney.Text = "Money: $" + money.ToString();
        }

        /// <summary>
        /// enables and disables specific buttons for the start of the round. Resets the deck and scores, updates displays.
        /// </summary>
        public void Initialize()
        {
            if (round <= 10)
            {
                //set buttons to be enabled or not
                metroButtonHit.Enabled = false;
                metroButtonStand.Enabled = false;
                metroButtonRestart.Enabled = false;
                metroButtonConfirmBet.Enabled = true;
                metroTextBoxBet.Enabled = true;
                //clear the listboxes and reset labels and scores
                playerScore = 0;
                dealerScore = 0;

                metroListViewDealer.Clear();
                metroListViewDealer.Columns.Add("Dealer");

                metroListViewPlayer.Clear();
                metroListViewPlayer.Columns.Add("Player");
                metroLabelDealerScore.ResetText();
                metroLabelPlayerScore.ResetText();
                metroLabelDisplay.Text = "Confirm bet to continue";
                bet = 0;
                round++;

                //create the deck
                Deck.Clear();
                Deck.AddRange(mainDeck);
                metroLabelRound.Text = "Round " + round;
            }
            else
            {
                Scoreboard sb = new Scoreboard(money);
                this.Close();
                sb.Show();
            }
        }

        /// <summary>
        /// Draws a specified number of cards for the specified player
        /// </summary>
        /// <param name="user">Who is drawing cards</param>
        /// <param name="draws">How many cards to draw</param>
        public void Draw(string user, int draws)
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

                    metroListViewPlayer.BeginUpdate();
                    metroListViewPlayer.View = View.Details;
                    metroListViewPlayer.Items.Add(draw.ToString());
                    metroListViewPlayer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);                    
                    metroListViewPlayer.EndUpdate();

                    Deck.Remove(draw);
                    metroLabelPlayerScore.Text = "Player Score: " + playerScore;
                }
                else
                {
                    Card draw = Deck[r.Next(Deck.Count)];
                    if (draw.GetValue() == "Ace")
                        dealerScore += draw.GetBlackjackValue(playerScore);
                    else
                        dealerScore += draw.GetBlackjackValue();

                    metroListViewDealer.BeginUpdate();
                    metroListViewDealer.View = View.Details;
                    metroListViewDealer.Items.Add(draw.ToString());
                    metroListViewDealer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    metroListViewDealer.EndUpdate();

                    Deck.Remove(draw);
                    metroLabelDealerScore.Text = "Dealer Score: " + dealerScore;
                }
            }          
        }

        /// <summary>
        /// Checks if the player has blackjack and then either wins, loses or draws with the dealer. Money is updated based on win state.
        /// </summary>
        public void CheckWin()
        {
            string winstate;
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
                UpdateMoney(bet);
                metroLabelDisplay.Text = winstate + ". Bet refunded";
            }
            else if (winstate == "Win")
            {
                UpdateMoney(bet * 2);
                metroLabelDisplay.Text = winstate + ". 2x bet won";
            }
            else if (winstate == "Blackjack")
            {
                UpdateMoney(bet * 2.5);
                metroLabelDisplay.Text = winstate + ". 2.5x bet won";
            } 
            else
                metroLabelDisplay.Text = winstate + ". Bet lost";

            metroButtonHit.Enabled = false;
            metroButtonStand.Enabled = false;
            metroButtonRestart.Enabled = true;

            if (money < 1)
            {
                Scoreboard sb = new Scoreboard(money);
                this.Close();
                sb.Show();
            }
        }

        /// <summary>
        /// Updates the players money and the label displaying the players current money
        /// </summary>
        /// <param name="updateAmount">The amount to modify the money count by. Can be negative or positive</param>
        public void UpdateMoney(double updateAmount)
        {
            money += updateAmount;
            metroLabelMoney.Text = "Money: $" + money;
            metroLabelDisplay.Text = "Press Hit to draw a card or Stand to end your turn";
        }

        /// <summary>
        /// Draws a card for the player. If they reach a score of 21 or greater the CheckWin method is invoked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButtonHit_Click(object sender, EventArgs e)
        {
            Draw("player", 1);
            //Thread.Sleep(150);
            if (playerScore >= 21)
            {
                metroLabelDisplay.Text = "Bust. Bet lost";
                while (dealerScore < 17)
                {
                    Draw("dealer", 1);
                    metroLabelDealerScore.Update();
                    Thread.Sleep(r.Next(150, 500));
                }
                CheckWin();
            }
        }

        /// <summary>
        /// Causes the dealer to begin drawing cards until they have a score of 17 or greater. They must draw at least one card.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButtonStand_Click(object sender, EventArgs e)
        {
            Draw("dealer", 1);

            while (dealerScore < 17)
            {
                Draw("dealer", 1);                
                metroLabelDealerScore.Update();
                Thread.Sleep(r.Next(150, 500));
            }
            CheckWin();
        }

        /// <summary>
        /// begins the next round
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButtonRestart_Click(object sender, EventArgs e)
        {
            Initialize();
        }

        /// <summary>
        /// Locks in the players bet and then does the initial 2 draws for the player and initial 1 draw for the dealer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButtonConfirmBet_Click(object sender, EventArgs e)
        {
            try
            {
                bet = double.Parse(metroTextBoxBet.Text);
                if (bet > money)
                    MessageBox.Show("You cannot bet more money than you have");
                else if (bet < 1)
                    MessageBox.Show("Bet cannot be less than 1");
                else
                {
                    UpdateMoney(bet * -1);
                    metroButtonConfirmBet.Enabled = false;
                    metroTextBoxBet.Enabled = false;
                    metroButtonHit.Enabled = true;
                    metroButtonStand.Enabled = true;
                    //Initial draw
                    Draw("player", 2);
                    Draw("dealer", 1);
                    if (playerScore >= 21)
                        CheckWin();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
