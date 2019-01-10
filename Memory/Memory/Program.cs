using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    class Program
    {
        static void Main(string[] args)
        {

            MemoryGame mGame = new MemoryGame(4,4);
            mGame.processInput();
            

        }
    }

    class MemoryCard
    {

        public bool revealed = false;
        public int mNumber;

        public MemoryCard(int mnumber)
        {
            mNumber = mnumber;
        }

    }


    class MemoryGame
    {
        private MemoryCard[,] mBoard;
        private int Width,Height;
        private Random rnd = new Random();


        public MemoryGame(int width,int height)
        {
            Width = width;
            Height = height;

            int cardCount = width * height;
            List<int> cardNumbers = new List<int>();

            for (int i = 0; i < cardCount; i++)
                cardNumbers.Add(i / 2);
            

            mBoard = new MemoryCard[height, width];

            for(int i=0;i<height;i++)
            {
                for(int j=0;j<Width;j++)
                {
                    int listItemIndex = rnd.Next()%cardNumbers.Count;

                    mBoard[i, j] = new MemoryCard(cardNumbers[listItemIndex]);

                    cardNumbers.Remove(cardNumbers[listItemIndex]);
                }
            }



        }

        private void displayBoard()
        {
            Console.Write("    ");
            for (int i = 0; i < Width; i++)
            {
                Console.Write("{0}  ", i);
            }
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < Height; i++)
            {
                Console.Write("{0}  ", i);
                for (int j = 0; j < Width; j++)
                {
                    if(mBoard[i, j].revealed)
                    Console.Write(" {0} ", mBoard[i, j].mNumber);
                    else
                    Console.Write(" # ");

                }
                Console.WriteLine();
            }
            
        }

        public void processInput()
        {
            
            int totalAmountOfPairs = Width * Height / 2;
            int currentAmountOfPairs = 0;
            while (currentAmountOfPairs!=totalAmountOfPairs)
            {

                MemoryCard card1, card2;

                Console.Clear();
                displayBoard();
                Console.WriteLine("To reveal card provide x and y (ex. 01 refers to card at x=0 y=1)");
                Console.Write("First Card: ");

                string input = Console.ReadLine();

                int xToReveal = Int32.Parse(input[0].ToString());// String inception xd
                int yToReveal = Int32.Parse(input[1].ToString());

                if (mBoard[yToReveal, xToReveal].revealed == true) continue;

                card1 = mBoard[yToReveal, xToReveal];
                card1.revealed = true;

                Console.Clear();
                displayBoard();
                Console.WriteLine("To reveal card provide x and y (ex. 01 refers to card at x=0 y=1)");
                Console.Write("Second Card: ");

                input = Console.ReadLine();

                xToReveal = Int32.Parse(input[0].ToString());// String inception xd
                yToReveal = Int32.Parse(input[1].ToString());

                if (mBoard[yToReveal, xToReveal].revealed == true) { card1.revealed = false; continue; }
            

                card2 = mBoard[yToReveal, xToReveal];
                card2.revealed = true;

                Console.Clear();
                displayBoard();

                if (card1.mNumber==card2.mNumber)
                {
                    Console.WriteLine("You have guessed correctly");
                    currentAmountOfPairs += 1;
                }
                else
                {
                    card1.revealed = false;
                    card2.revealed = false;
                    Console.WriteLine("No match");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

            }

            Console.WriteLine("Gratz!! You have finished the game");
            Console.ReadKey();
        }


    }




}
