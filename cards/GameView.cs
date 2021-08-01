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

        Game controller;

        public FormBlackjack()
        {
            InitializeComponent();

            player1 = new Player("Player");
            dealer = new Player("Dealer");

            controller = new Game(metroLabelDisplay, metroButtonHit, metroButtonStand, metroButtonRestart, metroButtonConfirmBet, metroTextBoxBet, metroLabelPlayerScore, metroLabelDealerScore,
                metroListViewPlayer, metroListViewDealer, metroLabelRound, metroLabelMoney);

            controller.ResetGameState(player1, dealer);
        }

        /// <summary>
        /// Draws a card for the player. If they reach a score of 21 or greater the CheckWin method is invoked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButtonHit_Click(object sender, EventArgs e)
        {
            controller.Hit(player1, dealer);
        }

        /// <summary>
        /// Causes the dealer to begin drawing cards until they have a score of 17 or greater. They must draw at least one card.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButtonStand_Click(object sender, EventArgs e)
        {
            controller.Stand(player1, dealer);
        }

        /// <summary>
        /// begins the next round
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButtonRestart_Click(object sender, EventArgs e)
        {
            //Initialize();
            controller.ResetGameState(player1, dealer);
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
                controller.ConfirmBet(player1, dealer, this);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                MetroMessageBox.Show(this, "Error: Bet must be a number greater than 0");
            }
        }
    }
}