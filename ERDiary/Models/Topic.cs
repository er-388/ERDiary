using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace ERDiary.Models
{
    public partial class Topic
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

        public Topic(string title)
        {
            
            using (LearningDiaryContext tietokantaYhteys = new LearningDiaryContext())
            {
                var taulu = tietokantaYhteys.Topics.Select(topic => topic);
                //Määritetään Id-numero: jos tietokannassa on ID:itä, katsotaan se tietokannasta.   
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
        public static bool PrintAllTopics() 
        {
            Console.WriteLine("Kaikki aiheet:\n");
            using (LearningDiaryContext tietokantaYhteys = new LearningDiaryContext())
            {
                var results = tietokantaYhteys.Topics.Select(topic => new { Title = topic.Title, Id = topic.Id });

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
        public static void ChoosePropertyToSet(int idOfChosenTopic)
        {
            //Tarkistetaan metodilla SearchForTopic() onko onko käyttäjän syöttämä ID-numero olemassa 
            if (SearchForTopic(idOfChosenTopic.ToString()).Count == 1)
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
                    Topic.SetProperty(idOfChosenTopic, propertyToSet);
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
        public static void SetProperty(int idOfChosenTopic, int propertyToSet)
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
                        == true) 
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
                        Console.WriteLine("Päivämäärä ei ollut oikein!");
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
        public static List<string> PrintAllProperties(int topicToPrint)
        {
            List<string> result = new List<string>();
            if (SearchForTopic(topicToPrint.ToString()).Count != 1)
            {
                return result;
            }

            using (LearningDiaryContext tietokantaYhteys = new LearningDiaryContext())
            {
                try
                {
                    Topic foundTopic = tietokantaYhteys.Topics.First(topic => topic.Id == topicToPrint);
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
        public static List<string> SearchForTopic(string searchObject)
        {
            using (LearningDiaryContext tietokantaYhteys = new LearningDiaryContext())
            {
                //luodaan lista, jonne hakutulokset menevät ja joka palautetaan metodista.
                List<string> result = new List<string>();
                if (Int32.TryParse(searchObject, out int searchId) == true)
                {
                    try
                    {
                        result.Add(tietokantaYhteys.Topics
                            .Where(topic => topic.Id == searchId)
                            .Select(topic => topic.Title)
                            .First());
                    }
                    catch 
                    {
                        
                    }
                    return result;
                }

                else
                {
                    result = tietokantaYhteys.Topics
                        .Where(topic => topic.Title.ToLower()
                        .Contains(searchObject.ToLower()))
                        .Select(topic => topic.Title).ToList();
                }
                return result;
            }
        }


    }
}
