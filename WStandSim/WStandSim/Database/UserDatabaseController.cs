using SQLite;
using System;
using System.Linq;
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
            database.DropTable<DayCount>();
            database.DropTable<ItemProperties>();
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
            database.CreateTable<DayCount>();
            database.CreateTable<ItemProperties>();
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

        // Ein - und Verkaufspreise für die Artikel einfügen
        public void AddItemPrice(ItemProperties itemprice)
        {
            database.Insert(itemprice);
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
            // Rückgabe der SeasonTempRangeID für Berechnung der ItemSalesQuota
            int seasonTempRangeID = database.Table<SeasonTempRange>().FirstOrDefault(item => item.SeasonId == seasonID && item.TempFrom <= seasonTemperature && item.TempTo >= seasonTemperature).Id;
            // Rückgabe der aktuellen Jahreszeit
            string seasonText = database.Table<Seasons>().FirstOrDefault(item => item.Id == seasonID).SeasonsText;

            // neues Objekt aus den errechneten Werten erzeugen
            Weather newWeather = new Weather(day, seasonID, tempFrom, tempTo, seasonTemperature, weatherText, tempLow, tempHigh, seasonText, seasonTempRangeID);
            // und abspeichern
            AddWeather(newWeather);
        }

        // Wettervorhersage aus Tabelle Weather
        public string WeatherForecast()
        {
            var w = database.Table<Weather>().ElementAt(0);
            return $"{w.WeatherText}\nTageshöchsttemperatur {w.TempHigh} Grad\nJahreszeit: {w.SeasonText}\nTag:{w.Day}";
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

            // Update der gesamten Spielzeit für Ablaufdatumsberechnung

            // aktuell gespielten Tage aus der Db holen
            int actualDay = database.Table<DayCount>().FirstOrDefault().ActualDay;
            // inkrementieren
            actualDay++;
            // aktuellen Datensatz löschen
            database.Execute("DELETE FROM DayCount");
            // neues Objekt erzeugen
            DayCount d = new DayCount(1, actualDay);
            // und abspeichern
            SaveDay(d);
        }

        // Vermerken, dass ein Spiel begonnen wurde
        public void SetGameIsSaved()
        {
            database.Execute("UPDATE GameSaved SET IsGameSaved = ?", true);
        }

        // Gesamte Spieltage
        public void SaveDay(DayCount dayCount)
        {
            database.Insert(dayCount);
            database.Commit();
        }

        //Artikel speichern => Einkauf
        public void SaveItemsToDB(int itemAmount, double price, int itemTypeID, int daysToExpire)
        {
            // Würste einfügen
            if (itemTypeID == 1)
                for (int i = 0; i < itemAmount; i++)
                {
                    database.Execute("INSERT INTO StoredItems (Bestbefore, ItemTypeID) VALUES (?, ?)", daysToExpire, itemTypeID);
                    database.Execute("UPDATE Finance SET Amount=Amount-? where AssetLabel = 'currentBalance'", price);
                }

            // Brot einfügen
            if (itemTypeID == 2)
                for (int i = 0; i < itemAmount; i++)
                {
                    database.Execute("INSERT INTO StoredItems (Bestbefore, ItemTypeID) VALUES (?, ?)", daysToExpire, itemTypeID);
                    database.Execute("UPDATE Finance SET Amount=Amount-? where AssetLabel = 'currentBalance'", price);
                }

            // Bier einfügen
            if (itemTypeID == 3)
                for (int i = 0; i < itemAmount; i++)
                {
                    database.Execute("INSERT INTO StoredItems (Bestbefore, ItemTypeID) VALUES (?, ?)", daysToExpire, itemTypeID);
                    database.Execute("UPDATE Finance SET Amount=Amount-? where AssetLabel = 'currentBalance'", price);
                }

            // Limonade einfügen
            if (itemTypeID == 4)
                for (int i = 0; i < itemAmount; i++)
                {
                    database.Execute("INSERT INTO StoredItems (Bestbefore, ItemTypeID) VALUES (?, ?)", daysToExpire, itemTypeID);
                    database.Execute("UPDATE Finance SET Amount=Amount-? where AssetLabel = 'currentBalance'", price);
                }
        }

        // Aktuellen Kontostand abrufen
        public double SelectCurrentBalance()
        {
            double c = database.Table<Finance>().Where(a => a.AssetLabel == "currentBalance").FirstOrDefault().Amount;
            return c;
        }

        // Einnahmen abrufen
        public double SelectReceiptsYesterday()
        {
            double r = database.Table<Finance>().Where(a => a.AssetLabel == "receiptsYesterday").FirstOrDefault().Amount;
            return r;
        }

        // Ausgaben abrufen
        public double SelectExpendituresYesterday()
        {
            double e = database.Table<Finance>().Where(a => a.AssetLabel == "expendituresYesterday").FirstOrDefault().Amount;
            return e;
        }

        // Aktuellen Tag zurückgeben
        public int SelectActualDay()
        {
            int actualDay = database.Table<DayCount>().FirstOrDefault().ActualDay;
            return actualDay;
        }

        // Aktuelle SeasonTempRange auswerten
        public int SelectSeasonTempRange()
        {
            int seasonTempRangeID = database.Table<Weather>().FirstOrDefault().SeasonTempRangeID;
            return seasonTempRangeID;
        }

        // ItemSalesQuotaID für die entsprechende SeasonTempRang und den entsprechenden Artikel zurückgeben
        public int SelectItemSalesQuotaID(int seasonTempRangeID, int itemTypeID)
        {
            int itemSalesQuotaID = database.Table<ItemSalesQuota>().FirstOrDefault(item => item.SeasonTempRangeId == seasonTempRangeID && item.ItemTypeId == itemTypeID).Id;
            return itemSalesQuotaID;
        }

        // Selektieren der beiden Verkaufsquoten
        public void SelectItemSalesQuota(int itemSalesQuotaID, out int salesQuotaFrom, out int salesQuotaTo)
        {
            salesQuotaFrom = database.Table<ItemSalesQuota>().FirstOrDefault(item => item.Id == itemSalesQuotaID).SalesQuotaFrom;
            salesQuotaTo = database.Table<ItemSalesQuota>().FirstOrDefault(item => item.Id == itemSalesQuotaID).SalesQuotaTo;
        }

        // Selektieren der Anzahl der jeweiligen Artikel
        public void SelectAmountPerItem(out int sausagesNumber, out int breadNumber, out int beerNumber, out int lemonadesNumber)
        {
            sausagesNumber = database.Table<StoredItems>().Count(item => item.ItemTypeId == 1);
            breadNumber = database.Table<StoredItems>().Count(item => item.ItemTypeId == 2);
            beerNumber = database.Table<StoredItems>().Count(item => item.ItemTypeId == 3);
            lemonadesNumber = database.Table<StoredItems>().Count(item => item.ItemTypeId == 4);
        }

        // Ein - und Verkaufspreis eines bestimmten Artikels abrufen
        public void SelectItemPrices(int itemTypeID, out double purchasingPrice, out double retailPrice, out int daysToExpire)
        {
            purchasingPrice = database.Table<ItemProperties>().FirstOrDefault(item => item.Id == itemTypeID).PurchasingPrice;
            retailPrice = database.Table<ItemProperties>().FirstOrDefault(item => item.Id == itemTypeID).RetailPrice;
            daysToExpire = database.Table<ItemProperties>().FirstOrDefault(item => item.Id == itemTypeID).DaysToExpire;
        }

        // Verkäufe aus der DB löschen und Betrag zum Kontostand hinzufügen => Verkauf
        public void DeleteItemsFromDBAndAddToBalance(int amount, int itemTypeID)
        {
            if (amount > 0)
            {
                // Löschen der jeweiligen Anzahl des jeweiligen Artikels
                var listToRemove = (from a in database.Table<StoredItems>() where a.ItemTypeId.Equals(itemTypeID) orderby a.Bestbefore descending select a).Take(amount).ToList();
                foreach (var item in listToRemove)
                {
                    database.Delete(item);
                }

                // Aufruf der Methode für die Verkaufspreise
                SelectItemPrices(itemTypeID, out double purchasingPrice, out double retailPrice, out int daysToExpire);

                // Selektieren des aktuellen Kontostandes
                double currBal = SelectCurrentBalance();

                // Verkäufe des übergebenen Items zum Kontostand zählen
                double newCurrentBalance = (amount * retailPrice) + currBal;

                // und in der Datenbank überschreiben
                database.Execute("UPDATE Finance SET Amount = ? where AssetLabel = 'currentBalance'", newCurrentBalance);

                // Selektieren der aktuellen Einnahmen gestern
                double recYest = SelectReceiptsYesterday();

                // Verkäufe als "Einnahmen gestern" in Variable speichern
                double receiptsYesterday = (amount * retailPrice) + recYest;

                // und überschreiben
                database.Execute("UPDATE Finance SET Amount = ? where AssetLabel = 'receiptsYesterday'", receiptsYesterday);
            }
        }
    }
}
