using System.Collections.ObjectModel;
using System.ComponentModel;
using NpvCalculator.Models;
using Prism.Commands;

namespace NpvCalculator.Pages.Home.ViewModels
{
    public interface INpvCalculatorViewModel
    {
        ObservableCollection<NetPresentValue> NetPresentValues { get; }

        ObservableCollection<CashFlow> CashFlows { get; }

        NpvParameter NpvParameter { get; set; }

        bool HasItems { get; set; }

        DelegateCommand<object> ComputeNpvCommand { get; }

        DelegateCommand<object> SetCashFlowsCommand { get; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}