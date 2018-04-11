using System;
using WStandSim.Database;

namespace WStandSim.Helpers
{
    // Klasse für die Simulation des gesamten Tages
    class Simulation : DBBase
    {
        // Instanzierung des DB-Controllers
        UserDatabaseController db = new UserDatabaseController();

        // Konstruktor
        public Simulation()
        {
            this.CurrentBalance = db.SelectCurrentBalance();
            this.expendituresYesterday = db.SelectExpendituresYesterday();
            this.receiptsYesterday = db.SelectReceiptsYesterday();
        }

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
            // WICHTIG!!! Hier ist der erste Punkt nach dem Kauf, zu dem die RICHTIGE ID der Artikels benötigt wird.
            // Hier muss unbedingt die richtige ID rein und mit der ID des Artikels in der Tabelle ItemType übereinstimmen!!!
            int sausageID = 1, breadID = 2, beerID = 3, lemonadeID = 4;

            // aktuellen Tag holen für Berechnung des engültigen Ablauftages eines Artikel
            int actualDay = db.SelectActualDay();

            // Artikel speichern und zurücksetzen
            // Wurst
            if (Sausages > 0)
            {
                // Tage bis zum Ablauf des Produkts aus der DB holen
                db.SelectItemPrices(sausageID, out double purchasingPrice, out double retailPrice, out int daysToExpire);
                int expiryDay = actualDay + daysToExpire;

                // Werte an Methode übergeben
                db.SaveItemsToDB(Sausages, purchasingPrice, sausageID, daysToExpire);
                Sausages = 0;
            }
            // Brot
            if (Bread > 0)
            {
                // Tage bis zum Ablauf des Produkts aus der DB holen
                db.SelectItemPrices(breadID, out double purchasingPrice, out double retailPrice, out int daysToExpire);
                int expiryDay = actualDay + daysToExpire;

                // Werte an Methode übergeben
                db.SaveItemsToDB(Bread, purchasingPrice, breadID, daysToExpire);
                Bread = 0;
            }
            // Bier
            if (Beer > 0)
            {
                // Tage bis zum Ablauf des Produkts aus der DB holen
                db.SelectItemPrices(beerID, out double purchasingPrice, out double retailPrice, out int daysToExpire);
                int expiryDay = actualDay + daysToExpire;

                // Werte an Methode übergeben
                db.SaveItemsToDB(Beer, purchasingPrice, beerID, daysToExpire);
                Beer = 0;
            }
            // Limonade
            if (Lemonades > 0)
            {
                // Tage bis zum Ablauf des Produkts aus der DB holen
                db.SelectItemPrices(lemonadeID, out double purchasingPrice, out double retailPrice, out int daysToExpire);
                int expiryDay = actualDay + daysToExpire;

                // Werte an Methode übergeben
                db.SaveItemsToDB(Lemonades, purchasingPrice, lemonadeID, daysToExpire);
                Lemonades = 0;
            }

            // Currentbalance aktualisieren
            CurrentBalance = db.SelectCurrentBalance();
            // Einnahmen gestern aktualisieren
            ReceiptsYesterday = db.SelectReceiptsYesterday();
            // Lagerstand aktualisieren
            SetAmountPerItem();
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
            if (soldSausages < 1 && sausagesNumber > 0) { soldSausages = 1; } else if (soldSausages >= 1) { soldSausages = sausageCalcQuote * sausagesNumber / 100; };
            // Brot
            int soldBread = breadCalcQuote * breadNumber / 100;
            if (soldBread < 1 && breadNumber > 0) { soldBread = 1; } else if (soldBread >= 1) { soldBread = breadCalcQuote * breadNumber / 100; };
            // Bier
            int soldBeer = beerCalcQuote * beerNumber / 100;
            if (soldBeer < 1 && beerNumber > 0) { soldBeer = 1; } else if (soldBeer >= 1) { soldBeer = beerCalcQuote * beerNumber / 100; };
            // Limonade
            int soldLemonades = lemonadeCalcQuote * lemonadesNumber / 100;
            if (soldLemonades < 1 && lemonadesNumber > 0) { soldLemonades = 1; } else if (soldLemonades >= 1) { soldLemonades = lemonadeCalcQuote * lemonadesNumber / 100; };

            // Würste löschen/verkaufen und zum Kontostand hinzufügen
            if(sausagesNumber > 0) { db.DeleteItemsFromDBAndAddToBalance(soldSausages, 1); CurrentBalance = db.SelectCurrentBalance(); }
            // Brote löschen/verkaufen und zum Kontostand hinzufügen
            if(breadNumber > 0) { db.DeleteItemsFromDBAndAddToBalance(soldBread, 2); CurrentBalance = db.SelectCurrentBalance(); }
            // Bier löschen/verkaufen und zum Kontostand hinzufügen
            if(beerNumber > 0) { db.DeleteItemsFromDBAndAddToBalance(soldBeer, 3); CurrentBalance = db.SelectCurrentBalance(); }
            // Limonade löschen/verkaufen und zum Kontostand hinzufügen
            if(lemonadesNumber > 0) { db.DeleteItemsFromDBAndAddToBalance(soldLemonades, 4); CurrentBalance = db.SelectCurrentBalance(); }

            // tägliche Betriebskosten verrechnen
            db.OperatingCosts();

            // Abfragen ob Pleite und setzen der Property
            if(db.SelectCurrentBalance() < -500) IsBankrupt = true;

            // Lagerstand aktualisieren
            SetAmountPerItem();

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
            get { currentBalance = db.SelectCurrentBalance(); return Math.Round(this.currentBalance, 2); }
            set { if (this.currentBalance != value) { this.currentBalance = value; ; this.NotifyPropertyChanged("CurrentBalance"); } }
        }

        // Aktuelle Einnahmen => werden nach der Simulation berechnet anhand der verkauften Artikel
        private double receiptsYesterday;
        // Property für Einnahmen
        public double ReceiptsYesterday
        {
            get { receiptsYesterday = db.SelectReceiptsYesterday(); return Math.Round(this.receiptsYesterday, 2); }
            set { if (this.receiptsYesterday != value) { this.receiptsYesterday = value; ; this.NotifyPropertyChanged("ReceiptsYesterday"); } }
        }

        // Aktuelle Ausgaben => werden nach der Simulation berechnet anhand der Einkäufe und der abgelaufenen Waren
        private double expendituresYesterday;
        // Property für Ausgaben
        public double ExpendituresYesterday
        {
            get { expendituresYesterday = db.SelectExpendituresYesterday(); return Math.Round(this.expendituresYesterday, 2); }
            set { if (this.expendituresYesterday != value) { this.expendituresYesterday = value; ; this.NotifyPropertyChanged("ExpendituresYesterday"); } }
        }

        // Für Abfrage ob pleite
        private bool isBankrupt;
        // Property für Pleite
        public bool IsBankrupt
        {
            get { return isBankrupt; }
            set { isBankrupt = value; }
        }

        // Property für Abfrage ob Spiel gespeichert
        public bool IsGameSaved
        {
            get { return db.SelectIsGameSaved(); }
            set { db.SetGameIsNotSaved(); }
        }

        // Property für die Abfrage, ob ein anderer Button bereits aktiv ist
        public bool ButtonIsActive { get; set; }

        #region Properties für Lagerstände und Methode zur Befüllung
        // Wurst
        private int sausageAmount = 0;
        public int SausageAmount
        {
            get { return this.sausageAmount; }
            set { if (this.sausageAmount != value) { this.sausageAmount = value; ; this.NotifyPropertyChanged("SausageAmount"); } }
        }

        // Brot
        private int breadAmount = 0;
        public int BreadAmount
        {
            get { return this.breadAmount; }
            set { if (this.breadAmount != value) { this.breadAmount = value; ; this.NotifyPropertyChanged("BreadAmount"); } }
        }
        // Bier
        private int beerAmount = 0;
        public int BeerAmount
        {
            get { return this.beerAmount; }
            set { if (this.beerAmount != value) { this.beerAmount = value; ; this.NotifyPropertyChanged("BeerAmount"); } }
        }

        // Limonade
        private int lemonadeAmount = 0;
        public int LemonadeAmount
        {
            get { return this.lemonadeAmount; }
            set { if (this.lemonadeAmount != value) { this.lemonadeAmount = value; ; this.NotifyPropertyChanged("LemonadeAmount"); } }
        }

        // Methode die die Werte an die Attribute überibt, wird nach jedem Kauf und Verkauf ausgeführt
        // Setzt die Properties auf die entsprechenden Werte
        public void SetAmountPerItem()
        {
            db.SelectAmountPerItem(out int sausagesNumber, out int breadNumber, out int beerNumber, out int lemonadesNumber);
            SausageAmount = sausagesNumber;
            BreadAmount = breadNumber;
            BeerAmount = beerNumber;
            LemonadeAmount = lemonadesNumber;
        }
        #endregion
    }
}
