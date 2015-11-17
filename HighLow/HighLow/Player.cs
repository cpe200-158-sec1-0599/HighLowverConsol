using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLow
{
    class Player
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public Pile playerPile = new Pile();
        public Pile pwinPile = new Pile();
        public Pile faceDown = new Pile();
        public Player(string name)
        {
           Name = name;
        }
        public Card faceUp()
        {
            Card c = playerPile.topCard();
            playerPile.removeCard();
            return c;
        }
    }
}
