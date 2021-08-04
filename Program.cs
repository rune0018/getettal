using System;

namespace GetEtTal
{
    class Program
    {
        static void Main(string[] args)
        {
            Getettal.start();
            while(Gui.GetStringFromUser("\ntryk y for at genstarte") == "y")
            {
                Getettal.start();
            }
            //Rul en tærning og få et tilfældigt tal
            //int guessThisNumber = Dice.Roll();
            //Console.Write("Gæt et tal: ");

            ////Gør plads
            //int inputnumber = 0;
            //int.TryParse(Console.ReadLine(), out inputnumber);

            ////Feedback til brugeren
            //Console.Write("Du gættede " + inputnumber);
            //Console.WriteLine(Getettal.Get(inputnumber));
        }

        class Dice
        {
            public static int Sides = 6;
            public static int Roll()
            {
                Random random = new Random();
                return random.Next(Sides) + 1;
            }
        }
        class Getettal
        {
            public static int guessThisNumber;
            public static int inputnumber;
            public static void start()
            {
                Gui.clear();
                string navn = Gui.GetStringFromUser("hvad hedder du: ");
                Gui.Write("hej " + navn);
                int.TryParse(Gui.GetStringFromUser(" hvor mange sider vil du have på din tærning: "), out Dice.Sides);
                guessThisNumber = Dice.Roll();

                while (Guess(inputnumber) != " og det var rigtigt")
                {
                    int.TryParse(Gui.GetStringFromUser("Gæt et tal: "),out inputnumber);
                    Gui.Write(" "+Guess(inputnumber)+" ");
                }
            }
            public static string Guess(int inputnumber)
            {
                if (inputnumber > guessThisNumber)
                {
                    return " og det er for højt";
                }
                else if (inputnumber < guessThisNumber)
                {
                    return " og det er for lavt";
                }
                else
                {
                    return " og det var rigtigt";
                }
            }
        }
        class Gui
        {
            public static string GetStringFromUser(string guide)
            {
                Console.Write(guide);
                string input = Console.ReadLine();
                return input;
            }
            public static void Write(string input)
            {
                Console.Write(input);
            }
            public static void clear()
            {
                Console.Clear();
            }
        }
    }
}
