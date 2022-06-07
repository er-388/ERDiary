using System;
using System.Collections.Generic;

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
        public static List<Topic> topics = new List<Topic>();
        //private static int counter = 1;
        public Topic(string title)
        {
            //Id = counter;
            //counter++;
            Title = title;
            Id = topics.Count + 1;
            topics.Add(this);
            Console.WriteLine("Lisäsit aiheen " + Title + ", jonka id on "+Id+" \n");
        }

        //public static void AddNewTopic(string title)
        //{
        //    topics.Add(new Topic(title));
        //}

        public static void PrintAllTopics()
        {
            Console.Clear();
            Console.WriteLine("Kaikki syötetyt aiheet:");
            foreach (var topic in topics)
            {
                Console.WriteLine(topic.Title);
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
                "\njne. jne.");
            Console.WriteLine();
        }

        public static void ChoosePropertyToSet(int indexOfChosenTopic)
        {
            Console.WriteLine("Kirjoita numero, minkä tiedon haluat asettaa: " +
                "\n1) Otsikko" +
                "\n2) Kuvaus");
            int propertyToSet = Convert.ToInt32(Console.ReadLine());
            Topic.SetProperty(indexOfChosenTopic, propertyToSet);

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
