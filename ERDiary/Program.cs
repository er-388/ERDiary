using System;
using System.IO;

namespace ERDiary
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToClear = @"C:\Users\Erkki\source\repos\ERDiary\data.txt";//tyhjentää tiedoston ajon aluksi
            File.Create(pathToClear).Close();//tyhjentää tiedoston ajon 

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();//ShowMenu() palauttaa false, jos käyttäjä haluaa lopettaa.
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
                return false;//lopettaa MainMenun (ja ohjelman) suorituksen
            }

            else if (input == "1")//lisää aiheen tiedostoon ja listaan topics
            {
                Console.Write("Syötä aihe: ");
                string title = Console.ReadLine();
                Topic t = new Topic(title);
            }

            else if (input == "2")
            {
                Console.WriteLine("Kaikki syötetyt aiheet:");
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
