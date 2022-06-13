using System;
using System.Collections.Generic;
using System.IO;


namespace ERDiary
{
    /*
     Id – int - Tähän talletetaan kyseisen aiheen tunniste
Title – string - Aiheen otsikko
Description – string - Aiheen kuvaus
EstimatedTimeToMaster  - double - Aika-arvio, kuinka kauan aiheen oppimiseen kuluu aikaa
TimeSpent - double - Käytetty aika
Source – string - Mahdollinen lähde esim web url tai kirja
StartLearningDate – datetime - Aloitusaika
InProgress – bool - Onko aiheen opiskelu kesken
CompletionDate - datetime - Milloin aihe on opiskeltu*/
    public class Topic
    {
        private int Id { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private double EstimatedTimeToMaster { get; set; }
        private double TimeSpent { get; set; }
        private string Source { get; set; }
        private DateTime StartLearningDate { get; set; }
        private bool InProgress { get; set; }
        private DateTime CompletionDate { get; set; }

        private static string path = @"C:\Users\Erkki\source\repos\ERDiary\data.csv";
        //private static List<Topic> topics = new List<Topic>();

        private static int idCounter = 1;//muuttuja ID:n määrittämiseksi; ensimmäinen aihe saa ID:n 1.
        private static bool increaseCounterValueFromCSV = true;//Katsoo CSV-tiedostosta aiheiden määrän VAIN ohjelman suorituksen alussa
                                                               //>> kun lista luetaan konstruktorissa ensimmäisen kerran, saa arvon false.


        public Topic(string title)
        {
            Console.Clear();

            //kun ohjelman käynnistyksen jälkeen luodaan ensimmäinen topic, while-loopissa katsotaan CSV-tiedostosta rivien määrä ja määritetään idCounter-muuttujalle oikea arvo. 
            if (File.Exists(path))
            {
                while (increaseCounterValueFromCSV)
                {
                    try
                    {
                        foreach (string line in File.ReadLines(path)) { idCounter++; }
                        increaseCounterValueFromCSV = false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            Title = title;
            //Id = topics.Count + 1;//ID määritetty ennen kuin Topic lisätään listalle >> topics.Count + 1
            Id = idCounter;
            idCounter++;

            //StartLearningDaten määritys
            StartLearningDate = DateTime.Now;

            Description = "-";

            //luodaan string array, yhdistetään string arrayn osat merkkijonoksi erotettuna pilkulla ja lisätään se csv-tiedostoon
            string[] stringsToAppend = new string[] { this.Id.ToString(), this.Title, this.StartLearningDate.ToString(), this.Description };
            string stringToAppend = String.Join(",", stringsToAppend);
            File.AppendAllText(path, stringToAppend + Environment.NewLine);

            //testataan, että tallentunut tiedostoon
            if (File.Exists(path))
            {
                string[] testing;
                testing = File.ReadAllLines(path);
                foreach (string topic in testing)
                {
                    Console.WriteLine("Tiedostosta tulostettu: " + topic);
                }
            }
        }
        

        //tulostaa kaikki aiheet ja niiden ID:t
        public static void PrintAllTopics()
        {
            Console.Clear();
            //yritetään lukea tiedosto
            try 
            {
                string[] topicsToPrint = File.ReadAllLines(path);
                if (topicsToPrint.Length == 0)
                {
                    Console.WriteLine("Et ole lisännyt yhtään aihetta.");//jos tiedosto löytyy mutta on tyhjä
                }
                
                //jos tiedosto ei ole tyhjä, foreach-loopissa jokaisesta rivin sisällöstä tehdään string[] ja tulostetaan sisältö
                else
                {
                    foreach (string topic in topicsToPrint)
                    {
                        string[] line = topic.Split(',');
                        Console.WriteLine("Aihe: " + line[1] +
                            " (tunniste: " + line[0] + ")");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.ResetColor();
                    }
                }
            }
            //jos tiedostoa ei ole olemassa, käyttäjä ei ole lisännyt yhtään aihetta
            catch (FileNotFoundException)
            {
                Console.WriteLine("Et ole vielä lisännyt yhtään aihetta!");
            }
            Console.WriteLine();

        }
        //public static void PrintAllIdsAndTopics()
        //{
        //    Console.Clear();
        //    Console.WriteLine("Kaikki aiheet (id ja aihe):");
        //    foreach (var topic in topics)
        //    {
        //        Console.WriteLine(topic.Id + ") " + topic.Title);
        //    }
        //    Console.WriteLine();
        //}

        //metodi tulostaa parametrina saadun ID:n mukaisen aiheen kaikki tiedot
        public static void PrintAllProperties(int idOfChosenTopic)
        {
            //List<String> printingArray = new List<String>();
            foreach (string line in File.ReadLines(path))
            {
                string[] singleLine = line.Split(',');
                if (idOfChosenTopic.ToString() == singleLine[0])//lines[0] = In
                {
                    Console.WriteLine("Aihe: " + singleLine[1] +
                        " (tunniste: " + singleLine[0] + ")" +
                        "\nAloitusaika: " + singleLine[2] +
                        "\nKuvaus: " + singleLine[3]);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
                    Console.ResetColor();   
                }
            }
        }

        //tässä metodissa valitaan mitä attribuuttia haluaa muuttaa. Metodi kutsuu metodia SetProperty().
        public static void ChoosePropertyToSet(int idOfChosenTopic)
        {
        //tähän pitäisi lisätä tarkitus, onko metodin parametri ok
        Console.WriteLine("\nMitä tietoa haluat muuttaa: " +
            "\n1) Otsikko" +
            "\n2) Kuvaus\n");
            AskForId("");
            if (Int32.TryParse(Console.ReadLine(), out int propertyToSet) == true)
            {
                Topic.SetProperty(idOfChosenTopic, propertyToSet);
            }
            else
            {
                Console.WriteLine("Syötä numero.");
            }
        }

        //Metodi muuttaa parametrina saadun ID:n ja attribuutin mukaisesti tietoja
        public static void SetProperty(int idOfChosenTopic, int propertyToSet)
        {
            switch (propertyToSet)
            {
                case 1:
                    Console.Write("Syötä aiheelle uusi aihe: ");
                    string newProperty = Console.ReadLine();

                    EditPropertyInCSV(idOfChosenTopic, propertyToSet, newProperty);
                    break;

                case 2:
                    Console.Write("Syötä aiheelle uusi kuvaus: ");
                    string newDescription = Console.ReadLine();
                    EditPropertyInCSV(idOfChosenTopic, propertyToSet, newDescription);
                    break;

                default:
                    Console.WriteLine("Vain otsikkoa (=1) ja kuvausta (=2) voi toistaiseksi muuttaa!");//Muut ominaisuudet kesken!
                    break;
            }

        }

        private static void EditPropertyInCSV(int idOfChosenTopic, int indexOfPropertyToSet, string newProperty)
        {
            //Muutetaan käyttäjän syöte vastaamaan CSV-tiedoston muotoa: 1 >> lines[1] = Title, 2 >> lines[3] = Description
            if (indexOfPropertyToSet == 2)
            {
                indexOfPropertyToSet = 3;
            }
            //käydään tiedoston rivit läpi
            List<String> newLines = new List<String>();
            foreach (string line in File.ReadLines(path))
            {
                string[] singleLine = line.Split(',');
                if (idOfChosenTopic.ToString() == singleLine[0])//lines[0] = In
                {
                    singleLine[indexOfPropertyToSet] = newProperty;//lines[1] = Title, lines[3] = Description
                }
                newLines.Add(String.Join(',', singleLine));
            }
            File.Create(path).Close();//tyhjentää listan ennen kuin uusi sisältö lisätään
            foreach (string line in newLines)
            {
                File.AppendAllText(path, line + Environment.NewLine);
            }
        }


        //Metodi tekee käyttäjän syötteen mukaisen haun 
        public static void SearchForTopic(string searchObject)
        {
            Dictionary<int, string> topicsDict = CreateDictionaryFromCSV();//kutsutaan sanakirjan palauttavaa metodia
            if (Int32.TryParse(searchObject, out int searchObjectNumber) == true) 
            {
                //etsitään numerolla
                if (topicsDict.ContainsKey(searchObjectNumber))
                {
                    Console.WriteLine("Löytyi! Tunnisteella {0} etsimäsi aihe on {1}!", searchObjectNumber, topicsDict[searchObjectNumber]);
                }
                else { Console.WriteLine("Tunnisteella {0} ei löytynyt aihetta.", searchObjectNumber); }
            }
            else
            {
                //etsitään aiheella tai sen osalla. Haku ei ole merkkikokoriippuvainen (toLower)
                List<string> topicsFound = new List<string>();
                for (int i = 1; i <= topicsDict.Count; i++)
                {
                    if (topicsDict[i].ToLower().Contains(searchObject.ToLower()))
                    {
                        //Console.WriteLine("Löytyi! Etsimäsi aiheen {0} tunniste on {1}.", topicsDict[i], i);
                        topicsFound.Add(topicsDict[i]);
                    }
                }
                if (topicsFound.Count == 0) 
                {
                    Console.WriteLine("Aihetta {0} ei löytynyt.", searchObject);
                }
                else 
                //jos topicsFound.Count ei ole 0, suoritetaan topicsFound.Countin mukainen koodilohko
                {
                    switch (topicsFound.Count)
                    {
                        case 1:
                            Console.WriteLine("Haulla löytyi yksi aihe \"{0}\".", topicsFound[0]);
                            break;
                        case 2:
                            Console.WriteLine("Haulla löytyi aiheet \"{0}\" ja \"{1}\".", topicsFound[0], topicsFound[1]);
                            break;
                        default:
                            Console.WriteLine("Haulla löytyi seuraavat aiheet:");
                            foreach (string title in topicsFound)
                            {
                                Console.WriteLine(title);
                            }
                            break;
                    }
                }
                    
            }
        }


        //Metodi palauttaa CSV-tiedostosta luodun sanakirjan (TKey = int ID, TValue = string topic)
        private static Dictionary<int, string> CreateDictionaryFromCSV()
        {
            Dictionary<int, string> topicsDict = new Dictionary<int, string>();
            //käydään läpi CSV-tiedosto ja lisätään sanakirjaoliot
            try
            {
                foreach (string line in File.ReadLines(path))
                {
                    string[] singleLine = line.Split(',');
                    topicsDict.Add(Convert.ToInt32(singleLine[0]), singleLine[1]);//singleLine[0] = ID, singleLine[1] = topic                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return topicsDict;
        }

        //Metodi tulostaa punaisella värillä kentän, johon käyttäjä syöttää numeron (jotta kenttä on helpompi huomata muun tekstin joukosta)
        public static void AskForId(string whatTypeOfNumber)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Kirjoita {0}numero:  ", whatTypeOfNumber);
            Console.ResetColor();
        }
    }

}
