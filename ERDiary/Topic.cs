//FEATURE

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
        private static List<Topic> topics = new List<Topic>();
        private static string path = @"C:\Users\Erkki\source\repos\ERDiary\data.csv";
        private static int idCounter = 1;//muuttuja ID:n määrittämiseksi; ensimmäinen aihe saa ID:n 1.
        
        public Topic(string title)
        {

            foreach (string line in File.ReadLines(path)) { idCounter++; }
            Title = title;
            //Id = topics.Count + 1;//ID määritetty ennen kuin Topic lisätään listalle >> topics.Count + 1
            Id = idCounter;
            topics.Add(this);//lisätään listalle topics
            Console.WriteLine("Lisäsit aiheen " + Title + ", jonka id on "+Id+" \n");

            //luodaan string array, yhdistetään string arrayn osat merkkijonoksi erotettuna pilkulla ja lisätään se csv-tiedostoon
            string[] stringsToAppend = new string[] { this.Id.ToString(), this.Title };
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
                Console.WriteLine();
            }
        }

        public static void PrintAllTopics()
        {
            Console.Clear();
            try 
            {
                string[] topicsToPrint = File.ReadAllLines(path);
                if (topicsToPrint.Length == 0)
                {
                    Console.WriteLine("Et ole lisännyt yhtään aihetta.");
                }
                else
                {
                    foreach (string topic in topicsToPrint)
                    {
                        Console.WriteLine(topic);//Tulostaa nyt csv-tiedoston rivit, mukaan lukien indeksit ja pilkut
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Et ole vielä lisännyt yhtään aihetta!");
            }
            Console.WriteLine();

        }
        public static void PrintAllIdsAndTopics()
        {
            Console.Clear();
            Console.WriteLine("Kaikki aiheet (id ja aihe):");
            foreach (var topic in topics)
            {
                Console.WriteLine(topic.Id + ") " + topic.Title);
            }
            Console.WriteLine();
        }

        public static void PrintAllProperties(int indexOfTopicToPrint)
        {
            Console.Clear();
            Console.WriteLine("Kaikki aiheen \"{0}\" tiedot:" +
                "\nId:" + topics[indexOfTopicToPrint].Id +
                "\nKuvaus: " + topics[indexOfTopicToPrint].Description +
                "\nAika-arvio, milloin taito hallittu: " + topics[indexOfTopicToPrint].EstimatedTimeToMaster +
                "\njne. jne." +
                "\njne. jne.", topics[indexOfTopicToPrint].Title);
            Console.WriteLine();
        }

        public static void ChoosePropertyToSet(int indexOfChosenTopic)
        {
        //tähän pitäisi lisätä tarkitus, onko metodin parametri ok!
        Console.WriteLine("Kirjoita numero, minkä tiedon haluat asettaa: " +
            "\n1) Otsikko" +
            "\n2) Kuvaus");
            if (Int32.TryParse(Console.ReadLine(), out int propertyToSet) == true)
            {
                Topic.SetProperty(indexOfChosenTopic, propertyToSet);
            }
            else
            {
                Console.WriteLine("Syötä numero.");
            }
        }

        public static void SetProperty(int idOfChosenTopic, int propertyToSet)
        {
            switch (propertyToSet)
            {
                case 1:
                    Console.Write("Syötä aiheelle uusi aihe: ");
                    //vaihtaa aiheen listaan
                    string newTopic = Console.ReadLine();
                    topics[idOfChosenTopic-1].Title = newTopic;
                    //vaihtaa aiheen csv-tiedostoon: käydään tiedoston rivit läpi
                    List<String> newLines = new List<String>();
                    foreach (string line in File.ReadLines(path)) 
                    {
                        string[] singleLine = line.Split(',');
                        if (idOfChosenTopic.ToString() == singleLine[0])//lines[0] = In
                        {
                            singleLine[1] = newTopic;//lines[1] = Title
                        }
                        newLines.Add(String.Join(',', singleLine));
                    }
                    File.Create(path).Close();
                    foreach (string line in newLines)
                    {
                        File.AppendAllText(path, line + Environment.NewLine);
                    }
                    break;

                case 2:
                    Console.Write("Syötä aiheen kuvaus: ");
                    topics[idOfChosenTopic].Description = Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("Vain otsikkoa (=1) ja kuvausta (=2) voi toistaiseksi muuttaa!");//Muut ominaisuudet kesken!
                    break;
            }

        }

    }

}
