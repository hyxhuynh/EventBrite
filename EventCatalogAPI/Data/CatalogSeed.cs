using Microsoft.EntityFrameworkCore;
using EventCatalogAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public static class CatalogSeed
    {
        public static void Seed(CatalogContext context)
        {
            context.Database.Migrate();

            if (!context.CatalogTypes.Any())
            {
                context.CatalogTypes
                    .AddRange(GetPreConfiguredCatalogTypes());
                context.SaveChanges();
            }
            if (!context.CatalogCategories.Any())
            {
                context.CatalogCategories
                    .AddRange(GetPreConfiguredCatalogCategories());
                context.SaveChanges();
            }
            if (!context.CatalogEvents.Any())
            {
                context.CatalogEvents
                    .AddRange(GetPreConfiguredCatalogEvents());
                context.SaveChanges();
            }
        }

        private static IEnumerable<CatalogType>
          GetPreConfiguredCatalogTypes()
        {
            return new List<CatalogType>()
            {
                new CatalogType() {Type= "Festival"},
                new CatalogType() {Type = "Performance" },
                new CatalogType() {Type = "Screening" }
            };
        }
        private static IEnumerable<CatalogCategory>
            GetPreConfiguredCatalogCategories()
        {
            return new List<CatalogCategory>()
            {
                new CatalogCategory() {Category = "Music"},
                new CatalogCategory() {Category = "Performance & Visual Arts" },
                new CatalogCategory() {Category = "Film & Media" }
            };
        }
        private static IEnumerable<CatalogEvent>
            GetPreConfiguredCatalogEvents()
        { 
            return new List<CatalogEvent>()
            {
                new CatalogEvent() {Name = " "},
                new CatalogEvent() {CatalogTypeId=0,CatalogCategoryId=0, Description = "Music event", Name = "Devin Townsend", Price = 0, PictureUrl = "", Address1 = "", Address2 = "", City = "", State = "", Zipcode = "", EventDateTime= new DateTime(2008, 6, 1, 7, 47, 0)}
            };
        }
    }
}
