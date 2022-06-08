using System;
using System.IO;
//MAIN BRANCH

namespace ERDiary
{
    class Program
    {
        static void Main(string[] args)
        {
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
                "\n3) Muokkaa aiheen tietoja" +
                "\n4) Näytä yhden aiheen kaikki tiedot" +
                "\ntai paina ENTER lopettaaksesi. ");
            string input = Console.ReadLine();
            Console.WriteLine();
            if (String.IsNullOrWhiteSpace(input))
            {
                return false;//lopettaa MainMenun (ja ohjelman) suorituksen
            }

            else if (input == "1")//Uuden aiheen syöttäminen (aiheen nimi)
            {
                Console.Write("Syötä aihe: ");
                string title = Console.ReadLine();
                Topic t = new Topic(title);
            }

            else if (input == "2")//Näytä kaikki aiheet
            { 
                Topic.PrintAllTopics(); 
            }
            
            else if (input == "3")//Tulostaa listan kaikista aiheista ja antaa käyttäjän muokata yhden aiheen tietoja
            {   
                Topic.PrintAllIdsAndTopics();
                Console.Write("Kirjoita sen aiheen numero, jonka tietoja haluat lisätä: ");
                int topicToEdit = Convert.ToInt32(Console.ReadLine()) - 1;//vähennetään 1 jotta saadaan suoraan listan topics indeksi
                Topic.ChoosePropertyToSet(topicToEdit);
            }

            else if (input == "4")//Tulostaa kaikki valittavan aiheen tiedot
            {
                Console.WriteLine("Kirjoita sen aiheen numero, jonka kaikki tiedot haluat nähdä." +
                    "\nAiheet:");
                Topic.PrintAllIdsAndTopics();
                int topicToPrint = Convert.ToInt32(Console.ReadLine()) - 1;//vähennetään 1 jotta saadaan suoraan listan topics indeksi
                Topic.PrintAllProperties(topicToPrint);
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
