using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ListViewFilter.Extensions
{
    public static class StringExtensions
    {
        public static string[] DiacriticVariations(this string str)
        {
            var res = new List<string>();
            res.Add(str);
            res.Add(str.RemoveDiacritics());

            var positions = new List<int>();

            for (var i = 0; i < str.Length; i++)
            {
                var c = str[i];
                if (c.IsDiacritic())
                {
                    positions.Add(i);
                }
            }

            var combs = GetKCombs(positions, positions.Count);
            for (var i = positions.Count - 1; i > 0; i--)
            {
                combs = combs.Union(GetKCombs(positions, i));
            }
            foreach (var comb in combs)
            {
                var sb = new StringBuilder();
                for (var i = 0; i < str.Length; i++)
                {
                    char c = str[i];
                    if (comb.Contains(i))
                    {
                        sb.Append(c.ToString().RemoveDiacritics());
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
                res.Add(sb.ToString());
            }
            return res
                .ToArray();
        }

        public static bool IsDiacritic(this char c)
        {
            var s = c.ToString().Normalize(NormalizationForm.FormD);
            return (s.Length > 1) &&
                   char.IsLetter(s[0]) &&
                   s.Skip(1).All(c2 => CharUnicodeInfo.GetUnicodeCategory(c2) == UnicodeCategory.NonSpacingMark);
        }

        public static string RemoveDiacritics(this string inputString)
        {
            var normalizedString = inputString.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();
            foreach (var c in normalizedString)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }
            return stringBuilder.ToString();
        }

        private static IEnumerable<IEnumerable<T>> GetKCombs<T>(IEnumerable<T> list, int length) where T : IComparable
        {
            if (length == 0) return new List<IEnumerable<T>>();
            if (length == 1) return list.Select(t => new T[] { t });
            return GetKCombs(list, length - 1)
                .SelectMany(t => list.Where(o => o.CompareTo(t.Last()) > 0),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }


}
