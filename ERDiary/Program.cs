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
                "\n1) Syöttääksesi uusi aihe" +
                "\n2) Tulostaaksesi kaikki aiheet " +
                "\n3) Muokkaa aiheen tietoja (KESKEN!)" +
                "\n4) Näytä yhden aiheen kaikki tiedot (KESKEN!)" +
                "\ntai paina ENTER lopettaaksesi. ");
            string stringInput = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(stringInput))
            {
                return false;//lopettaa MainMenun (ja ohjelman) suorituksen
            }

            else if (Int32.TryParse(stringInput, out int input) == false)//tarkistaa onko syöte kokonaisluku
            {
                Console.WriteLine("Syötä numero.");
            }

            else if (input == 1)//lisää aiheen tiedostoon ja listaan topics
            {
                Console.Write("Syötä aihe: ");
                string title = Console.ReadLine();
                Topic t = new Topic(title);
            }

            else if (input == 2)
            {
                Console.WriteLine("Kaikki syötetyt aiheet:");
                Topic.PrintAllTopics();
            }

            else if (input == 3)//Tulostaa listan kaikista aiheista; käyttäjä valitsee yhden aiheen jonka tietoja muokkaa
            {
                Topic.PrintAllIdsAndTopics();
                Console.Write("Kirjoita sen aiheen numero, jonka tietoja haluat lisätä: ");
                if (Int32.TryParse(Console.ReadLine(), out int topicToEdit) == true)
                {
                    topicToEdit--; //vähennetään 1 jotta saadaan suoraan listan topics indeksi
                    Topic.ChoosePropertyToSet(topicToEdit);
                }
                else
                {
                    Console.WriteLine("Syötä numero.");
                
            }

            else if (input == 4)//Tulostaa kaikki valittavan aiheen tiedot
            {
                Console.WriteLine("Kirjoita sen aiheen numero, jonka kaikki tiedot haluat nähdä." +
                    "\nAiheet:");
                Topic.PrintAllIdsAndTopics();
                if (Int32.TryParse(Console.ReadLine(), out int topicToPrint) == true) {
                    topicToPrint--; //vähennetään 1 jotta saadaan suoraan listan topics indeksi
                    Topic.PrintAllProperties(topicToPrint);
                }
                else
                {
                    Console.WriteLine("Syötä numero.");
                }
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Kokeile uudestaan.");
            }
            return true;//jos syöte muuta kuin ENTER, MainMenu() toistoa jatketaan.
            
        }


    }

}
