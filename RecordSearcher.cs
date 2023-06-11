using System;
using System.Linq;

namespace Task5
{
    public class RecordSearcher
    {
        public static void Search(Record[] db)
        {
            var dict = db
                .GroupBy(g => g.ClientID)
                .ToDictionary(g => g.Key,
                    g => g.Select(el => el.Duration).Sum())
                .OrderByDescending(el => el.Value)
                .ThenBy(el => el.Key)
                .ToDictionary(g => g.Key, g => g.Value);
            if (dict.Count > 0)
            {
                foreach (var key in dict.Keys)
                    Console.WriteLine($"{dict[key]} {key}");
            }
            else
                Console.WriteLine("Нет данных.");
        }
    }
}