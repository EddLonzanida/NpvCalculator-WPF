using Prism.Mvvm;

namespace NpvCalculator.Models
{
    public class NetPresentValue : BindableBase
    {
        public int Index
        {
            get { return _Index; }
            set { SetProperty(ref _Index, value); }
        }
        private int _Index;

        public double DiscountRateLevel
        {
            get { return _DiscountRateLevel; }
            set { SetProperty(ref _DiscountRateLevel, value); }
        }
        private double _DiscountRateLevel;

        public double Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }
        private double _value;
    }
}