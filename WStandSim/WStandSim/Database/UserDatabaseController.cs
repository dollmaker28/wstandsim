using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WStandSim.Models;
using Xamarin.Forms;

namespace WStandSim.Database
{
    public class UserDatabaseController
    {

        static object locker = new object();

        SQLiteConnection database;

        // DB-Verbindung aufbauen
        public UserDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
        }

        public void DropTables()
        {
            database.DropTable<StoredItems>();
            database.DropTable<ItemType>();
            database.DropTable<ItemSalesQuota>();
            database.DropTable<Finance>();
            database.DropTable<Weather>();
            database.DropTable<Seasons>();
            database.DropTable<SeasonTempRange>();
            database.DropTable<GameSaved>();
            database.DropTable<SeasonDays>();
        }

        // Erstellen der Tabellen
        public void CreateTables()
        {
            database.CreateTable<StoredItems>();
            database.CreateTable<ItemType>();
            database.CreateTable<ItemSalesQuota>();
            database.CreateTable<Finance>();
            database.CreateTable<Weather>();
            database.CreateTable<Seasons>();
            database.CreateTable<SeasonTempRange>();
            database.CreateTable<GameSaved>();
            database.CreateTable<SeasonDays>();
        }

        // Finanzen einfügen
        public void AddFinance(Finance finance)
        {
            database.Insert(finance);
            database.Commit();
        }

        // Jahreszeiten einfügen
        public void AddSeason(Seasons season)
        {
            database.Insert(season);
            database.Commit();
        }

        // Jahreszeit-Temperaturbereiche einfügen
        public void AddSeasonTempRange(SeasonTempRange seasonTempRange)
        {
            database.Insert(seasonTempRange);
            database.Commit();
        }

        // Artikel zum Verlauf einfügen
        public void AddItemType(ItemType itemType)
        {
            database.Insert(itemType);
            database.Commit();
        }

        // Verkaufsquote für die jeweiligen Artikel einfügen
        public void AddItemSalesQuota(ItemSalesQuota itemSalesQuota)
        {
            database.Insert(itemSalesQuota);
            database.Commit();
        }

        // Jahreszeit und Tag einfügen
        public void AddSeasonDays(SeasonDays season)
        {
            database.Insert(season);
            database.Commit();
        }

        // Wetter für morgen einfügen und merken
        public void AddWeather(Weather weather)
        {
            database.Insert(weather);
            database.Commit();
        }

        // Wetter für kommenden Tag berechnen und speichern
        public void CalculateCurrentDayWeather()
        {
            // aktuelles Wetter löschen und neu berechnen
            database.Execute("DELETE FROM Weather");
            // Befüllen der Variablen
            int day = database.Table<SeasonDays>().FirstOrDefault().DaysInSeason;
            int seasonID = database.Table<SeasonDays>().FirstOrDefault().CurrentSeasonID;
            int tempFrom = database.Table<Seasons>().FirstOrDefault(item => item.Id == seasonID).TempFrom;
            int tempTo = database.Table<Seasons>().FirstOrDefault(item => item.Id == seasonID).TempTo;

            // Random für Wetterberechnung anhand der aktuellen Jahreszeit
            Random rnd = new Random();
            int seasonTemperature = rnd.Next(tempFrom, tempTo);

            // Rückgabe der Wettervorhersage
            string weatherText = database.Table<SeasonTempRange>().FirstOrDefault(item => item.SeasonId == seasonID && item.TempFrom <= seasonTemperature && item.TempTo >= seasonTemperature).SeasonTempRangeWeatherText;
            // Rückgabe der Tagestiefsttemperatur
            int tempLow = database.Table<SeasonTempRange>().FirstOrDefault(item => item.SeasonId == seasonID && item.TempFrom <= seasonTemperature && item.TempTo >= seasonTemperature).TempFrom;
            // Rückgabe der Tageshöchsttemperatur
            int tempHigh = database.Table<SeasonTempRange>().FirstOrDefault(item => item.SeasonId == seasonID && item.TempFrom <= seasonTemperature && item.TempTo >= seasonTemperature).TempTo;
            // Rückgabe der aktuellen Jahreszeit
            string seasonText = database.Table<Seasons>().FirstOrDefault(item => item.Id == seasonID).SeasonsText;

            // neues Objekt aus den errechneten Werten erzeugen
            Weather newWeather = new Weather(day, seasonID, tempFrom, tempTo, seasonTemperature, weatherText, tempLow, tempHigh, seasonText);
            // und abspeichern
            AddWeather(newWeather);
            //return $"Wettervorhersage: {weatherText}, aktuelle Jahreszeit: {seasonText}, aktueller Tag: {day}, Tageshöchstemperatur: {tempHigh}, Tagestiefsttemperatur: {tempLow}";
        }

        // Wettervorhersage aus Tabelle Weather
        public string WeatherForecast()
        {
            var w = database.Table<Weather>().ElementAt(0);
            return $"{w.WeeatherText}, TagHöTemp:{w.TempHigh}, TagNiedTemp:{w.TempLow}, {w.SeasonText}, STemp:{w.SeasonTemperature}, Tag:{w.Day}";
        }

        // Tag und Jahreszeit nach vorne setzen
        public void SetCurrentDayAndSeasonNewDay()
        {
            // Daten aus Tabelle lesen
            int seasonID = database.Table<SeasonDays>().FirstOrDefault().CurrentSeasonID;
            int daysInSeason = database.Table<SeasonDays>().FirstOrDefault().DaysInSeason;

            // Abfrage und Update
            // Wenn Frühling, Sommer oder Herbst und 20 Tage noch nicht erreicht sind
            if (daysInSeason < 20)
            {
                // ein Tag dazu
                database.Execute("UPDATE SeasonDays SET DaysInSeason = DaysInSeason + ?", 1);
            }
            // Wenn der 20. Tag erreicht ist
            else if (daysInSeason == 20)
            {
                int newSeasonID;
                // Abfrage auf die aktuelle Jahreszeit
                switch (seasonID)
                {
                    case 1:
                        newSeasonID = 2;
                        break;
                    case 2:
                        newSeasonID = 3;
                        break;
                    case 3:
                        newSeasonID = 4;
                        break;
                    case 4:
                        newSeasonID = 1;
                        break;
                    default:
                        newSeasonID = 1;
                        break;
                }

                // Tag auf 1 zurücksetzen
                database.Execute("UPDATE SeasonDays SET DaysInSeason = ?", 1);
                // eine Jahreszeit dazu
                database.Execute("UPDATE SeasonDays SET CurrentSeasonID = ?", newSeasonID);
            }
        }

        // Vermerken, dass ein Spiel begonnen wurde
        public void SetGameIsSaved()
        {
            database.Execute("UPDATE GameSaved SET IsGameSaved = ?", true);
        }
    }
}
