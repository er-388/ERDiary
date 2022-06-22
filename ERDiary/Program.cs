using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ERDiary.Models;

namespace ERDiary
{
    class Program
    {
        static void Main(string[] args)
        {
            

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
                "\n3) Aiheen tietojen muokkaaminen tai aiheen poisto" +
                "\n4) Näytä yhden aiheen kaikki tiedot (EI TOIMI)" +
                "\n5) Etsi aihe" +
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

            //Kysyy käyttäjältä aihetta ja lisää sen tietokantaan
            else if (input == 1)
            {
                Console.Write("Syötä aihe: ");
                string title = Console.ReadLine();

                ERDiary.Models.Topic t = new ERDiary.Models.Topic(title);
            }

            //Tulostaa kaikki aiheet
            else if (input == 2)
            {
                Console.Clear();
                Console.WriteLine("Kaikki syötetyt aiheet:\n");
                Topic.PrintAllTopics();
            }
            

            //Käyttäjä voi muokata valitsemansa aiheen tietoja
            else if (input == 3)
            {
                Console.Clear();
                //PrintAllTopics() palauttaa true jos yksikin aihe on luotu.
                if (Topic.PrintAllTopics() == true)
                {
                    Console.WriteLine("Minkä aiheen tietoja haluat muokata?\n");
                    Console.Write("Kirjota aiheen tunnistenumero: ");
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
            }
            /*
            else if (input == 4)//Tulostaa kaikki valittavan aiheen tiedot
            {
                if (Topic.PrintAllTopics() ==  true)
                {
                    Console.WriteLine("Minkä aiheen kaikki tiedot haluat nähdä?");
                    
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
            }
            */
            //käyttäjä voi hakea aihetta tunnistenumeron tai aiheen perusteella
            else if (input == 5)
            {
                Console.Clear();
                Console.WriteLine("Kirjoita aihe TAI tunnistenumero, jota haluat hakea:");
                Console.Write("Kirjoita aihe TAI tunnistenumero: ");    
            
                string searchObject = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(searchObject) == true)
                {
                    Console.WriteLine("Kirjoita aihe tai tunnistenumero hakeaksesi aihetta!");
                }
                else
                {
                    
                    List<string> searchResult = Topic.SearchForTopic(searchObject);

                    if (searchResult.Count == 1)
                    {
                        Console.WriteLine("Haullasi \"{0}\" löytyi aihe {1}.", searchObject, searchResult[0]);
                    
                    }

                    if (searchResult.Count == 2)
                    {
                        Console.WriteLine("Haullasi \"{0}\" löytyi tulokset {1} ja {2}.", searchObject, searchResult[0], searchResult[1]);
                    }
                    
                    if (searchResult.Count > 2)
                    {
                        Console.WriteLine("Haullasi löytyi seuraavat aiheet: ");
                        foreach (string title in searchResult)
                        {
                            Console.WriteLine(title);
                        }
                    }
                    
                    else if (searchResult.Count == 0)
                    {
                        Console.WriteLine("Haullasi \"{0}\" ei löytynyt aiheita.", searchObject);
                    }

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
