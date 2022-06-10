using System;
using System.IO;

namespace ERDiary
{
    class Program
    {
        static void Main(string[] args)
        {
            //tyhjentää tiedoston ajon aluksi (testailua varten)
            //string pathToClear = @"C:\Users\Erkki\source\repos\ERDiary\data.csv";
            //File.Create(pathToClear).Close();

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine(@"  _   _   _ ___      ___  __  _ o  o ___    o  o    ___  _           
 / \ |_) |_) |  |\/|  |  (_  |_) /\   | \  / /\  |/  |  |_)   |  /\  
 \_/ |   |  _|_ |  | _|_ __) |  /--\ _|_ \/ /--\ |\ _|_ | \ \_| /--\");

            Console.WriteLine();
            Console.ResetColor();

            //ShowMenu() palauttaa false, jos käyttäjä haluaa lopettaa eli painaa valikossa ENTER.
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        static bool MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(@"
    ~~~~~~~~~~~~~
       VALIKKO
    ~~~~~~~~~~~~~");
            Console.ResetColor();
            Console.Write("\n1) Syöttääksesi uusi aihe" +
                "\n2) Tulostaaksesi kaikki aiheet " +
                "\n3) Muokkaa aihetta tai sen kuvausta" +
                "\n4) Näytä yhden aiheen kaikki tiedot" +
                "\ntai paina ENTER lopettaaksesi.\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Valitse toiminto:  ");
            Console.ResetColor();
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

            else if (input == 3)
            {
                //ohjelma kaatuu, jos CSV-tiedostoa ei ole ja käyttäjä jatkaa tiedon muokkaamiseen
                //Tulostaa listan kaikista aiheista. Kysytään käyttäjältä mitä aihetta haluaa muokata.
                Topic.PrintAllTopics();
                Console.WriteLine("Minkä aiheen tietoja haluat muokata?\n");
                Topic.AskForId("tunniste");
                //jos syöte on numero, siirrytään metodiin, josta valitaan mitä valitun aiheen ominaisuutta halutaan muokata.
                if (Int32.TryParse(Console.ReadLine(), out int idOfTopicToEdit) == true)
                {
                    Topic.ChoosePropertyToSet(idOfTopicToEdit);
                }
                else
                {
                    Console.WriteLine("Syötä numero.");
                }
            }

            else if (input == 4)//Tulostaa kaikki valittavan aiheen tiedot
            {
                //ohjelma kaatuu, jos CSV-tiedostoa ei ole   
                Topic.PrintAllTopics();
                Console.WriteLine("Minkä aiheen kaikki tiedot haluat nähdä?");
                Topic.AskForId("tunniste");
                if (Int32.TryParse(Console.ReadLine(), out int topicToPrint) == true)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nAiheen {0} kaikki tiedot", topicToPrint);
                    Console.ResetColor();
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
