using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    public class Card
    {
        private string suit;
        private string value;
        private int num;

        /// <summary>
        /// Creates a new card object
        /// </summary>
        /// <param name="s">The suit of the card</param>
        /// <param name="v">The raw value of the card such as ace, one, king, etc</param>
        /// <param name="n">The value used to calculate score</param>
        public Card(string s, string v, int n)
        {
            this.suit = s;
            this.value = v;
            if (n > 10)
                this.num = 10;
            else
                this.num = n;
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

        //public int GetBlackjackValue()
        //{
        //    int temp = this.num;
        //    if (temp > 10)
        //        temp = 10;
        //    return temp;
        //}

        public int GetBlackjackValue(int score)
        {
            if (this.num == 1)
                if (score > 10)
                    return 1;
                else
                    return 11;
            else 
                return this.num;
        }
    }
}
