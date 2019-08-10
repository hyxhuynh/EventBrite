using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Infrastructure
{
    public class ApiPaths
    {
        public static class Catalog
        {
            public static string GetAllTypes(string baseUri)
            {
                return $"{baseUri}catalogtypes";
            }
            public static string GetAllCategories(string baseUri)
            {
                return $"{baseUri}catalogcategories";
            }
            public static string GetAllEventCities(string baseUri)
            {
                return $"{baseUri}catalogeventcities";
            }
            // ============= Remove Zipcode here if not needed ==============
            public static string GetAllEventZipcodes(string baseUri)
            {
                return $"{baseUri}catalogeventzipcodes";
            }
            public static string GetAllCatalogEvents(string baseUri, int page, int take, int? type, int? category, int? eventcity, int? eventzipcode)
            {
                var filterQs = string.Empty;

                if (category.HasValue || type.HasValue || eventcity.HasValue || eventzipcode.HasValue)
                {
                    var categoryQs = (category.HasValue) ? category.Value.ToString() : "null";
                    var typeQs = (type.HasValue) ? type.Value.ToString() : "null";
                    var eventcityQs = (eventcity.HasValue) ? eventcity.Value.ToString() : "null";
                    var eventzipcodeQs = (eventzipcode.HasValue) ? eventzipcode.Value.ToString() : "null";
                    filterQs = $"/type/{typeQs}/category/{categoryQs}/eventzipcode/{eventcityQs}/eventzipcode/{eventzipcodeQs}";
                }

                return $"{baseUri}events{filterQs}?pageIndex={page}&pageSize={take}";
            }
        }

        public static class Basket
        {
            public static string GetBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }

            public static string UpdateBasket(string baseUri)
            {
                return baseUri;
            }

            public static string CleanBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }
        }

        public static class Order
        {
            public static string GetOrder(string baseUri, string orderId)
            {
                return $"{baseUri}/{orderId}";
            }

            //public static string GetOrdersByUser(string baseUri, string userName)
            //{
            //    return $"{baseUri}/userOrders?userName={userName}";
            //}
            public static string GetOrders(string baseUri)
            {
                return baseUri;
            }
            public static string AddNewOrder(string baseUri)
            {
                return $"{baseUri}/new";
            }
        }

    }
}
