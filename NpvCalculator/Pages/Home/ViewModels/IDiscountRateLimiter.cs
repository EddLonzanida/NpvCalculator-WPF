using System.Collections.Generic;

namespace NpvCalculator.Pages.Home.ViewModels
{
    public interface IDiscountRateLimiter
    {
        List<double> GetRateLevels(double lowerBoundDiscountRate,double upperBoundDiscountRate, double discountRateIncrement);
    }
}