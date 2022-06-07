using System;

namespace ERDiary
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        static bool MainMenu()
        {
            Console.Write("Kirjoita:" +
                "\n1) Syöttääksesi uusi aihe"+
                "\n2) Tulostaaksesi kaikki aiheet " +
                "\ntai paina ENTER lopettaaksesi. ");
            string input = Console.ReadLine();
                
            if (String.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            else if (input == "1")
            {
                Console.Write("Syötä aihe: ");
                string title = Console.ReadLine();
                Topic t = new Topic(title)
            }

            else if (input == "2")
            { 
                Topic.PrintAllTopics(); 
            }
                
            else
            {
                Console.Clear();
                Console.WriteLine("Kokeile uudestaan.");
            }
            return true;
            
        }


    }

}
