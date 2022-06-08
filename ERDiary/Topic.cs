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
        private static string path = @"C:\Users\Erkki\source\repos\ERDiary\data.txt";
        public Topic(string title)
        {
            Title = title;
            Id = topics.Count + 1;//ID määritetty ennen listalle lisäämistä, joten topics.Count + 1
            topics.Add(this);
            Console.WriteLine("Lisäsit aiheen " + Title + ", jonka id on "+Id+" \n");
            File.AppendAllText(path, title + Environment.NewLine);

            if (File.Exists(path))//testataan tiedosto
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
            if (File.Exists(path))
            {
                string[] topicsToPrint = File.ReadAllLines(path);
                if (topicsToPrint.Length == 0)
                {
                    Console.WriteLine("Tiedosto on tyhjä!");
                }
                else
                {
                    foreach (string topic in topicsToPrint)
                    {
                        Console.WriteLine(topic);
                    }
                }
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
                "\njne. jne.", topics[indexOfTopicToPrint].Title);
            Console.WriteLine();
        }

        public static void ChoosePropertyToSet(int indexOfChosenTopic)
        {
            Console.WriteLine("Kirjoita numero, minkä tiedon haluat asettaa: " +
                "\n1) Otsikko" +
                "\n2) Kuvaus");
            if (Int32.TryParse(Console.ReadLine(), out int propertyToSet) == true)
            {
                propertyToSet--; //vähennetään 1 jotta saadaan suoraan listan topics indeksi
                Topic.SetProperty(indexOfChosenTopic, propertyToSet);
            }
            else
            {
                Console.WriteLine("Syötä numero.");
            }

        }
        public static void SetProperty(int indexOfChosenTopic, int propertyToSet)
        {
            switch (propertyToSet)
            {
                case 1:
                    Console.Write("Syötä aiheelle uusi aihe: ");
                    topics[indexOfChosenTopic].Title = Console.ReadLine();
                    break;

                case 2:
                    Console.Write("Syötä aiheen kuvaus: ");
                    topics[indexOfChosenTopic].Description = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Vain otsikkoa (=1) ja kuvausta (=2) voi toistaiseksi muuttaa!");//Muut ominaisuudet kesken!
                    break;
            }

        }

    }

}
