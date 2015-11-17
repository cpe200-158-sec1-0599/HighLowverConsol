using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLow
{
    class Deck
    {
        //PROPERTY
        public List<Card> deck = new List<Card>();
        private int _cardRemain;
        public int CardRemain
        {
            get { return _cardRemain; }
            set { _cardRemain = value; }
        }
        //METHOD
        public void mainDeck()
        {
            for (int sTmp = 0; sTmp < 4; sTmp++)
            {
                for (int nTmp = 2; nTmp < 15; nTmp++)
                {
                    deck.Add(new Card(sTmp, nTmp));
                    CardRemain++;
                    //Console.WriteLine(deck.Last().ToString());
                }
            }

        }
        public void addCard(Card c)
        {
            deck.Add(c);
            CardRemain++;
        }
        public void removeCard()
        {
            deck.Remove(deck.Last());
            CardRemain--;
        }
        public Card rspDeal()
        {
            Card tmpC = deck.Last();
            //Console.WriteLine(""+CardRemain+"");
            //Console.WriteLine(deck.Last().ToString());
            removeCard();
            return tmpC;
        }
        public void Shuffle()
        {
            int n = CardRemain;
            Random rnd = new Random();
            while (n > 1)
            {
                int k = (rnd.Next(0, n) % n);
                n--;
                Card value = deck[k];
                deck[k] = deck[n];
                deck[n] = value;
            }
        }
    }
}
