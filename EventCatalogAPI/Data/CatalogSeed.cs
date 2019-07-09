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

        // Types
        private static IEnumerable<> GetPreConfiguredCatalogEvents()
        {
            return new List<CatalogEvent>()
            {
                new CatalogEvent() {}
            }

        }

        // Zipcode
        private static IEnumerable<CatalogEventZipcode> GetPreConfiguredCatalogEventZipcodes()
        {
            return new List<CatalogEventZipcode>()
            {
                new CatalogEventZipcode()
                {

                }
            }
        }

        // City
        private static IEnumerable<CatalogEventCity> GetPreConfiguredCatalogEventCities()
        {
            return new List<CatalogEventCity>()
            {
                new CatalogEventCity()
                {

                }
            }
        }

        // Type
        private static IEnumerable<CatalogType> GetPreConfiguredCatalogTypes()
        {
            return new List<CatalogType>()
            {
                new CatalogType()
                {

                }
            }
        }

        private static IEnumerable<CatalogCategory> GetPreConfiguredCatalogCategories()
        {
            return new List<CatalogCategory>()
            {
                new CatalogCategory()
                {

                }
            }
        }
    }
}
