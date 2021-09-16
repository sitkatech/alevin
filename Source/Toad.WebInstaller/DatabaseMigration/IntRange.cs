using System;
using System.Collections.Generic;
using System.Linq;
using Toad.WebInstaller.Database.DatabaseUtil;

namespace Toad.WebInstaller.DatabaseMigration
{
    public class IntRange
    {
        public readonly int Max;
        public readonly int Min;

        public IntRange(int min, int max)
        {
            ErrorHelper.AssertPreCondition(min <= max, string.Format("Min {0} <= {1} Max failed.", min, max));
            Min = min;
            Max = max;
        }

        public static string ToDisplayString(IEnumerable<int> ints)
        {
            var ranges = MakeIntRanges(ints);
            if (ranges.Count == 0)
            {
                return "(none)";
            }
            return String.Join(",", ranges.Select(x => x.ToDisplayString()));
        }

        public static List<IntRange> MakeIntRanges(IEnumerable<int> ints)
        {
            var ranges = new List<IntRange>();
            if (ints == null || !ints.Any())
            {
                return ranges;
            }
            if (ints.Count() == 1)
            {
                ranges.Add(new IntRange(ints.Min(), ints.Max()));
                return ranges;
            }

            var sorted = ints.OrderBy(x => x);
            var previous = sorted.First() - 1;
            var currentMin = sorted.First();

            foreach (var i in sorted)
            {
                var delta = i - previous;
                if (delta != 1)
                {
                    ranges.Add(new IntRange(currentMin, previous));
                    currentMin = i;
                }
                previous = i;
            }
            ranges.Add(new IntRange(currentMin, previous));
            return ranges;
        }

        public string ToDisplayString()
        {
            if (Min == Max)
            {
                return Min.ToString();
            }
            return string.Format("{0}..{1}", Min, Max);
        }
    }
}