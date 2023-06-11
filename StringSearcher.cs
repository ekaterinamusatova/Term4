using System;
using System.Linq;

namespace Task5
{
    public class StringSearcher
    {
        public string[] Search(string[] array)
        {
            return array.Where(s => s.Length > 0)
                .Select(s => s.Substring(Math.Min(3, s.Length)).ToUpper())
                .Distinct()
                .OrderByDescending(s => s)
                .ToArray();
        }
    }
}