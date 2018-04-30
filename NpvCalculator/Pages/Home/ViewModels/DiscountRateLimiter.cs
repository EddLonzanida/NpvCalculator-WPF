using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace NpvCalculator.Pages.Home.ViewModels
{
    [Export(typeof(IDiscountRateLimiter))]
    public class DiscountRateLimiter : IDiscountRateLimiter
    {
        public List<double> GetRateLevels(double lowerBoundDiscountRate, double upperBoundDiscountRate, double discountRateIncrement)
        {
            var results = new List<double> { lowerBoundDiscountRate };

            while (lowerBoundDiscountRate < upperBoundDiscountRate)
            {
                lowerBoundDiscountRate += discountRateIncrement;
                results.Add(lowerBoundDiscountRate);
            }

            return results;
        }
    }
}
