using Prism.Mvvm;
using NpvCalculator.Core.Extensions;

namespace NpvCalculator.Models
{
    public class NpvParameter : BindableBase
    {
        #region PROPERTIES
        public double InitialInvestment
        {
            get { return _initialInvestment; }
            set { SetProperty(ref _initialInvestment, value); }
        }
        private double _initialInvestment;


        public double LowerBoundDiscountRate
        {
            get { return _LowerBoundDiscountRate; }
            set { SetProperty(ref _LowerBoundDiscountRate, value); }
        }
        private double _LowerBoundDiscountRate;

        public double UpperBoundDiscountRate
        {
            get { return _UpperBoundDiscountRate; }
            set { SetProperty(ref _UpperBoundDiscountRate, value); }
        }
        private double _UpperBoundDiscountRate;

        public double DiscountRateIncrement
        {
            get { return _DiscountRateIncrement; }
            set { SetProperty(ref _DiscountRateIncrement, value); }
        }
        private double _DiscountRateIncrement;

        public int? ProjectLife
        {
            get { return _ProjectLife; }
            set { SetProperty(ref _ProjectLife, value); }
        }
        private int? _ProjectLife;
        #endregion // PROPERTIES

        public bool IsValid()
        {
            return LowerBoundDiscountRate.IsNonZero()
                   && DiscountRateIncrement.IsNonZero()
                   && UpperBoundDiscountRate.IsNonZero()
                   && ProjectLife != 0;
        }
    }
}