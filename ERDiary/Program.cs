using System;
using System.Collections.Generic;
using ERDiary.Models;
using System.Threading.Tasks;
using System.Linq;

namespace ERDiary
{
    class Program
    {
        static async Task Main(string[] args)
        {
            

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine(@"  _   _   _ ___      ___  __  _ o  o ___    o  o    ___  _           
 / \ |_) |_) |  |\/|  |  (_  |_) /\   | \  / /\  |/  |  |_)   |  /\  
 \_/ |   |  _|_ |  | _|_ __) |  /--\ _|_ \/ /--\ |\ _|_ | \ \_| /--\");

            Console.WriteLine();
            Console.ResetColor();

            //ShowMenu() palauttaa false, jos käyttäjä haluaa lopettaa eli painaa valikossa ENTER.

            //bool showMenu = true;
            while (await MainMenuAsync())
            {
                
            }
            

            
            
        }

        static async Task<bool> MainMenuAsync()
        {
            bool showMenu;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(@"
    ~~~~~~~~~~~~~
       VALIKKO
    ~~~~~~~~~~~~~");
            Console.ResetColor();
            Console.WriteLine("\n   Toiminnot"                          +
                "\n1) Syöttääksesi uusi aihe"                           +
                "\n2) Tulostaaksesi kaikki aiheet "                     +
                "\n3) Aiheen tietojen muokkaaminen tai aiheen poisto"   +
                "\n4) Näytä yhden aiheen kaikki tiedot"                 +
                "\n5) Etsi aihe\n"                                      +

                "\n6) Syöttääksesi uusi tehtävä"                        +
                "\n7) Tulostaaksesi kaikki tehtävät"                    +
                "\ntai paina ENTER lopettaaksesi.");
            
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Valitse toiminto:  ");
            Console.ResetColor();
            string stringInput = Console.ReadLine();


           if (String.IsNullOrWhiteSpace(stringInput))
            {
                showMenu = false; ;//lopettaa MainMenun (ja ohjelman) suorituksen
                return showMenu;
            }

            //tarkistaa onko syöte kokonaisluku ja luo kokonaislukumuuttujan "input"
            else if (Int32.TryParse(stringInput, out int input) == false)
            {
                Console.WriteLine("Syötä numero.");
            }


            //Kysyy käyttäjältä aihetta ja lisää sen tietokantaan
            else if (input == 1)
            {
                Console.Write("Syötä aiheen otsikko (tai paina ENTER palataksesi takaisin): ");
                string title = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(title))
                {
                    Topic t = new Topic(title);
                }
                else
                {
                    Console.WriteLine("\nAnna aiheelle jokin otsikko!\n");
                }
            }


            //Tulostaa kaikki aiheet
            else if (input == 2)
            {
                Console.Clear();
                Console.WriteLine("Kaikki syötetyt aiheet:\n");
                await Topic.PrintAllTopicsAsync();
                Console.WriteLine("Jatketaan ohjelman suoritusta.");

            }


            //Käyttäjä voi muokata valitsemansa aiheen tietoja
            else if (input == 3)
            {
                Console.Clear();
                //tulostaa aiheet ja palauttaa true jos yksikin aihe on luotu.

                if (await Topic.PrintAllTopicsAsync() == true)
                {
                    Console.WriteLine("Minkä aiheen tietoja haluat muokata?\n");
                    Console.Write("Kirjota aiheen tunnistenumero: ");

                    //jos syöte on numero, siirrytään metodiin, josta valitaan mitä valitun aiheen ominaisuutta halutaan muokata.
                    if (Int32.TryParse(Console.ReadLine(), out int idOfTopicToEdit) == true)
                    {
                        await Topic.ChoosePropertyToSet(idOfTopicToEdit);
                    }

                    else
                    {
                        Console.WriteLine("Syötä numero.");
                    }
                }
            }


            //Tulostaa kaikki valittavan aiheen tiedot
            else if (input == 4)
            {
                if (await Topic.PrintAllTopicsAsync() == true)
                {
                    Console.WriteLine("Minkä aiheen kaikki tiedot haluat nähdä?");

                    if (Int32.TryParse(Console.ReadLine(), out int topicToPrint) == true)
                    {
                        Console.Clear();
                        List<string> printResult = await Topic.PrintAllProperties(topicToPrint);
                        if (printResult.Count != 0)
                        {
                            //Jos tieto puuttuu, muutetaan tulostusta varten kentän tiedoksi "---"
                            for (int i = 0; i < printResult.Count; i++)
                            {
                                if (String.IsNullOrWhiteSpace(printResult[i]))
                                {
                                    printResult[i] = "---";
                                }
                            }
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nAiheen {0} kaikki tiedot:", topicToPrint);
                            Console.ResetColor();
                            //Tulostetaan printResultin alkiot
                            Console.WriteLine("Aihe: " + printResult[0] +
                                " (tunniste: " + printResult[1] + ")" +
                                "\nKuvaus: " + printResult[2] +
                                "\nOpiskeluun kuluva aika (h): " + printResult[3] +
                                "\nOpiskeluun käytetty aika (h): " + printResult[4] +
                                "\nLähde: " + printResult[5] +
                                "\nAloitusaika: " + printResult[6]);
                            Console.WriteLine("Aiheen oppiminen kesken: " + ((printResult[7].ToLower() == "true") ? "Kyllä" : "Ei"));
                            Console.WriteLine("Opiskelu loppunut: " + printResult[8]);
                        }

                        else if (printResult.Count == 0)
                        {
                            Console.WriteLine("Valitsemallasi tunnistenumerolla ei löytynyt aihetta.");
                        }


                    }
                    else
                    {
                        Console.WriteLine("Syötä numero.");//Jos tulostettavan aiheen tunnistenumeroa pyydettäessä ei ole syötetty numeroa
                    }
                }
            }


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

                    List<string> searchResult = await Topic.SearchForTopicAsync(searchObject);

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


            //Luodaan uusi tehtävä
            else if (input == 6)
            {
                Console.Clear();
                Console.Write("Syötä tehtävän otsikko (tai paina ENTER palataksesi takaisin): ");
                string taskTitle = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(taskTitle))
                {
                    Console.WriteLine("Anna tehtävälle otsikko!");
                }
                //Jos käyttäjän syöte ei ole tyhjä, jatketaan tärkeysasteen ja määräajan kysymistä, kunnes ko. tiedot on saatu oikein käyttäjältä.
                else 
                {
                    string priority = "";
                    bool correctDateFormat = false;
                    DateTime deadline = new DateTime();
                    while (correctDateFormat == false)
                    {
                        Console.Write("\nSyötä tehtävän määräaika (pp.kk.vvvv): ");
                        if (DateTime.TryParseExact(Console.ReadLine(), "d.M.yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("fi-FI"),
                            System.Globalization.DateTimeStyles.None, out DateTime dt)
                            == true)
                        {
                            correctDateFormat = true;
                            deadline = dt;
                        }
                        else
                        {
                            Console.WriteLine("\nPäivämäärä ei ollut oikeassa muodossa!");
                        }
                    }

                    bool correctPriority = false;
                    string[] acceptedPriority = new string[] { "matala", "keski", "keskitaso", "korkea" };
                    while (correctPriority == false)
                    {
                        Console.WriteLine("Onko tehtävän tärkeysaste matala, keskitaso vai korkea?");
                        priority = Console.ReadLine().ToLower();
                        if (acceptedPriority.Contains(priority) == true)
                        {
                            correctPriority = true;
                        }
                        else
                        {
                            Console.WriteLine("\nTärkeysaste ei ollut oikein!");
                        }
                    }
                    
                    TaskObject t = new TaskObject(taskTitle, deadline, priority);
                }
            }


            //Tulostetaan taskArraystä kaikkien ohjelman ajon aikana luotujen taskien otsikot.
            else if (input == 7)
            {
                Console.Clear();
                List<string> taskTitles = TaskObject.PrintAllTaskTitles();
                switch (taskTitles.Count)
                {
                    case 0:
                        Console.WriteLine("Yhtään tehtävää ei ole vielä luotu!");
                        break;

                    case 1:
                        Console.WriteLine($"Löytyi tehtävä {taskTitles[0]}.");
                        break;

                    default:
                        Console.WriteLine("Löytyi seuraavat tehtävät:");
                        foreach (string title in taskTitles)
                        {
                            Console.WriteLine(title);
                        }
                        break;
                }
            }


            else
            {
                Console.Clear();
                Console.WriteLine("Kokeile uudestaan.");//käyttäjä syöttänyt MainMenun() sisällä jotakun muuta kuin 1-5 tai ENTER.
            }

            showMenu = true;
            return showMenu;//jos syöte muuta kuin ENTER, MainMenu() toistoa jatketaan.
        }

    
    }


}
