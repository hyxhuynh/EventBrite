using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class CatalogSeed
    {
        public static void Seed(CatalogContext context)
        {
            context.Database.Migrate();
            // Categories
            if (!context.CatalogCategories.Any())
            {
                context.CatalogCategories
                    .AddRange(GetPreConfiguredCatalogCategories());

                context.SaveChanges();
            }

            // Types
            if (!context.CatalogTypes.Any())
            {
                context.CatalogTypes
                    .AddRange(GetPreConfiguredCatalogTypes());

                context.SaveChanges();
            }

            // Cities
            if (!context.CatalogEventCities.Any())
            {
                context.CatalogEventCities
                    .AddRange(GetPreConfiguredCatalogEventCities());

                context.SaveChanges();
            }

            // Zipcodes
            if (!context.CatalogEventZipcodes.Any())
            {
                context.CatalogEventZipcodes
                    .AddRange(GetPreConfiguredCatalogEventZipcodes());

                context.SaveChanges();
            }

            // Events
            if (!context.CatalogEvents.Any())
            {
                context.CatalogEvents
                    .AddRange(GetPreConfiguredCatalogEvents());

                context.SaveChanges();
            }

        }


        // ================== METHODS =======================

        // Event
        private static IEnumerable<CatalogEvent> GetPreConfiguredCatalogEvents()
        {
            return new List<CatalogEvent>()
            {
                // Networking, Sport&Fitness, Seattle, 98103
                new CatalogEvent() { CatalogTypeId = 3, CatalogCategoryId = 5, Description = "An event combining a light workout, followed by healthy hosted appetizers, thirst-quenching drinks, and of course networking with other active young professionals!", Name = "Networkout July | Flow Fitness - Fremont", Price = 10, Address1 = "Flow Fitness, 710 North 34th Street", Address2 = "", CatalogEventCityId = 1, State = "WA", CatalogEventZipcodeId = 1, EventDateTime = new DateTime(2019, 7, 18, 19, 0, 0), PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },

                // Networking, Sport&Fitness, Issaquah, 98029
                new CatalogEvent() { CatalogTypeId = 3, CatalogCategoryId = 5, Description = "Are you new to mountain biking, looking to meet more ladies who ride, or just looking for a mid-week excuse to get out? Come to this meet-up to make new friends, practice your bike skills, and get outside.", Name = "WA SheJumps Mountain Bike Meet Up at Duthie Hill", Price = 10, Address1 = "Duthie Hill Mountain Bike Park, Southeast Issaquah-Fall City Road", Address2 = "", CatalogEventCityId = 2, State = "WA", CatalogEventZipcodeId = 2, EventDateTime = new DateTime(2019, 8, 21, 18, 0, 0), PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2" },

                
                // Party, Sport&Fitness, Seattle, 98134
                new CatalogEvent() { CatalogTypeId = 4, CatalogCategoryId = 5, Description = "Join UAS Chancellor Richard Caulfield and UAS Alumni & Friends in an exclusive right-field group suite at T-Mobile Park (formerly Safeco Field)! Ticket includes a tasty lineup of snacks, entrees, desserts, and non-alcoholic beverages and parking pass.", Name = "UAS Alumni & Friends Mariners Baseball Suite", Price = 35, Address1 = "T-Mobile Park, 1250 1st Avenue South", Address2 = "", CatalogEventCityId = 1, State = "WA", CatalogEventZipcodeId = 3, EventDateTime = new DateTime(2019, 7, 20, 17, 0, 0), PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3" },

                // Festival, Food & Drink, Kirkland, 98033
                new CatalogEvent() { CatalogTypeId = 2, CatalogCategoryId = 3, Description = "Sip Kirkland is a tasting event showcasing top tier wineries and breweries from the Pacific Northwest region. ", Name = "Sip Kirkland", Price = 14, Address1 = "25 Lakeshore Plaza", Address2 = "", CatalogEventCityId = 3, State = "WA", CatalogEventZipcodeId = 4, EventDateTime = new DateTime(2019, 7, 27, 13, 0, 0), PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4" },

            };

        }

        // Zipcode
        private static IEnumerable<CatalogEventZipcode> GetPreConfiguredCatalogEventZipcodes()
        {
            return new List<CatalogEventZipcode>()
            {
                new CatalogEventZipcode() {Zipcode = "98103"}, // 1
                new CatalogEventZipcode() {Zipcode = "98029"},  // 2
                new CatalogEventZipcode() {Zipcode = "98134"},  // 3
                new CatalogEventZipcode() {Zipcode = "98033"} // 4
            };
        }

        // City
        private static IEnumerable<CatalogEventCity> GetPreConfiguredCatalogEventCities()
        {
            return new List<CatalogEventCity>()
            {
                new CatalogEventCity() {City = "Seattle"}, // 1
                new CatalogEventCity() {City = "Issaquah"}, // 2
                new CatalogEventCity() {City = "Kirkland"} // 3
            };
        }

        // Type
        private static IEnumerable<CatalogType> GetPreConfiguredCatalogTypes()
        {
            return new List<CatalogType>()
            {
                new CatalogType() {Type = "Convention"}, // 1
                new CatalogType() {Type = "Festival"}, // 2
                new CatalogType() {Type = "Networking"}, // 3
                new CatalogType() {Type = "Party"}, // 4
                new CatalogType() {Type = "Performance"} // 5
            };
        }

        // Category
        private static IEnumerable<CatalogCategory> GetPreConfiguredCatalogCategories()
        {
            return new List<CatalogCategory>()
            {
                new CatalogCategory() {Category = "Community"}, // 1
                new CatalogCategory() {Category = "Family & Education"}, // 2
                new CatalogCategory() {Category = "Food & Drink"}, // 3
                new CatalogCategory() {Category = "Science & Tech"}, // 4
                new CatalogCategory() {Category = "Sport & Fitness"}, // 5
                new CatalogCategory() {Category = "Travel & Outdoor"}, // 6
            };
        }
    }
}
