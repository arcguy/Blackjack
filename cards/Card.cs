using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    class Card
    {
        private string suit;
        private string value;
        private int num;

        public Card(string s, string v, int n)
        {
            suit = s;
            value = v;
            num = n;
        }

        public string GetSuit()
        {
            return this.suit;
        }

        public string GetValue()
        {
            return this.value;
        }

        public override string ToString()        
        {
            return value + " of " + suit;
        }

        public int GetBlackjackValue()
        {
            int temp = this.num;
            if (temp > 10)
                temp = 10;
            return temp;
        }

        public int GetBlackjackValue(int score)
        {
            int temp = 11;
            if (score > 10)
                temp = 1;
            return temp;
        }
    }
}
