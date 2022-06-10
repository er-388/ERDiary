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
        private static bool increaseCounterValueFromCSV = true;//Katsoo CSV-tiedostosta aiheiden määrän VAIN ohjelman suorituksen alussa >> kun lista luetaan konstruktorissa ensimmäisen kerran, saa arvon false.

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

            //lisätään listalle topics
            //topics.Add(this);
            //Console.WriteLine("\nLisäsit klo " + StartLearningDate + " aiheen " + Title + ", jonka id on "+Id+".\n");

            //luodaan string array, yhdistetään string arrayn osat merkkijonoksi erotettuna pilkulla ja lisätään se csv-tiedostoon
            string[] stringsToAppend = new string[] { this.Id.ToString(), this.Title, this.StartLearningDate.ToString(), this.Description};
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

        public static void ChoosePropertyToSet(int indexOfChosenTopic)
        {
        //tähän pitäisi lisätä tarkitus, onko metodin parametri ok
        Console.WriteLine("\nMitä tietoa haluat muuttaa: " +
            "\n1) Otsikko" +
            "\n2) Kuvaus\n");
            AskForId("");
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
                    //topics[idOfChosenTopic-1].Title = newTopic;
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
                    File.Create(path).Close();//tyhjentää listan ennen kuin uusi sisältö lisätään
                    foreach (string line in newLines)
                    {
                        File.AppendAllText(path, line + Environment.NewLine);
                    }
                    break;

                case 2:
                    //Console.Write("Syötä aiheen kuvaus: ");
                    //topics[idOfChosenTopic].Description = Console.ReadLine();
                    Console.Write("Syötä aiheelle uusi aihe: ");
                    //vaihtaa kuvauksen listaan
                    string newDescription = Console.ReadLine();
                    //topics[idOfChosenTopic - 1].Description = newDescription;
                    
                    //vaihtaa kuvauksen csv-tiedostoon: käydään tiedoston rivit läpi
                    List<String> newLinesOfDescription = new List<String>();
                    foreach (string line in File.ReadLines(path))
                    {
                        string[] singleLine = line.Split(',');
                        if (idOfChosenTopic.ToString() == singleLine[0])//lines[0] = In
                        {
                            singleLine[3] = newDescription;//lines[3] = Description
                        }
                        newLinesOfDescription.Add(String.Join(',', singleLine));
                    }
                    File.Create(path).Close();//tyhjentää listan ennen kuin uusi sisältö lisätään
                    foreach (string line in newLinesOfDescription)
                    {
                        File.AppendAllText(path, line + Environment.NewLine);
                    }
                    break;

                default:
                    Console.WriteLine("Vain otsikkoa (=1) ja kuvausta (=2) voi toistaiseksi muuttaa!");//Muut ominaisuudet kesken!
                    break;
            }

        }

        public static void AskForId(string whatTypeOfNumber)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Kirjoita {0}numero:  ", whatTypeOfNumber);
            Console.ResetColor();
        }
    }

}
