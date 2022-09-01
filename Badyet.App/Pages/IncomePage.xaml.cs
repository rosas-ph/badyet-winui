using Badyet.App.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

namespace Badyet.App.Pages
{
    public sealed partial class IncomePage : Page
    {
        public IncomePage()
        {
            InitializeComponent();
        }

        static readonly Income sampleIncome = new()
        {
            Type = "Employment",
            Name = "Optum",
            BasicPay = 18_000m,
            Allowance = 3_600m,
        };

        private readonly string formattedBasicPay = $"{sampleIncome.BasicPay:C}";
        private readonly string formattedAllowance = $"{sampleIncome.Allowance:C}";
        private readonly string incomeType = sampleIncome.Type;
        private readonly string incomeName = sampleIncome.Name;

        static readonly decimal dailyPay = sampleIncome.BasicPay / 30;
        static readonly decimal annualPay = sampleIncome.BasicPay * 12;

        private readonly string formattedDailyPay = $"{dailyPay:C}";
        private readonly string formattedAnnualPay = $"{annualPay:C}";

        static readonly decimal dailyAllowance = sampleIncome.Allowance / 30;
        static readonly decimal annualAllowance = sampleIncome.Allowance * 12;

        private readonly string formattedDailyAllowance = $"{dailyAllowance:C}";
        private readonly string formattedAnnualAllowance = $"{annualAllowance:C}";
    }
}
