using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLow
{
    class Pile : Deck
    {
        public Card topCard()
        {

            //Console.WriteLine("Player0 TopCard: " + deck.Last() + "");
            return deck.Last();
        }
       
    }
}
