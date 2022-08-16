using System;

namespace ClassLibraryExercise
{
    public class Class1
    {

        //Metodi kertoo opiskelun aloitusajan ja arvioidun opiskeluajan perusteella onko opiskelu myöhässä vai ei
        public static bool OnkoAjoissa(DateTime aloitusaika, double arvioituOpiskeluaika)
        {
            double verrokki = 0;
            
            if (aloitusaika.Date == DateTime.Now.Date)
            {
                //ei käytetä TimeSpania
                verrokki = DateTime.Now.Hour - aloitusaika.Hour;
            }

            else
            {
                //käytetään timespania
                TimeSpan kulunutAika = DateTime.Now - aloitusaika;
                verrokki = kulunutAika.TotalHours;
            }
            
            if (verrokki < arvioituOpiskeluaika)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        //Metodi palauttaa true jos päivämäärä on tulevaisuudessa ja false mikäli päivämäärä on menneisyydessä
        public static bool OnkoTulevaisuudesta(DateTime paiva)
        {
         if (paiva>DateTime.Now)
            {
                return true;
            }
         else if (paiva < DateTime.Now)
            {
                return false;
            }
         else
            {
                return false;
            }
        }


    }
}
