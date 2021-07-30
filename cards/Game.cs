using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework;
using MetroFramework.Controls;

namespace cards
{
    class Game
    {
        //Player p1, dealer;
        MetroLabel playerScore, playerMoney, dealerScore, displayLabel ,roundLabel;
        MetroListView playerDisplay, dealerDisplay;
        MetroButton hitButton, standButton, nextButton, betButton;
        MetroTextBox betTextbox;

        List<Card> Deck = new List<Card>(); //the deck that gets drawn from
        List<Card> mainDeck = new List<Card>(); //the initial deck that is used to reset the deck
        Random r = new Random();
        int round;

        public Game(Player player1, Player dealer1, MetroLabel d, MetroButton hit, MetroButton stand, MetroButton next, MetroButton bet, MetroTextBox betInput, MetroLabel pScore, MetroLabel dScore, MetroListView pDisplay, MetroListView dDisplay, MetroLabel rLabel, MetroLabel mLabel)
        {
            //p1 = player1;
            //dealer = dealer1;
            displayLabel = d;
            hitButton = hit;
            standButton = stand;
            nextButton = next;
            betButton = bet;
            betTextbox = betInput;
            playerScore = pScore;
            dealerScore = dScore;
            playerDisplay = pDisplay;
            dealerDisplay = dDisplay;
            roundLabel = rLabel;
            playerMoney = mLabel;

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

            round = 0;            
        }

        public int GetRound()
        {
            return this.round;
        }

        /// <summary>
        /// Enables and disables specific buttons for the start of the round. Resets the deck, scores and displays
        /// </summary>
        public void ResetGameState(Player p1, Player dealer)
        {
            if (round <= 10)
            {
                hitButton.Enabled = false;
                standButton.Enabled = false;
                nextButton.Enabled = false;
                betButton.Enabled = true;
                betTextbox.Enabled = true;

                displayLabel.Text = "Confirm bet to Continue";

                p1.UpdateMoneyDisplay(playerMoney);
                p1.Reset();
                p1.ResetDisplay(playerScore, playerDisplay);
                dealer.ResetDisplay(dealerScore, dealerDisplay);
                dealer.Reset();

                round++;

                Deck.Clear();
                Deck.AddRange(mainDeck);
                roundLabel.Text = "Round: " + round;

                betTextbox.Clear();
                betTextbox.Focus();

            }
            else 
            {
                Scoreboard sb = new Scoreboard(p1.GetMoney());
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
                Card c = Deck[r.Next(Deck.Count)];
                user.AddToDrawnCards(c);
                user.UpdateScore(c.GetBlackjackValue(user.GetScore()));
                Deck.Remove(c);
                //Update score display somewhere else
            }
        }

        /// <summary>
        /// Checks if the player has blackjack, a win, a draw or a loss.
        /// </summary>
        public void CheckWin(Player user, Player dealer)
        {
            string winstate = "Bust";
            if (user.GetScore() == 21)
            {
                if (dealer.GetScore() > 21 || dealer.GetScore() < 21)
                    winstate = "Blackjack";
                else if (dealer.GetScore() == 21)
                    winstate = "Blackjack";
            }
            else if (user.GetScore() < 21)
            {
                if (dealer.GetScore() <= 21)
                    if (user.GetScore() > dealer.GetScore())
                        winstate = "Win";
                    else if (user.GetScore() == dealer.GetScore())
                        winstate = "Draw";
                    else
                        winstate = "Bust";
                else
                    winstate = "Win";
            }
            //else
            //    winstate = "Bust";

            if (winstate == "Blackjack")
            {
                user.UpdateMoney(user.GetBet() * 2.5);
                displayLabel.Text = winstate + ". 2.5x bet won";
            }
            else if (winstate == "Win")
            {
                user.UpdateMoney(user.GetBet() * 2);
                displayLabel.Text = winstate + ". 2x bet won";
            }
            else if (winstate == "Draw")
            {
                user.UpdateMoney(user.GetBet());
                displayLabel.Text = winstate + ". Bet refunded";
            }
            else
                displayLabel.Text = winstate + ". Bet lost";

            hitButton.Enabled = false;
            standButton.Enabled = false;
            nextButton.Enabled = true;            
        }

        /// <summary>
        /// Draws a card for the player. If they reach a score of 21 or greater, the CheckWin method is invoked and the DrawDealer method is also invoked
        /// </summary>
        public void Hit(Player user, Player dealer)
        {
            Draw(user, 1);
            user.UpdateScoreDisplay(playerScore, playerDisplay);
            if (user.GetScore() >= 21)
            {
                DrawDealer(dealer);
                CheckWin(user, dealer);
            }            
            
        }

        /// <summary>
        /// draws cards for the dealer until they either bust or reach a score of at least 17. Also ensures dealer draws a minimum of one card to simulate the face down card drawn for the dealer in irl blackjack
        /// </summary>
        public void DrawDealer(Player dealer)
        {
            Draw(dealer, 1);
            while (dealer.GetScore() < 17)
            {
                Draw(dealer, 1);
            }
            dealer.UpdateScoreDisplay(dealerScore, dealerDisplay);
        }

        public void Stand(Player user, Player dealer)
        {
            DrawDealer(dealer);
            CheckWin(user, dealer);
        }

        public void ConfirmBet(Player user, Player dealer, System.Windows.Forms.IWin32Window window)
        {
            if (user.GetBet() > user.GetMoney())
                MetroMessageBox.Show(window, "You can't be more money than you have");
            else if (user.GetBet() < 1)
                MetroMessageBox.Show(window, "Bet can't be less than $1");
            else
            {
                user.UpdateMoney(-user.GetBet());
                user.UpdateMoneyDisplay(playerMoney);
                
                betButton.Enabled = false;
                betTextbox.Enabled = false;
                hitButton.Enabled = true;
                standButton.Enabled = true;

                //initial draws for player and dealer
                Draw(user, 2);
                user.UpdateScoreDisplay(playerScore, playerDisplay);
                Draw(dealer, 1);
                dealer.UpdateScoreDisplay(dealerScore, dealerDisplay);

                if (user.GetScore() >= 21)
                    CheckWin(user, dealer);
            }
        }
    }
}
