//FEATURE

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
            Title = title;
            Id = topics.Count + 1;//ID määritetty ennen listalle lisäämistä, joten topics.Count + 1
            topics.Add(this);
            Console.WriteLine("Lisäsit aiheen " + Title + ", jonka id on "+Id+" \n");
        }

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
        
    }

}
