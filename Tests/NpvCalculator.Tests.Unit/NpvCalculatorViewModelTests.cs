using System;
using System.Collections.Generic;
using System.Linq;
using NpvCalculator.Models;
using NpvCalculator.Pages.Home.ViewModels;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NpvCalculator.Tests.Unit
{
    public class NpvCalculatorViewModelTests
    {
        private readonly IDiscountRateLimiter discountRateLimiter;

        public NpvCalculatorViewModelTests()
        {
            discountRateLimiter = Substitute.For<IDiscountRateLimiter>();
        }

        [Fact]
        public void ComputeNpvCommand_ShouldComputeNpv()
        {
            var oneRateLevelOnly = new List<double> { 0.12 };
            discountRateLimiter.GetRateLevels(Arg.Any<double>(), Arg.Any<double>(), Arg.Any<double>())
                .Returns(oneRateLevelOnly);
            var npvParameter = new NpvParameter { InitialInvestment = -35000 };
            var sut = new NpvCalculatorViewModel(discountRateLimiter)
            {
                NpvParameter = npvParameter,
            };
            sut.CashFlows.Clear();
            sut.CashFlows.Add(new CashFlow { Cash = 10000, Index = 1 });
            sut.CashFlows.Add(new CashFlow { Cash = 27000, Index = 2 });
            sut.CashFlows.Add(new CashFlow { Cash = 19000, Index = 3 });

            sut.ComputeNpvCommand.Execute(null);

            sut.NetPresentValues.Count.ShouldBe(1);
            Math.Round(sut.NetPresentValues.First().Value, 2).ShouldBe(8976.63);
            //ref: https://www.investopedia.com/ask/answers/032615/what-formula-calculating-net-present-value-npv.asp
        }

        [Fact]
        public void ComputeNpvCommand_ShouldComputeMultipleNpv()
        {
            var multipleRateLevels = new List<double> { 0.12, 0.15 };
            discountRateLimiter.GetRateLevels(Arg.Any<double>(), Arg.Any<double>(), Arg.Any<double>())
                               .Returns(multipleRateLevels);
            var npvParameter = new NpvParameter { InitialInvestment = -35000 };
            var sut = new NpvCalculatorViewModel(discountRateLimiter)
            {
                NpvParameter = npvParameter,
            };
            sut.CashFlows.Clear();
            sut.CashFlows.Add(new CashFlow { Cash = 10000, Index = 1 });
            sut.CashFlows.Add(new CashFlow { Cash = 27000, Index = 2 });
            sut.CashFlows.Add(new CashFlow { Cash = 19000, Index = 3 });


            sut.ComputeNpvCommand.Execute(null);

            sut.NetPresentValues.Count.ShouldBe(2);
            Math.Round(sut.NetPresentValues.First().Value, 2).ShouldBe(8976.63);
            Math.Round(sut.NetPresentValues.Last().Value, 2).ShouldBe(6604.34);
        }
    }
}
