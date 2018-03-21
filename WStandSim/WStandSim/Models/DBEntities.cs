using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace WStandSim.Database
{
    public class DBEnities
    {
    }

    [Table("StoredItems")]
    // Klasse für Artikel
    public class StoredItems
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int Bestbefore { get; set; }
        [Indexed]
        public int ItemTypeId { get; set; }
    }

    [Table("ItemType")]
    // Klasse für Artikeltypen
    public class ItemType
    {
        public int Id { get; set; }
        public string ItemTypeName { get; set; }
    }

    [Table("ItemSalesQuota")]
    // Klasse für Verkaufsquoten je nach Artikel und Temperaturbereich
    public class ItemSalesQuota
    {
        public int Id { get; set; }
        public int ItemTypeId { get; set; }
        public int SeasonTempRangeId { get; set; }
        public int SalesQuotaFrom { get; set; }
        public int SalesQuotaTo { get; set; }
    }

    [Table("Finance")]
    // Klasse für Finanzen
    public class Finance
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string AssetLabel { get; set; }
    }

    [Table("Weather")]
    // Klasse für Wetter
    public class Weather
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Day { get; set; }
        public int SeasonID { get; set; }
        public int TempFrom { get; set; }
        public int TempTo { get; set; }
        public int SeasonTemperature { get; set; }
        public string WeatherText { get; set; }
        public int TempLow { get; set; }
        public int TempHigh { get; set; }
        public string SeasonText { get; set; }
        public int SeasonTempRangeID { get; set; }

        // Parameterloser Konstruktor
        public Weather()
        {

        }
        // Konstruktor
        public Weather(int day, int seasonID, int tempFrom, int tempTo, int seasonTemperature, string weatherText, int tempLow, int tempHigh, string seasonText, int seasonTempRangeID)
        {
            this.Day = day;
            this.SeasonID = seasonID;
            this.TempFrom = tempFrom;
            this.TempTo = tempTo;
            this.SeasonTemperature = seasonTemperature;
            this.WeatherText = weatherText;
            this.TempLow = tempLow;
            this.TempHigh = tempHigh;
            this.SeasonText = seasonText;
            this.SeasonTempRangeID = seasonTempRangeID;
        }
    }

    // Klasse für die Jahreszeiten
    [Table("Seasons")]
    public class Seasons
    {
        public int Id { get; set; }
        public string SeasonsText { get; set; }
        public int TempFrom { get; set; }
        public int TempTo { get; set; }
    }

    [Table("SeasonTempRange")]
    // Klasse für die Temperaturbereiche je Jahreszeit
    public class SeasonTempRange
    {
        public int Id { get; set; }
        public string SeasonTempRangeWeatherText { get; set; }
        public int SeasonId { get; set; }
        public int TempFrom { get; set; }
        public int TempTo { get; set; }
    }

    [Table("GameSaved")]
    // Klasse für die Variable, ob bereits ein Spiel gestartet wurd
    public class GameSaved
    {
        public int Id { get; set; }

        // Standard-Wert wenn Spiel das erste Mal gestartet wird
        public GameSaved()
        {
            IsGameSaved = false;
        }
        public bool IsGameSaved { get; set; }
    }

    [Table("SeasonDays")]
    // Klasse um sich die aktuelle Jahreszeit und den Tag zu merken
    public class SeasonDays
    {
        public int Id { get; set; }
        public int CurrentSeasonID { get; set; }
        public int DaysInSeason { get; set; }
    }

    [Table("DayCount")]
    // Klasse für die Gesamtzahl der gespielten Tage
    // Wichtig für das Ablaufdatum der Produkte
    public class DayCount
    {
        public int Id { get; set; }
        public int ActualDay { get; set; }

        // Konstruktor parameterlos
        public DayCount()
        {

        }
        // Konstruktor mit Parametern
        public DayCount(int Id, int actualDay)
        {
            this.Id = Id;
            this.ActualDay = actualDay;
        }
    }

    [Table("ItemPrice")]
    // Klasse für die Ein - und Verkaufspreise der Produkte
    public class ItemPrice
    {
        public int Id { get; set; }
        public int ItemTypeID { get; set; }
        public double PurchasingPrice { get; set; }
        public double RetailPrice { get; set; }
    }
}
