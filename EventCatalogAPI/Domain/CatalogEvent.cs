using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class CatalogEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
       //remove city and zipcode as per allie's branch
        //public string City { get; set; }
        public string State { get; set; }
       // public string Zipcode { get; set; }
        public DateTime EventDateTime { get; set; }

        public int CatalogTypeId { get; set; }
        public virtual CatalogType CatalogType { get; set; }

        public int CatalogCategoryId { get; set; }
        public virtual CatalogCategory CatalogCategory { get; set; }

        public int CatalogEventCityId { get; set; }
        public virtual CatalogEventCity CatalogEventCity { get; set; }

        public int CatalogEventZipcodeId { get; set; }
        public virtual CatalogEventZipcode CatalogEventZipcode { get; set; }
    }
}
