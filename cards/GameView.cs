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

namespace cards
{
    public partial class FormBlackjack : MetroForm
    {
        List<Card> Deck = new List<Card>(); //the deck that gets drawn from
        List<Card> mainDeck = new List<Card>(); //the initial deck that is used to reset the deck
        Random r = new Random();
        int round = 0;

        Player player1;
        Player dealer;

        public FormBlackjack()
        {
            InitializeComponent();
            player1 = new Player("Player");//("Player", metroLabelPlayerScore, metroListViewPlayer, metroLabelMoney);
            dealer = new Player("Dealer");// ("Dealer", metroLabelDealerScore, metroListViewDealer);

            for (int i = 1; i < 14; i++)
            {
                string value;
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

                metroLabelDisplay.Text = "Confirm bet to continue";

                player1.Reset(metroLabelPlayerScore, metroListViewPlayer);
                dealer.Reset(metroLabelDealerScore, metroListViewDealer);
                round++;

                //create the deck
                Deck.Clear();
                Deck.AddRange(mainDeck);
                metroLabelRound.Text = "Round " + round;

                metroTextBoxBet.Clear();
                metroTextBoxBet.Focus();
                player1.UpdateMoneyDisplay(metroLabelMoney);
            }
            else
            {
                Scoreboard sb = new Scoreboard(player1.GetMoney());
                this.Close();
                sb.Show();
            }
        }

        /// <summary>
        /// Draws a specified number of cards for the specified player
        /// </summary>
        /// <param name="user">Who is drawing cards</param>
        /// <param name="draws">How many cards to draw</param>
        public void Draw(Player user, int draws)
        {
            for (int i = 0; i < draws; i++)
            {
                Card draw = Deck[r.Next(Deck.Count)];
                user.AddToDrawnCards(draw);
                user.UpdateScore(draw.GetBlackjackValue(user.GetScore()));
                if(user.GetName() != "Dealer")
                {
                    player1.UpdateScoreDisplay(metroLabelPlayerScore, metroListViewPlayer);
                }
                else
                {
                    dealer.UpdateScoreDisplay(metroLabelDealerScore, metroListViewDealer);
                }
                Deck.Remove(draw);
            }          
        }

        /// <summary>
        /// Checks if the player has blackjack and then either wins, loses or draws with the dealer. Money is updated based on win state.
        /// </summary>
        public void CheckWin()
        {
            string winstate;
            if (player1.GetScore() == 21)
            {
                if (dealer.GetScore() > 21)
                {
                    winstate = "Blackjack";
                }
                else if (dealer.GetScore() == 21)
                    winstate = "Draw";
                else
                    winstate = "Blackjack";
            }
            else if (player1.GetScore() < 21)
            {
                if (dealer.GetScore() <= 21)
                {
                    if (player1.GetScore() > dealer.GetScore())
                    {
                        winstate = "Win";
                    }
                    else if (player1.GetScore() == dealer.GetScore())
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
                player1.UpdateMoney(player1.GetBet());
                metroLabelDisplay.Text = winstate + ". Bet refunded";
            }
            else if (winstate == "Win")
            {
                player1.UpdateMoney(player1.GetBet() * 2);
                metroLabelDisplay.Text = winstate + ". 2x bet won";
            }
            else if (winstate == "Blackjack")
            {
                player1.UpdateMoney(player1.GetBet() * 2.5);
                metroLabelDisplay.Text = winstate + ". 2.5x bet won";
            } 
            else
                metroLabelDisplay.Text = winstate + ". Bet lost";


            player1.UpdateMoneyDisplay(metroLabelMoney);
            metroButtonHit.Enabled = false;
            metroButtonStand.Enabled = false;
            metroButtonRestart.Enabled = true;

            if (player1.GetMoney() < 1)
            {
                Scoreboard sb = new Scoreboard(player1.GetMoney());
                this.Close();
                sb.Show();
            }
        }

        /// <summary>
        /// Draws a card for the player. If they reach a score of 21 or greater the CheckWin method is invoked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButtonHit_Click(object sender, EventArgs e)
        {
            Draw(player1, 1);
            if (player1.GetScore() >= 21)
            {
                metroLabelDisplay.Text = "Bust. Bet lost";
                while (dealer.GetScore() < 17)
                {
                    Draw(dealer, 1);
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
            Draw(dealer, 1);

            while (dealer.GetScore() < 17)
            {
                Draw(dealer, 1);                
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
                player1.SetBet(double.Parse(metroTextBoxBet.Text));
                if (player1.GetBet() > player1.GetMoney())
                    MessageBox.Show("You cannot bet more money than you have");
                else if (player1.GetBet() < 1)
                    MessageBox.Show("Bet cannot be less than 1");
                else
                {
                    player1.UpdateMoney(-player1.GetBet());
                    player1.UpdateMoneyDisplay(metroLabelMoney);

                    metroButtonConfirmBet.Enabled = false;
                    metroTextBoxBet.Enabled = false;
                    metroButtonHit.Enabled = true;
                    metroButtonStand.Enabled = true;
                    //Initial draw
                    Draw(player1, 2);
                    Draw(dealer, 1);
                    if (player1.GetScore() >= 21)
                        CheckWin();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                MetroMessageBox.Show(this, "Error: Bet must be a number greater than 0");
            }
        }
    }
}