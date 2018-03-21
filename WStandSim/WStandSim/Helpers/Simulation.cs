using System;
using System.Collections.Generic;
using System.Text;
using WStandSim.Database;
using System.ComponentModel;

namespace WStandSim.Helpers
{
    // Klasse für die Simulation des gesamten Tages
    class Simulation : DBBase
    {
        // Instanzierung des DB-Controllers
        UserDatabaseController db = new UserDatabaseController();

        // Berechnung der Jahreszeit für den kommenden Tag
        public void SimulateNewDayAndSeason()
        {
            db.SetCurrentDayAndSeasonNewDay();
            NotifyPropertyChanged("ReturnWeather");
        }

        // Wetter neu berechnen lassen
        public void CalculateNewWeather()
        {
            db.CalculateCurrentDayWeather();
            NotifyPropertyChanged("ReturnWeather");
        }

        // Ausgabe der Wettervorhersage
        public string ReturnWeather { get { return db.WeatherForecast(); } }

        // Properties für die Zähler auf der Verkaufsseite
        #region PropsArtikel
        // Variablen
        public int sausages, bread, beer, lemonades;
        // Properties
        public int Sausages
        { get { return sausages; } set { sausages = value; NotifyPropertyChanged(); } }
        public int Bread
        { get { return bread; } set { bread = value; NotifyPropertyChanged(); } }
        public int Beer
        { get { return beer; } set { beer = value; NotifyPropertyChanged(); } }
        public int Lemonades
        { get { return lemonades; } set { lemonades = value; NotifyPropertyChanged(); } }
        #endregion

        // Methode zum Erhöhen und Reduzieren der Artikel auf der Verkaufsseite
        #region RaiseLower

        // Methoden zum Erhöhen und Verringern der Werte
        public void Raise(string item)
        {
            switch (item)
            {
                case "sausage":
                    int a = sausages;
                    Sausages = a + 1;
                    break;
                case "bread":
                    int b = bread;
                    Bread = b + 1;
                    break;
                case "beer":
                    int c = beer;
                    Beer = c + 1;
                    break;
                case "lemonade":
                    int d = lemonades;
                    Lemonades = d + 1;
                    break;
                default:
                    int z = 0;
                    break;
            }
        }

        public void Lower(string item)
        {
            switch (item)
            {
                case "sausage":
                    int a = sausages;
                    if (a == 0) { } else Sausages = a - 1;
                    break;
                case "bread":
                    int b = bread;
                    if (b == 0) { } else Bread = b - 1;
                    break;
                case "beer":
                    int c = beer;
                    if (c == 0) { } else Beer = c - 1;
                    break;
                case "lemonade":
                    int d = lemonades;
                    if (d == 0) { } else Lemonades = d - 1;
                    break;
                default:
                    int z = 0;
                    break;
            }
        }
        // Wurst

        #region AlteMethoden (zum löschen)
        public void RaiseSausages()
        {
            int a = sausages;
            Sausages = a + 1;
        }
        public void LowerSausages()
        {
            int a = sausages;
            if (a == 0) { } else Sausages = a - 1;
        }
        // Brot
        public void RaiseBread()
        {
            int a = bread;
            Bread = a + 1;
        }
        public void LowerBread()
        {
            int a = bread;
            if (a == 0) { } else Bread = a - 1;
        }
        // Bier
        public void RaiseBeer()
        {
            int a = beer;
            Beer = a + 1;
        }
        public void LowerBeer()
        {
            int a = beer;
            if (a == 0) { } else Beer = a - 1;
        }
        // Limonade
        public void RaiseLemonades()
        {
            int a = lemonades;
            Lemonades = a + 1;
        }
        public void Loweremonades()
        {
            int a = lemonades;
            if (a == 0) { } else Lemonades = a - 1;
        }
        #endregion

        #endregion

        //Kaufen
        public void Buy()
        {
            // aktuellen Tag holen für Berechnung des engültigen Ablauftages eines Artikel
            int actualDay = db.SelectActualDay();

            // Artikel speichern und zurücksetzen
            // Wurst
            if (Sausages > 0)
            {
                // Tage bis zum Ablauf des Produkts aus der DB holen
                db.SelectItemPrices(1, out double purchasingPrice, out double retailPrice, out int daysToExpire);
                int expiryDay = actualDay + daysToExpire;

                // Werte an Methode übergeben
                db.SaveItemsToDB(Sausages, purchasingPrice, 1, daysToExpire);
                Sausages = 0;
            }
            // Brot
            if (Bread > 0)
            {
                // Tage bis zum Ablauf des Produkts aus der DB holen
                db.SelectItemPrices(1, out double purchasingPrice, out double retailPrice, out int daysToExpire);
                int expiryDay = actualDay + daysToExpire;

                // Werte an Methode übergeben
                db.SaveItemsToDB(Bread, purchasingPrice, 2, daysToExpire);
                Bread = 0;
            }
            // Bier
            if (Beer > 0)
            {
                // Tage bis zum Ablauf des Produkts aus der DB holen
                db.SelectItemPrices(1, out double purchasingPrice, out double retailPrice, out int daysToExpire);
                int expiryDay = actualDay + daysToExpire;

                // Werte an Methode übergeben
                db.SaveItemsToDB(Beer, purchasingPrice, 3, daysToExpire);
                Beer = 0;
            }
            // Limonade
            if (Lemonades > 0)
            {
                // Tage bis zum Ablauf des Produkts aus der DB holen
                db.SelectItemPrices(1, out double purchasingPrice, out double retailPrice, out int daysToExpire);
                int expiryDay = actualDay + daysToExpire;

                // Werte an Methode übergeben
                db.SaveItemsToDB(Lemonades, purchasingPrice, 4, daysToExpire);
                Lemonades = 0;
            }

            // Currentbalance aktualisieren
            CurrentBalance = db.SelectCurrentBalance();
        }

        // Verkaufen
        public void Sell()
        {
            // Aufruf der Methode GetCalcQuotes für den zu verkaufenden Prozentwert
            GetCalcQuotes(out int sausageCalcQuote, out int breadCalcQuote, out int beerCalcQuote, out int lemonadeCalcQuote);

            // Selektieren der gespeicherten Artikel pro Typ
            db.SelectAmountPerItem(out int sausagesNumber, out int breadNumber, out int beerNumber, out int lemonadesNumber);

            // Anzahl der zu verkaufenden / zu löschenden Artikel errechnen
            // Wurst
            int soldSausages = sausageCalcQuote * sausagesNumber / 100;
            // Brot
            int soldBread = breadCalcQuote * breadNumber / 100;
            // Bier
            int soldBeer = beerCalcQuote * beerNumber / 100;
            // Limonade
            int soldLemonades = lemonadeCalcQuote * lemonadesNumber / 100;

            // Würste löschen/verkaufen und zum Kontostand hinzufügen
            db.DeleteItemsFromDBAndAddToBalance(soldSausages, 1);
            // Brote löschen/verkaufen und zum Kontostand hinzufügen
            db.DeleteItemsFromDBAndAddToBalance(soldBread, 2);
            // Bier löschen/verkaufen und zum Kontostand hinzufügen
            db.DeleteItemsFromDBAndAddToBalance(soldBeer, 3);
            // Limonade löschen/verkaufen und zum Kontostand hinzufügen
            db.DeleteItemsFromDBAndAddToBalance(soldLemonades, 4);

            CurrentBalance = db.SelectCurrentBalance();
        }

        // Berechnen der akuellen Verkaufsquoten für die jeweiligen Artikel
        private void GetCalcQuotes(out int sausageCalcQuote, out int breadCalcQuote, out int beerCalcQuote, out int lemonadeCalcQuote)
        {
            // SeasonTempRangeID holen und merken
            int seasonTempRangeID = db.SelectSeasonTempRange();

            // die richtigen Datensätze für die Verkaufsquote aus der DB holen für alle Produkte
            int sausageSalesQuotaID = db.SelectItemSalesQuotaID(seasonTempRangeID, 1);
            int breadSalesQuotaID = db.SelectItemSalesQuotaID(seasonTempRangeID, 2);
            int beerSalesQuotaID = db.SelectItemSalesQuotaID(seasonTempRangeID, 3);
            int lemonadeSalesQuotaID = db.SelectItemSalesQuotaID(seasonTempRangeID, 4);

            // Die Quoten für die jeweiligen Produkte aus der DB holen
            db.SelectItemSalesQuota(sausageSalesQuotaID, out int sausageSalesQuotaFrom, out int sausageSalesQuotaTo);
            db.SelectItemSalesQuota(breadSalesQuotaID, out int breadSalesQuotaFrom, out int breadSalesQuotaTo);
            db.SelectItemSalesQuota(beerSalesQuotaID, out int beerSalesQuotaFrom, out int beerSalesQuotaTo);
            db.SelectItemSalesQuota(lemonadeSalesQuotaID, out int lemonadeSalesQuotaFrom, out int lemonadeSalesQuotaTo);

            // Randoms im jeweiligen Bereich berechnen
            Random rnd = new Random();
            sausageCalcQuote = rnd.Next(sausageSalesQuotaFrom, sausageSalesQuotaTo);
            breadCalcQuote = rnd.Next(breadSalesQuotaFrom, breadSalesQuotaTo);
            beerCalcQuote = rnd.Next(beerSalesQuotaFrom, beerSalesQuotaTo);
            lemonadeCalcQuote = rnd.Next(lemonadeSalesQuotaFrom, lemonadeSalesQuotaTo);
        }

        // Aktueller Kontostand => wird nach jedem Einkauf sowie nach der Simulation berechnet anhand der aktuellen Einnahmen
        private double currentBalance;
        // Property für aktuellen Kontostand
        public double CurrentBalance
        {
            get { currentBalance = db.SelectCurrentBalance(); return this.currentBalance; }
            set { if (this.currentBalance != value) { this.currentBalance = value; ; this.NotifyPropertyChanged("CurrentBalance"); } }
        }

        // Aktuelle Einnahmen => werden nach der Simulation berechnet anhand der verkauften Artikel
        private double receiptsYesterday;
        // Property für Einnahmen
        public double ReceiptsYesterday
        {
            get { receiptsYesterday = db.SelectReceiptsYesterday(); return this.receiptsYesterday; }
            set { if (this.receiptsYesterday != value) { this.receiptsYesterday = value; ; this.NotifyPropertyChanged("ReceiptsYesterday"); } }
        }

        // Aktuelle Ausgaben => werden nach der Simulation berechnet anhand der Einkäufe und der abgelaufenen Waren
        private double expendituresYesterday;
        // Property für Ausgaben
        public double ExpendituresYesterday
        {
            get { expendituresYesterday = db.SelectExpendituresYesterday(); return this.expendituresYesterday; }
            set { if (this.expendituresYesterday != value) { this.expendituresYesterday = value; ; this.NotifyPropertyChanged("ExpendituresYesterday"); } }
        }

    }
}
