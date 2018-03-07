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
        public int Id { get; set; }
        public string WeatherNextDay { get; set; }
        public int SeasonTempRangeId { get; set; }
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
}
