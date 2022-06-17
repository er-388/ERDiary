using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ERDiary
{
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

        //private static int idCounter = 1;//Ei enää käytössä; muuttuja ID:n määrittämiseksi; ensimmäinen aihe saa ID:n 1.
        //private static bool increaseCounterValueFromCSV = true;//Ei enää käytössä. Muuttuja käytössä, kun CSV-tiedostosta luetaan aiheiden määrä ohjelman suorituksen alussa
                                                               //>> kun lista luetaan konstruktorissa ensimmäisen kerran, saa arvon false.

        
        // Tämä konstruktori on käytössä, kun CSV:stä luodaan List<Topic>
        private Topic(string id, string title,
                string startLearningDate, string description,
                string estimatedTimeToMaster, string timeSpent,
                string inProgress, string source, string completionDate)
        {
            Id = Int32.Parse(id);
            Title = title;
            Description = description;
            EstimatedTimeToMaster = Double.Parse(estimatedTimeToMaster);
            TimeSpent = Double.Parse(timeSpent);
            Source = source;

            // parsetaan merkkijonosta DateTime-muoto dtStart
            DateTime.TryParseExact(startLearningDate, 
                "dd/MM/yyyy HH:MM:ss", 
                System.Globalization.CultureInfo.CreateSpecificCulture("fi-FI"), 
                System.Globalization.DateTimeStyles.None, out DateTime dtStart);
            StartLearningDate = dtStart;

            InProgress = Convert.ToBoolean(inProgress);

            // parsetaan merkkijonosta DateTime-muoto dtComplete
            DateTime.TryParseExact(completionDate, 
                "dd/MM/yyyy", 
                System.Globalization.CultureInfo.CreateSpecificCulture("fi-FI"),
                System.Globalization.DateTimeStyles.None, out DateTime dtComplete);
            CompletionDate = dtComplete;
        }


        // Tässä konstruktorissa lisätään topic CSV-tiedostoon, kun käyttäjä on syöttänyt aiheen.
        public Topic(string title)
        {
            Console.Clear();
            
            Title = title;

            //luodaan lista topiceista seuraavan ID:n määrittämistä varten, jos tiedosto on olemassa.
            if (File.Exists(path))
            {
                List<Topic> topics = CreateTopicList();
                // jos topics-lista ei ole tyhjä...
                if (topics.Count != 0)
                {
                    //...haetaan suurin topic.Id-arvo ja lisätään siihen 1, jotta saadaan luotavan Topicin ID
                    Id = topics.Max(topic => topic.Id) + 1;
                }
                //jos topics-lista on tyhjä, annetaan ID:ksi 1.
                else
                {
                    Id = 1;
                }
            }
            //jos tiedostoa ei ole olemassa, annetaan ID:ksi 1.
            else
            {
                Id = 1;
            }

            //StartLearningDaten määritys
            StartLearningDate = DateTime.Now;

            Description = "";
            EstimatedTimeToMaster = 0;
            TimeSpent = 0;
            InProgress = true;
            Source = "";

            //luodaan string array, yhdistetään string arrayn osat merkkijonoksi erotettuna pilkulla ja lisätään se csv-tiedostoon
            string[] stringsToAppend = new string[] { 
                this.Id.ToString(), 
                this.Title, 
                this.StartLearningDate.ToString(), 
                this.Description, 
                this.EstimatedTimeToMaster.ToString(), 
                this.TimeSpent.ToString(), 
                this.InProgress.ToString(), 
                this.Source,
                ""};//viimeinen "" on CompletionDate, joka ei saa vielä arvoa
            string stringToAppend = String.Join(",", stringsToAppend);//luodaan string arraystä merkkijono, jonka osaset on eroteltu pilkuilla
            File.AppendAllText(path, stringToAppend + Environment.NewLine);//lisätään edellisellä rivillä luotu merkkijono CSV-tiedostoon

            //testataan, että tallentunut tiedostoon - tulostetaan tiedoston kaikki rivit
            if (File.Exists(path))
            {
                foreach (string line in File.ReadLines(path))
                    Console.WriteLine("Tiedostosta tulostettu: " + line);
            }
        }


        //Metodi luo listan Topic-olioista muiden metodien käyttöä varten.
        private static List<Topic> CreateTopicList()
        {
            List<Topic> topics = new List<Topic>();
            if (File.Exists(path))
            {
                foreach (string line in File.ReadLines(path))
                {
                    string[] singleLine = line.Split(',');
                    topics.Add(new Topic(singleLine[0], singleLine[1], singleLine[2], singleLine[3], singleLine[4], singleLine[5], singleLine[6], singleLine[7], singleLine[8]));
                }
            }
            else
            {
                Console.WriteLine("\nEt ole luonut vielä yhtään aihetta!");
                Console.Write("Jatka painamalla jotakin näppäintä. ");
                Console.ReadLine();
            }
            return topics;
        }

        //tulostaa kaikki aiheet ja niiden ID:t suoraan CSV:stä
        /*public static void PrintAllTopics()
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
                        Console.ForegroundColor = ConsoleColor.DarkGray;
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

        }*/


        //PrintAllTopics()-metodi Linqiä käyttäen
        public static bool PrintAllTopics()
        {
            Console.Clear();
            List<Topic> topics = CreateTopicList();
            
            if (topics.Count == 0)
            {
                Console.WriteLine("Yhtään aihetta ei ole lisättynä!");
                return false;
            }
            else
            {
                    var results = topics.Select(topic => "Tunniste: " + topic.Id.ToString() + " " + topic.Title);
                    foreach (string line in results)
                    {
                        Console.WriteLine(line);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.ResetColor();
                    }
                    return true;

            }
        }


        //metodi tulostaa parametrina saadun ID:n mukaisen aiheen kaikki tiedot
        public static void PrintAllProperties(int idOfChosenTopic)
        {
            foreach (string line in File.ReadLines(path))
            {
                string[] singleLine = line.Split(',');
                if (idOfChosenTopic.ToString() == singleLine[0])//lines[0] = In
                {
                    Console.WriteLine("Aihe: " + singleLine[1] +
                        " (tunniste: " + singleLine[0] + ")" +
                        "\nAloitusaika: " + singleLine[2] +
                        "\nKuvaus: " + singleLine[3] +
                        "\nOpiskeluun kuluva aika (h): " + singleLine[4].Replace('.', ',') + //vaihtaa suomalaisen desimaalierottimen
                        "\nOpiskeluun käytetty aika (h): " + singleLine[5].Replace('.', '.'));//vaihtaa suomalaisen desimaalierottimen
                    Console.WriteLine("Aiheen oppiminen kesken: " + ((singleLine[6].ToLower() == "true") ? "Kyllä" : "Ei"));
                    Console.WriteLine("Lähde: " + singleLine[7]);
                    Console.WriteLine("Opiskelu loppunut: " + singleLine[8]);
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
            "\n2) Kuvaus" +
            "\n3) Asian opiskeluun kuluva aika" +
            "\n4) Asian opiskeluun käytetty aika" +
            "\n5) Lähde (esim. kirja tai URL)" +
            "\n6) Aseta aihe opiskelluksi" +
            "\n7) Poista aihe");
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

                    EditPropertyInCSV(idOfChosenTopic, 1, newProperty);//title on CSV:ssä indeksissä 1
                    break;

                case 2:
                    Console.Write("Syötä aiheelle uusi kuvaus: ");
                    string newDescription = Console.ReadLine();
                    EditPropertyInCSV(idOfChosenTopic, 3, newDescription);//description on CSV:ssä indeksissä 3
                    break;

                case 3:
                    Console.Write("Montako tuntia aiheen opetteluun kuluu? ");
                    string estimatedTimeToMaster = Console.ReadLine();
                    EditPropertyInCSV(idOfChosenTopic, 4, estimatedTimeToMaster);//EstimatedTimeToMaster on CSV:ssä indeksissä 4
                    break;

                case 4://TimeSpent
                    Console.Write("Montako tuntia olet opiskellut aihetta? ");
                    string timeSpent = Console.ReadLine();
                    EditPropertyInCSV(idOfChosenTopic, 5, timeSpent);//TimeSpent on CSV:ssä indeksissä 5
                    break;

                case 5://string Source
                    Console.Write("Kirjoita opiskelussa käyttämäsi lähteet (kirja ja/tai nettisivu): ");
                    string Source = Console.ReadLine();
                    EditPropertyInCSV(idOfChosenTopic, 7, Source);//Source on CSV:ssä indeksissä 7
                    break;

                case 6://CompletionDate

                    EditPropertyInCSV(idOfChosenTopic, 8, DateTime.Today.ToString("dd.MM.yyyy"));//CompletionDate on CSV:ssä indeksissä 8
                    EditPropertyInCSV(idOfChosenTopic, 6, false.ToString());//muuttaa InProgress = false indeksiin 6;
                    break;

                case 7://Poistaa aiheen
                    DeleteTopic(idOfChosenTopic);
                    break;

                default:
                    Console.WriteLine("Valitse toiminto numeroilla 1-7!");//
                    break;
            }

        }

        //metodi muuttaa parametrina saadun ID-numeron, aiheen ja saadun uuden attribuutin mukaisesti CSV-tiedostoa
        private static void EditPropertyInCSV(int idOfChosenTopic, int indexOfPropertyToSet, string newProperty)
        {
            List<String> newLines = new List<String>();
            //käydään tiedoston rivit läpi
            foreach (string line in File.ReadLines(path))
            {
                string[] singleLine = line.Split(',');
                if (idOfChosenTopic.ToString() == singleLine[0])//lines[0] = In
                {
                    singleLine[indexOfPropertyToSet] = newProperty;//lines[1] = Title, lines[3] = Description
                }
                newLines.Add(String.Join(',', singleLine));//lisää loopissa kunkin rivin string arrayn osaset listaan eroteltuina pilkulla.
            }
            File.Create(path).Close();//tyhjentää listan ennen kuin uusi sisältö lisätään
            foreach (string line in newLines)
            {
                File.AppendAllText(path, line + Environment.NewLine);
            }
        }


        //Poistaa CSV-tiedostosta käyttäjän haluaman aiheen tunnisteen perusteella
        private static void DeleteTopic(int idOfChosenTopic)
        {
            List<string> afterDeleting = new List<string>();

            foreach (string line in File.ReadLines(path))
            {
                string[] singleLine = line.Split(',');
                //Jos CSV:stä saatu tunniste on sama kuin tunniste, jonka käyttäjä haluaa poistettavaksi, ei mennä loopissa eteenpäin lisäämään ko. riviä afterDeleting-listalle.
                if (idOfChosenTopic.ToString() == singleLine[0])
                {
                    continue;
                }
                afterDeleting.Add(String.Join(',', singleLine));
            }
            File.Create(path).Close();//kirjoittaa aiemman tiedoston päälle tyhjän tiedoston
            File.AppendAllLines(path, afterDeleting);//täsä eri lisäyskoodi kuin ylempänä
            Console.WriteLine("\nPoistit aiheen tunnisteella {0}.", idOfChosenTopic);

        }


        //Metodi tekee käyttäjän syötteen mukaisen haun 
        public static void SearchForTopic(string searchObject)
        {
            
            Dictionary<int, string> topicsDict = CreateDictionaryFromCSV();//kutsutaan sanakirjan luovaa ja palauttavaa metodia
            
            //jos saadussa sanakirjassa ei ole yhtään aihetta, tulostetaan käyttäjälle ilmoitus ja lopetetaan tämän metodin suorittaminen
            if (topicsDict.Count == 0)
            {
                Console.WriteLine("Et ole vielä lisännyt yhtään aihetta!");
                return;
            }

            if (Int32.TryParse(searchObject, out int searchObjectNumber) == true)
                {
                    //etsitään numerolla, jos käyttäjän syöte on numero
                    if (topicsDict.ContainsKey(searchObjectNumber))
                    {
                        Console.WriteLine("Löytyi! Tunnisteella {0} etsimäsi aihe on {1}.", searchObjectNumber, topicsDict[searchObjectNumber]);
                    }
                    else
                    {
                        Console.WriteLine("Tunnisteella {0} ei löytynyt aihetta.", searchObjectNumber);
                    }
                }

                else
                {
                    //etsitään aiheella tai sen osalla, jos käyttäjän syöte ei ollut numero. Haku ei ole merkkikokoriippuvainen (toLower)
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
                    //jos topicsFound.Count ei ole 0, suoritetaan topicsFound.Countin mukainen switch/case-koodilohko
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
            catch
            {
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
