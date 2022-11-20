using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelComplex
{
    public static class Mapping
    {
        public enum Source
        {
            Tables,
            Client,
            Organization,
            Order,
            Builing,
            Costs,
            Room,
            Location,
            Tarrif,
            Service,
            Set,
        }

        private static readonly Dictionary<string, string> tables = new Dictionary<string, string>
        {
            { "client", "клиент" },
            { "organization", "организация" },
            { "booking_order", "заказ на бронирование" },
            { "building", "корпус комплекса" },
            { "client_costs", "расходы клиента" },
            { "room", "комната отеля" },
            { "room_location", "локация комнаты" },
            { "tarrif", "тариф бронирования" },
            { "tarrif_service", "услуга" },
            { "tarrif_service_set", "набор услуг" },
        };

        public static bool MappingValues(string[] data, out string[] val, Source source, bool esape = false)
        {
            var sourceValues = getMappingSource(source);
            var hasUnmapped = false;
            var mappedList = new List<string>();
            foreach (var item in data)
            {
                var found = sourceValues.TryGetValue(item, out string mappedItem);
                if (found)
                {
                    mappedList.Add(mappedItem);
                }
                else
                {
                    mappedList.Append("");
                    hasUnmapped = true;
                }
            }
            val = mappedList.ToArray();  
            return hasUnmapped;
        }

        private static Dictionary<string,string> getMappingSource(Source source)
        {
            Dictionary<string, string> mapValues;
            switch (source)
            {
                case Source.Tables:
                default:
                    mapValues = tables;
                break;
            }
            return mapValues;
        }
    }
}
