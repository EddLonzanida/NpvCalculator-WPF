using System;

namespace NpvCalculator.Core.Extensions
{
    public static class FloatingPointExtensions
    {
        public static bool IsZero(this double value, int tolerance = 5)
        {
            var tmpTolerance = GetTolerance(tolerance);

            return value < tmpTolerance;
        }

        public static bool IsNonZero(this double value, int tolerance = 5)
        {
            var isZero = value.IsZero(tolerance);

            return !isZero;
        }

        //float
        public static bool IsZero(this float value, int tolerance = 5)
        {
            var tmpTolerance = GetTolerance(tolerance);

            return value < tmpTolerance;
        }

        public static bool IsNonZero(this float value, int tolerance = 5)
        {
            var isZero = value.IsZero(tolerance);

            return !isZero;
        }

        private static double GetTolerance(int tolerance)
        {
            return Math.Pow(10, -tolerance);
        }
    }
}
