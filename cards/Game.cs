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
        Player p1, dealer;
        MetroLabel playerScore, playerMoney, dealerScore;
        MetroListView playerDisplay, dealerDisplay;
        
        public Game(Player player1, Player dealer1)
        {
            p1 = player1;
            dealer = dealer1;
        }
    }
}
