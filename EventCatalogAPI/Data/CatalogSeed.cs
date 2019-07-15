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

                // Performance, Music, Seattle, 98103
                new CatalogEvent() {CatalogTypeId=5,CatalogCategoryId=7, CatalogEventCityId = 1, CatalogEventZipcodeId = 1, Description = "30 Years x 30 Cities", Name = "Helmet 30th Anniversary Tour", Price = 24, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5", Address1 = "645 NW 45th Street", Address2 = "", State = "WA", EventDateTime= new DateTime(2019, 11, 17, 21, 00, 0)},

                // Screening, Film & Media, Seattle, 98103
                new CatalogEvent() {CatalogTypeId=6, CatalogCategoryId=6, CatalogEventCityId=1, CatalogEventZipcodeId =1, Description = "With Marty McFly heading to the 50's and our iconic drive-in style, you'll feel like you're in the past too! Free and All Ages!", Name = "Outdoor Movie: Back to the Future!", Price = 0, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/6", Address1 = "12325 30th Ave NE", Address2 = "", State = "WA", EventDateTime = new DateTime(2019, 7, 23, 19, 00, 0) },

                // Festival, Community, Kirkland,
                new CatalogEvent() {CatalogTypeId=2, CatalogCategoryId=1, CatalogEventCityId=3, CatalogEventZipcodeId=4, Description = "Come and experience the beauty as thousands of lanterns illuminate the water in Kirkland, WA", Name = "1000 Lights Water Lantern Festival", Price = 25, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7", Address1 = "9703 NE Juanita Drive", Address2 = "", State = "WA", EventDateTime = new DateTime(2019, 8, 10, 18, 00, 0)},

                // Networking, Science & Tech, Seattle, 98104
                new CatalogEvent() { CatalogTypeId = 3, CatalogCategoryId = 4, Description = "Seattle SQL provides opportunities to enjoy data experts visiting the area, networking with peers, and to share knowledge about Microsoft data platforms, including SQL Server and SQL Server on Azure. as well as professional development.", Name = "Seattle SQL Monthly Meetings", Price = 0, Address1 = "Bank of America Fifth Avenue Plaza 800 5th Avenue", Address2 = "27th Floor", CatalogEventCityId = 1, State = "WA", CatalogEventZipcodeId = 5, EventDateTime = new DateTime(2019, 7, 26, 13, 30, 0), PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8" },

                // Networking, Science & Tech, Seattle, 98121
                new CatalogEvent() { CatalogTypeId = 3, CatalogCategoryId = 4, Description = "Join us for drinks, snacks and good conversation with Code Fellows' students, staff, and alumni. You'll have an opportunity to learn more about Code Fellows’ programs and what a future career in coding can look like for you.", Name = "Happy Hour at Code Fellows", Price = 0, Address1 = "Code Fellows 2901 3rd Avenue", Address2 = "#300", CatalogEventCityId = 1, State = "WA", CatalogEventZipcodeId = 6, EventDateTime = new DateTime(2019, 7, 18, 16, 30, 0), PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/9" },

                 // Convention, Family & Education, Seattle, 98122
                new CatalogEvent() { CatalogTypeId = 1, CatalogCategoryId = 2, Description = "Learn about admissions requirements and application deadlines for graduate programs in social work, public policy, nonprofit management, international affairs, public interest law, social entrepreneurship, and many more", Name = "Seattle Idealist Grad Fair 2019", Price = 0, Address1 = "Seattle University, Campion Ballroom 914 E Jefferson Street", Address2 = "", CatalogEventCityId = 1, State = "WA", CatalogEventZipcodeId = 7, EventDateTime = new DateTime(2019, 10, 17, 17, 00, 0), PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/10" },

            };

        }

        // Zipcode
        private static IEnumerable<CatalogEventZipcode> GetPreConfiguredCatalogEventZipcodes()
        {
            return new List<CatalogEventZipcode>()
            {
                new CatalogEventZipcode() {Zipcode = "98103"}, // 1
                new CatalogEventZipcode() {Zipcode = "98029"}, // 2
                new CatalogEventZipcode() {Zipcode = "98134"}, // 3
                new CatalogEventZipcode() {Zipcode = "98033"}, // 4
                new CatalogEventZipcode() {Zipcode = "98104"}, // 5
                new CatalogEventZipcode() {Zipcode = "98121"}, // 6
                new CatalogEventZipcode() {Zipcode = "98122"}  // 7
            };
        }

        // City
        private static IEnumerable<CatalogEventCity> GetPreConfiguredCatalogEventCities()
        {
            return new List<CatalogEventCity>()
            {
                new CatalogEventCity() {City = "Seattle"},  // 1
                new CatalogEventCity() {City = "Issaquah"}, // 2
                new CatalogEventCity() {City = "Kirkland"}  // 3
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
                new CatalogType() {Type = "Performance"}, // 5
                new CatalogType() {Type = "Screening"} //6
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
                new CatalogCategory() {Category = "Film & Media"}, //6
                new CatalogCategory() {Category = "Music"} //7
            };
        }
    }
}
