using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using NpvCalculator.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace NpvCalculator.Pages.Home.ViewModels
{
    [Export(typeof(INpvCalculatorViewModel))]
    public class NpvCalculatorViewModel : BindableBase, INpvCalculatorViewModel
    {
        private readonly IDiscountRateLimiter npvCalculator;

        [ImportingConstructor]
        public NpvCalculatorViewModel(IDiscountRateLimiter npvCalculator)
        {
            this.npvCalculator = npvCalculator;

            ComputeNpvCommand = new DelegateCommand<object>(ComputeNpvExecute, ComputeNpvCanExecute);
            SetCashFlowsCommand = new DelegateCommand<object>(SetCashFlowsExecute);

            NpvParameter = new NpvParameter
            {
                InitialInvestment = -100000,
                LowerBoundDiscountRate = 0.0365,
                UpperBoundDiscountRate = 0.037,
                DiscountRateIncrement = 0.0001,
                ProjectLife = 3
            };

            CashFlows.AddRange(new[]{
                new CashFlow { Index = 0, Cash = 10000 },
                new CashFlow { Index = 1, Cash = 10000 },
                new CashFlow { Index = 2, Cash = 10000 }
            });
        }

        #region PROPERTIES
        public ObservableCollection<NetPresentValue> NetPresentValues { get; } = new ObservableCollection<NetPresentValue>();

        public ObservableCollection<CashFlow> CashFlows { get; } = new ObservableCollection<CashFlow>();

        public NpvParameter NpvParameter
        {
            get { return _npvParameter; }
            set
            {
                if (_npvParameter != null) _npvParameter.PropertyChanged -= NpvParameterOnPropertyChanged;

                SetProperty(ref _npvParameter, value);

                if (_npvParameter != null) _npvParameter.PropertyChanged += NpvParameterOnPropertyChanged;
            }
        }

        private NpvParameter _npvParameter;

        private void NpvParameterOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            ComputeNpvCommand.RaiseCanExecuteChanged();
        }

        public bool HasItems
        {
            get { return _HasItems; }
            set { SetProperty(ref _HasItems, value); }
        }
        private bool _HasItems;

        #endregion // PROPERTIES

        #region ComputeNpvCommand
        public DelegateCommand<object> ComputeNpvCommand { get; private set; }

        private void ComputeNpvExecute(object param)
        {
            NetPresentValues.Clear();
            var rateLevels = npvCalculator.GetRateLevels(NpvParameter.LowerBoundDiscountRate,
                NpvParameter.UpperBoundDiscountRate,
                NpvParameter.DiscountRateIncrement);

            for (var i = 0; i < rateLevels.Count; i++)
            {
                NetPresentValues.Add(new NetPresentValue { Index = i + 1, DiscountRateLevel = rateLevels[i] });
            }

            for (var i = 0; i < NetPresentValues.Count; i++)
            {
                var discountRateLevel = NetPresentValues[i].DiscountRateLevel;
                var j = 0;
                var totalPresentValue = CashFlows.ToList().Sum(c =>
                {
                    j++;
                    var presentValue = CalculatePresentValue(c.Cash, discountRateLevel, j);
                    return presentValue;
                });

                NetPresentValues[i].Value = totalPresentValue + NpvParameter.InitialInvestment;
            }

            HasItems = true;
        }

        private bool ComputeNpvCanExecute(object param)
        {
            var canExecute = NpvParameter.IsValid()
                                && CashFlows.Any();

            return canExecute;
        }

        private static double CalculatePresentValue(double cashFlow, double discountRateLevel, int power)
        {
            return cashFlow / Math.Pow(1 + discountRateLevel, power);
        }

        #endregion // ComputeNpvCommand

        #region SetCashFlowsCommand
        public DelegateCommand<object> SetCashFlowsCommand { get; private set; }

        private void SetCashFlowsExecute(object param)
        {
            int i = 0;

            if (!int.TryParse(param.ToString(), out i)) return;

            NetPresentValues.Clear();
            HasItems = false;
            SetCashFlows(i);
        }

        private void SetCashFlows(int count)
        {
            if (count == 0)
            {
                CashFlows.Clear();
            }
            else if (count < CashFlows.Count)
            {
                while (count < CashFlows.Count)
                {
                    CashFlows.RemoveAt(CashFlows.Count - 1);
                }
            }
            else if (count > CashFlows.Count)
            {
                while (count > CashFlows.Count)
                {
                    var index = CashFlows.Count;

                    CashFlows.Add(new CashFlow { Index = index + 1 });
                }
            }
        }
        #endregion // SetCashFlowsCommand
    }
}
