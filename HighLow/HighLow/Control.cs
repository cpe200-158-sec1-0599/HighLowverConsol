using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLow
{
    class Control
    {
        public Player[] gameplayer = new Player[2];
        public Deck deck = new Deck();
        //public
        public Control()
        {
            setPName();
            Deal();
            
        }
        public void setPName()
        {
            Console.WriteLine("Player 0's Name : ");
            string n0 = Console.ReadLine();
            gameplayer[0] = new Player(n0);
            Console.WriteLine("Player 1's Name : ");
            string n1 = Console.ReadLine();
            gameplayer[1] = new Player(n1);
        }
        public void Deal()
        {
            deck.mainDeck();
            //deck.Shuffle();
            /*while(deck.CardRemain > 50)
            {
                gameplayer[0].playerPile.addCard(deck.rspDeal());
                //Console.WriteLine("Player0 : "+gameplayer[0].playerPile.topCard().ToString() +"");
                gameplayer[1].playerPile.addCard(deck.rspDeal());
                //Console.WriteLine("Player1 : " + gameplayer[1].playerPile.topCard().ToString() + "");
            }*/
            
            gameplayer[0].playerPile.addCard(new Card(1,5));
            gameplayer[0].playerPile.addCard(new Card(0, 4));
            //Console.WriteLine("Player0 : "+gameplayer[0].playerPile.topCard().ToString() +"");
            gameplayer[1].playerPile.addCard(new Card(3, 2));
            gameplayer[1].playerPile.addCard(new Card(1,4));
            //Console.WriteLine("Player1 : " + gameplayer[1].playerPile.topCard().ToString() + "");
        }
        public void inGame()
        {
            while((gameplayer[0].playerPile.CardRemain > 0)|| (gameplayer[1].playerPile.CardRemain > 0))
            {
                //Console.WriteLine("Player0 Remain: " + gameplayer[0].playerPile.CardRemain + "");
                //Console.WriteLine("Player1 Remain: " + gameplayer[1].playerPile.CardRemain + "");
                Console.WriteLine("Player0 : " + gameplayer[0].playerPile.topCard().ToString() + "");
                Console.WriteLine("Player1 : " + gameplayer[1].playerPile.topCard().ToString() + "");
                inTurn();
                Console.WriteLine("Player0 WinCard: " + gameplayer[0].pwinPile.CardRemain + "");
                Console.WriteLine("Player1 WinCard: " + gameplayer[1].pwinPile.CardRemain + "");
            }

        }
        public void inTurn()
        {
            //gameplayer[0].playerPile.Shuffle();
            //gameplayer[1].playerPile.Shuffle();
            //Console.WriteLine("Player0 : " + gameplayer[0].playerPile.topCard() + "");
            //Console.WriteLine("Player1 : " + gameplayer[1].playerPile.topCard() + "");
            //Console.WriteLine("Player0 TopCard: " + gameplayer[0].playerPile.topCard() + "");
            switch (Compare(gameplayer[0].playerPile.topCard().Num, gameplayer[1].playerPile.topCard().Num))
            {
                case 0:
                    Console.WriteLine("Player0 Win!!");
                    endTurn(0);
                    break;
                case 1:
                    Console.WriteLine("Player1 Win!!");
                    endTurn(1);
                    break;
                case 2:
                    //Console.WriteLine("Player0 TopCard: " + gameplayer[0].playerPile.topCard() + "");
                    Console.WriteLine("Tie!!");
                    tie(gameplayer[0].playerPile.topCard().Num);
                    break;
            }
            
        }
        public int Compare(int p0fcup,int p1fcup)
        {
            if (p0fcup - p1fcup > 0)
            {
                gameplayer[0].faceDown.addCard(gameplayer[0].faceUp());
                gameplayer[1].faceDown.addCard(gameplayer[1].faceUp());
                return 0;
            }
            else if (p0fcup - p1fcup < 0)
            {
                gameplayer[0].faceDown.addCard(gameplayer[0].faceUp());
                gameplayer[1].faceDown.addCard(gameplayer[1].faceUp());
                return 1;
            }
            else
            {
                //gameplayer[0].faceDown.addCard(gameplayer[0].faceUp());
                //gameplayer[1].faceDown.addCard(gameplayer[1].faceUp());
                return 2;
            }
        }
        public void tie(int n)
        {
            Console.WriteLine("Player0 Remain: " + gameplayer[0].playerPile.CardRemain + "");
            Console.WriteLine("Player1 Remain: " + gameplayer[1].playerPile.CardRemain + "");
            if (gameplayer[0].playerPile.deck.Count > n-1)
            {
                Console.WriteLine("CheckPoint0");
                for (int i = 0; i < n; i++)
                {
                    //if(gameplayer[0].playerPile.CardRemain > 2)
                    gameplayer[0].faceDown.addCard(gameplayer[0].faceUp());
                    //if (gameplayer[1].playerPile.CardRemain > 2)
                    gameplayer[1].faceDown.addCard(gameplayer[1].faceUp());
                }
                switch (Compare(gameplayer[0].playerPile.topCard().Num, gameplayer[1].playerPile.topCard().Num))
                {
                    case 0:
                        gameplayer[0].faceDown.addCard(gameplayer[0].faceUp());
                        gameplayer[0].faceDown.addCard(gameplayer[1].faceUp());
                        Console.WriteLine("Player0 Tie Win!!");
                        endTurn(0);
                        break;
                    case 1:
                        gameplayer[0].faceDown.addCard(gameplayer[0].faceUp());
                        gameplayer[0].faceDown.addCard(gameplayer[1].faceUp());
                        Console.WriteLine("Player1 Tie Win!!");
                        endTurn(1);
                        break;
                    case 2:
                        while (gameplayer[0].faceDown.CardRemain > 1)
                        {
                            gameplayer[0].playerPile.addCard(gameplayer[1].faceDown.topCard());
                            gameplayer[0].faceDown.removeCard();
                        }
                        while (gameplayer[1].faceDown.CardRemain > 1)
                        {
                            gameplayer[1].playerPile.addCard(gameplayer[1].faceDown.topCard());
                            gameplayer[1].faceDown.removeCard();
                        }
                        Console.WriteLine("Tie Tie!!");
                        break;
                }
            }
            
            else
            {
                switch (Compare(gameplayer[0].playerPile.topCard().Num, gameplayer[1].playerPile.topCard().Num))
                {
                    case 0:
                        gameplayer[0].faceDown.addCard(gameplayer[0].faceUp());
                        gameplayer[0].faceDown.addCard(gameplayer[1].faceUp());
                        Console.WriteLine("Player0 Tie Win!!");
                        endTurn(0);
                        break;
                    case 1:
                        gameplayer[0].faceDown.addCard(gameplayer[0].faceUp());
                        gameplayer[0].faceDown.addCard(gameplayer[1].faceUp());
                        Console.WriteLine("Player1 Tie Win!!");
                        endTurn(1);
                        break;
                    case 2:
                        Console.WriteLine("Tie Tie!!");
                        gameplayer[0].faceDown.addCard(gameplayer[0].faceUp());
                        gameplayer[0].faceDown.addCard(gameplayer[1].faceUp());
                        
                        break;
                }

            }
            Console.WriteLine("CheckPoint2");
            Console.ReadKey();

        }
        public void endTurn(int player)
        {
            //add facedownCard to playerwinpile
            while(gameplayer[0].faceDown.CardRemain > 0)
            {
                gameplayer[player].pwinPile.addCard(gameplayer[0].faceDown.topCard());
                gameplayer[0].faceDown.removeCard();
            }
            while (gameplayer[1].faceDown.CardRemain > 0)
            {
                gameplayer[player].pwinPile.addCard(gameplayer[1].faceDown.topCard());
                gameplayer[1].faceDown.removeCard();
            }
        }
        public void endgame()
        {
            
            if (gameplayer[0].pwinPile.deck.Count > gameplayer[1].pwinPile.deck.Count)
            {
                Console.WriteLine("Player0 WinGame!!");

            }
            else if (gameplayer[0].pwinPile.deck.Count < gameplayer[1].pwinPile.deck.Count)
            {
                Console.WriteLine("Player1 WinGame!!");
            }
            else
            {
                Console.WriteLine("Tie Game!!");
            }
        }
    }
}
