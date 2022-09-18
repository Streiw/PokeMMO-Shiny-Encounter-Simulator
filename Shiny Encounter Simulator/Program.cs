//PokeMMO Shiny Encounter Simulator v1.0
//@Waam#3424
//2022

namespace Shiny_Encounter_Simulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int encounternumber;
            int oddsceiling;
            Console.WriteLine("How many encounters do you want to simulate?");
           
            var setencounters = Console.ReadLine();
            encounternumber = Int32.Parse(setencounters);
          

            Console.WriteLine("Do you want to calculate with Donor/Shiny Charm status?\nInput 'd' for donor (1:27000), 'a' for shiny charm + donor (1:24300), 'n' for full odds (1:30000) or 'h' for Gameboy odds (1:8192)");
            
            var donorstatus = Console.ReadLine();

            if (donorstatus == "d")
            {
                oddsceiling = 27000;

            }
            else if (donorstatus == "a")
            {
                oddsceiling = 24300;
            }
            else if (donorstatus == "h")
            {
                oddsceiling = 8192;
            }

            else
            {
                oddsceiling = 30000;
            }

            makeRandom(oddsceiling);


            void makeRandom(int oddsceiling)
            {
                int foundshiny = 0;
                int foundsecret = 0;
                Console.WriteLine("\n\nSimulating " + encounternumber + " Pokemon encounters with shiny odds of 1:" + oddsceiling + "\n");
                for (int i = 0; i < encounternumber; i++)
                {
                    Random random = new Random();
                    int number = random.Next(1, oddsceiling);

                    if (number == 1)
                    {
                        int secretshiny = random.Next(1, 16);

                        if (secretshiny == 1)
                        {
                            Console.WriteLine("Secret  shiny found on encounter number: " + i);
                            foundshiny++;
                            foundsecret++;

                        }
                        else
                        {
                            Console.WriteLine("Regular shiny found on encounter number: " + i);
                            foundshiny++;
                        }
                    }
                }
                var shinyaverage = (decimal)(encounternumber / foundshiny);
                var encountertimerseconds = (decimal)(encounternumber * 10);
                var encountertimerminutes = (decimal)(encountertimerseconds / 60);
                var encountertimerhours = (decimal)(encountertimerminutes / 60);
                var houraverage = (decimal)(encountertimerhours / foundshiny);
                Console.WriteLine("\nShinies found: " + foundshiny);
                Console.WriteLine("Secret shinies found: " + foundsecret);
                Console.WriteLine("Encounter average per shiny: " + shinyaverage);
                Console.WriteLine("Simulated play time: " + encountertimerhours + " hours (10 seconds per encounter)");
                Console.WriteLine("Hours per shiny: " + houraverage);

                Console.WriteLine("\nPress enter to run again.\n");

                Console.ReadLine();

                makeRandom(oddsceiling);

            }

        }
    }
}