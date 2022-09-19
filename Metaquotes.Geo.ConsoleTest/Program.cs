using System;
using System.Collections.Generic;
using Metaquotes.Geo.Common;
using Metaquotes.Geo.Data;

namespace Metaquotes.Geo.ConsoleTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            DataBase database = DataBaseManager.Read(@"C:\Users\venik\Desktop\Programming\C#\projects\MetaQuotes\MetaquotesTest-master\geobase.dat");
            //DataBase database = DataBaseManager.Read(@"C:\Users\venik\source\repos\GeoLocationSPA\GeoBaseData\Database\geobase.dat");
            //---
            Console.WriteLine($"Database loaded in {database.LoadTime} ms.");
            //---
            ISearchService searchService = new SearchService(database);
           //---
            IReadOnlyCollection<Location> locations = searchService.GetLocationsByCity("cit_Gbqw4");//cit_Opyfu - source, cit_Gbqw4 - my
            //---
            foreach (Location location in locations)
            {
                Console.WriteLine(location);
            }
            //---
            Console.WriteLine();
            //---
            Location? ipLocation = searchService.GetLocationByIp(3933989499);//16287938 - source, 3933989499 - my
            if (ipLocation.HasValue)
            {
                Console.WriteLine(ipLocation);
            }
            //---
            Console.ReadKey();
        }
    }
}