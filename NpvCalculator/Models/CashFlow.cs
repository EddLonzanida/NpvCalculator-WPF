using Prism.Mvvm;

namespace NpvCalculator.Models
{
    public class CashFlow : BindableBase
    {
        public int Index
        {
            get { return _Index; }
            set { SetProperty(ref _Index, value); }
        }
        private int _Index;

        public double Cash
        {
            get { return _Cash; }
            set { SetProperty(ref _Cash, value); }
        }
        private double _Cash;
    }
}