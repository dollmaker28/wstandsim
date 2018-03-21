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
            // aktuellen Tag holen für Ablaufdatum
            int actualDay = db.SelectActualDay();

            // Artikel speichern und zurücksetzen
            // Wurst
            if(Sausages > 0)
            {
            db.SaveItemsToDB(Sausages, actualDay, 3.70, 1);
            Sausages = 0;
            }
            // Brot
            if(Bread > 0)
            {
            db.SaveItemsToDB(Bread, actualDay, 0.50, 2);
            Bread = 0;
            }
            // Bier
            if(Beer > 0)
            {
            db.SaveItemsToDB(Beer, actualDay, 2.50, 3);
            Beer = 0;
            }
            // Limonade
            if(Lemonades > 0)
            {
            db.SaveItemsToDB(Lemonades, actualDay, 1.20, 4);
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
            get { currentBalance = db.SelectCurrentBalance();  return this.currentBalance; } 
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
