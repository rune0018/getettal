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
        }
        //tærningen der bliver brugt til at gøre tallet random
        class Dice
        {
            //holder på default siderne på tærningen
            public static int Sides = 6;

            //kaster tærningen og retunere tallet
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
            public static void start() //staten af kode
            {
                Gui.clear();

                //bruger gui klassen til at hente navnet fra brugeren
                string navn = Gui.GetStringFromUser("hvad hedder du"); 
                Gui.Write("hej " + navn);

                //ser om det er muligt at lave svaret om til et tal
                int.TryParse(Gui.GetStringFromUser(" hvor mange sider vil du have på din tærning: "), out Dice.Sides);
                guessThisNumber = Dice.Roll();

                //kører indtil svaret matcher computerens tal
                while (Guess(inputnumber) != " og det var rigtigt")
                {
                    int.TryParse(Gui.GetStringFromUser("Gæt et tal"),out inputnumber);
                    Gui.Write(" "+Guess(inputnumber)+" ");
                }
            }
            // gæt håndtering for at få feedback på hvad brugeren skrev
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
            //samle input fra brugeren op og sender det tilbagge fra hvor det kom fra og skriver i consollen med en guide givet ved kald
            public static string GetStringFromUser(string guide)
            {
                Console.Write(guide + ": ");
                string input = Console.ReadLine();
                return input;
            }
            //skriver i consollen
            public static void Write(string input)
            {
                Console.Write(input);
            }
            //clear consollen
            public static void clear()
            {
                Console.Clear();
            }
        }
    }
}
