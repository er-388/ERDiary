﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oppimispäiväkirja.Data;

namespace Oppimispäiväkirja.Models

#nullable disable

{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? TimeToMaster { get; set; }
        public int? TimeSpent { get; set; }
        public string Source { get; set; }
        public DateTime? StartLearningDate { get; set; }
        public bool? InProgress { get; set; }
        public DateTime? CompletionDate { get; set; }

        
        public Topic()
        {

        }
        
        /*
        public Topic(string title)
        {

            using (TopicsContext tietokantaYhteys = new TopicsContext(DbContextOptions<TopicsContext>))
            {
                var taulu = tietokantaYhteys.Topics.Select(topic => topic);

                //Määritetään Id-numero: jos tietokannassa on ID:itä, katsotaan suurin ID tietokannasta.   
                var suurinId = 0;
                try
                {
                    suurinId = tietokantaYhteys.Topics.Max(topic => topic.Id);
                }
                catch { }

                Id = suurinId + 1;
                Title = title;
                StartLearningDate = DateTime.Now;
                InProgress = true;

                tietokantaYhteys.Topics.Add(this);
                tietokantaYhteys.SaveChanges();
            }

        }

        
        // Tulostaa kaikki aiheet ja tunnistenumerot tietokannasta. Palauttaa true jos ainakin 1 aihe löytyy, muutoin palauttaa false.
        public async static Task<bool> PrintAllTopicsAsync()
        {
            using (LearningDiaryContext tietokantaYhteys = new LearningDiaryContext())
            {
                var results = await Task.Run(() =>
                tietokantaYhteys.Topics.Select(topic =>
                new { Title = topic.Title, Id = topic.Id }));

                foreach (var result in results)
                {
                    Console.WriteLine("{0} (Tunnistenumero: {1})", result.Title, result.Id);
                }

                if (results.Count() == 0)
                {
                    return false;
                }

                else
                {
                    return true;
                }
            }
        }


        //tässä metodissa valitaan mitä attribuuttia haluaa muuttaa. Metodi kutsuu metodia SetProperty().
        public async static Task ChoosePropertyToSet(int idOfChosenTopic)
        {
            //Tarkistetaan palauttaako metodi SearchForTopic() listan, jossa on yksi alkio
            List<string> idExists = await SearchForTopicAsync(idOfChosenTopic.ToString());
            if (idExists.Count == 1)
            {
                Console.WriteLine("\nMitä tietoa haluat muuttaa?" +
                    "\n1) Otsikko" +
                    "\n2) Kuvaus" +
                    "\n3) Asian opiskeluun kuluva aika" +
                    "\n4) Asian opiskeluun käytetty aika" +
                    "\n5) Lähde (esim. kirja tai URL)" +
                    "\n6) Aseta aiheen opiskelun päättymispäivä" +
                    "\n7) Poista aihe");

                if (Int32.TryParse(Console.ReadLine(), out int propertyToSet) == true)
                {
                    Topic.SetPropertyAsync(idOfChosenTopic, propertyToSet);
                }
                else
                {
                    Console.WriteLine("Syötä numero.");
                }
            }
            else
            {
                Console.WriteLine("\nSyöttämälläsi tunnistenumerolla ei ole aihetta!");
                return;
            }
        }


        //Metodi muuttaa parametrina saadun ID:n ja attribuutin mukaisesti tietoja
        public static async Task SetPropertyAsync(int idOfChosenTopic, int propertyToSet)
        {
            switch (propertyToSet)
            {
                case 1:
                    Console.Write("Syötä aiheelle uusi aihe: ");
                    string newTitle = Console.ReadLine();

                    using (var tietokantaYhteys = new LearningDiaryContext())
                    {
                        var result = tietokantaYhteys.Topics.SingleOrDefault(topic => topic.Id == idOfChosenTopic);
                        if (result != null)
                        {
                            result.Title = newTitle;
                            tietokantaYhteys.SaveChanges();
                        }

                    }
                    break;

                case 2:
                    Console.Write("Syötä aiheelle uusi kuvaus: ");
                    string newDescription = Console.ReadLine();
                    using (var tietokantaYhteys = new LearningDiaryContext())
                    {
                        var result = tietokantaYhteys.Topics.SingleOrDefault(topic => topic.Id == idOfChosenTopic);
                        if (result != null)
                        {
                            result.Description = newDescription;
                            tietokantaYhteys.SaveChanges();
                        }

                    }
                    break;

                case 3:
                    Console.Write("Montako tuntia aiheen opetteluun kuluu? ");
                    if (Int32.TryParse(Console.ReadLine(), out int timeToMaster) == true)
                    {
                        using (LearningDiaryContext tietokantaYhteys = new LearningDiaryContext())
                        {
                            var result = tietokantaYhteys.Topics.SingleOrDefault(topic => topic.Id == idOfChosenTopic);
                            if (result != null)
                            {
                                result.TimeToMaster = timeToMaster;
                                tietokantaYhteys.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Kirjoita opetteluun käytettävä aika numerona!");
                    }
                    break;

                case 4://TimeSpent
                    Console.Write("Montako tuntia olet opiskellut aihetta? ");
                    if (Int32.TryParse(Console.ReadLine(), out int timeSpent) == true)
                    {
                        using (LearningDiaryContext tietokantaYhteys = new LearningDiaryContext())
                        {
                            var result = tietokantaYhteys.Topics.SingleOrDefault(topic => topic.Id == idOfChosenTopic);
                            result.TimeSpent = timeSpent;
                            tietokantaYhteys.SaveChanges();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Kirjoita opiskeluun käytetty aika numerona!");
                    }
                    break;

                case 5://string Source
                    Console.Write("Kirjoita opiskelussa käyttämäsi lähteet (kirja ja/tai nettisivu): ");
                    string source = Console.ReadLine();


                    using (LearningDiaryContext tietokantaYhteys = new LearningDiaryContext())
                    {
                        var result = tietokantaYhteys.Topics.SingleOrDefault(topic => topic.Id == idOfChosenTopic);
                        result.Source = source;
                        tietokantaYhteys.SaveChanges();
                    }
                    break;

                case 6://Asettaa päättymispäivän käyttäjän syötteen mukaisesti ja muuttaa InProgress = false

                    Console.Write("Milloin aiheen opiskelu on päättynyt? Kirjoita muodossa pp.kk.vvvv: \n");
                    if (DateTime.TryParseExact(Console.ReadLine(),
                        "d.M.yyyy",
                        System.Globalization.CultureInfo.CreateSpecificCulture("fi-FI"),
                        System.Globalization.DateTimeStyles.None,
                        out DateTime completionDate)
                        == true
                        && Class1.OnkoTulevaisuudesta(completionDate) == false)
                    {

                        using (LearningDiaryContext tietokantaYhteys = new LearningDiaryContext())
                        {
                            var result = tietokantaYhteys.Topics.SingleOrDefault(topic => topic.Id == idOfChosenTopic);
                            if (result != null)
                            {
                                result.CompletionDate = completionDate;
                                result.InProgress = false;
                                tietokantaYhteys.SaveChanges();
                            }
                        }
                    }

                    else
                    {
                        Console.WriteLine("Päivämäärä ei ollut oikein tai päivämäärä on tulevaisuudessa!");
                    }

                    break;

                case 7://Poistaa aiheen
                    DeleteTopic(idOfChosenTopic);
                    break;

                default:
                    Console.WriteLine("Valitse toiminto numerolla 1-7!");//
                    break;
            }
        }


        //poistaa käyttäjän valitseman topicin
        public static void DeleteTopic(int idOfChosenTopic)
        {
            using (LearningDiaryContext tietokantaYhteys = new LearningDiaryContext())
            {
                var result = tietokantaYhteys.Topics.FirstOrDefault(topic => topic.Id == idOfChosenTopic);
                tietokantaYhteys.Topics.Remove(result);
                tietokantaYhteys.SaveChanges();
            }
        }


        //Palauttaa List<string>-listan haetun aiheen attribuuteista
        public static async Task<List<string>> PrintAllProperties(int topicToPrint)
        {
            List<string> result = new List<string>();

            //Tarkistetaan SearchForTopicAsync()-metodilla löytyykö haluttua ID:tä 
            List<string> idExists = await SearchForTopicAsync(topicToPrint.ToString());
            if (idExists.Count != 1)
            {
                return result;
            }

            using (LearningDiaryContext tietokantaYhteys = new LearningDiaryContext())
            {
                try
                {
                    Topic foundTopic = await (tietokantaYhteys.Topics.SingleOrDefaultAsync(topic => topic.Id == topicToPrint));

                    string[] s = new string[] {
                        foundTopic.Title,
                        foundTopic.Id.ToString(),
                        foundTopic.Description,
                        foundTopic.TimeToMaster.ToString(),
                        foundTopic.TimeSpent.ToString(),
                        foundTopic.Source,
                        foundTopic.StartLearningDate.ToString(),
                        foundTopic.InProgress.ToString(),
                        foundTopic.CompletionDate.ToString() };
                    result = s.ToList();
                }
                catch
                {
                    Console.WriteLine("Et ole vielä lisännyt yhtään aihetta!");
                }
            }
            return result;
        }


        //Haetaan käyttäjän syötteen mukaan joko ID:n tai titlen mukaan aihetta ja näytetään tulokset käyttäjälle
        public static async Task<List<string>> SearchForTopicAsync(string searchObject)
        {
            using (LearningDiaryContext tietokantaYhteys = new LearningDiaryContext())
            {
                //luodaan lista, jonne hakutulokset menevät ja joka palautetaan metodista.
                List<string> result = new List<string>();
                if (Int32.TryParse(searchObject, out int searchId) == true)
                {
                    try
                    {
                        await Task.Run(() => result.Add(tietokantaYhteys.Topics
                            .Where(topic => topic.Id == searchId)
                            .Select(topic => topic.Title)
                            .First()));
                    }
                    catch
                    {

                    }
                    return result;
                }

                else
                {
                    result = await Task.Run(() =>
                    tietokantaYhteys.Topics
                        .Where(topic => topic.Title.ToLower()
                        .Contains(searchObject.ToLower()))
                        .Select(topic => topic.Title).ToList());
                }
                return result;
            }
        }


    }

    public class TaskObject : Topic
    {

        protected List<string> Notes { get; set; }
        protected DateTime Deadline { get; set; }
        protected _Priority Priority { get; set; }  //low, medium, high
        protected bool Done { get; set; }

        private static TaskObject[] taskArray = new TaskObject[100];

        public TaskObject()
        {

        }

        public TaskObject(string title, DateTime deadline, string priority)
        {
            //Etsitään suurin ID
            int highestTaskId = 0;
            try
            {
                foreach (TaskObject task in taskArray)
                {
                    if (task != null)
                    {
                        if (task.Id > highestTaskId)
                        {
                            highestTaskId = task.Id;
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception)
            {

            }

            this.Id = highestTaskId + 1;
            this.Title = title;
            this.Deadline = deadline;

            if (priority == "matala")
            {
                this.Priority = _Priority.Low;
            }
            if (priority == "keski" || priority == "keskitaso")
            {
                this.Priority = _Priority.Medium;
            }
            if (priority == "korkea")
            {
                this.Priority = _Priority.High;
            }
            this.Deadline = deadline;
            this.Done = false;
            taskArray[this.Id] = this;
        }


        public static List<string> PrintAllTaskTitles()
        {
            List<string> taskTitles = new List<string>();
            if (taskArray.Count() > 0)
            {
                foreach (TaskObject task in taskArray)
                {
                    if (task != null)
                    {
                        taskTitles.Add(task.Title);
                    }
                }
            }
            return taskTitles;
        }



        public enum _Priority
        {
            High = 1,
            Medium = 2,
            Low = 3

        }
        */
    }
}
