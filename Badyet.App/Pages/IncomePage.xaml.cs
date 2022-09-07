using Badyet.App.Models;
using Badyet.App.Components;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Threading.Tasks;

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
            BasicPay = 18_000M,
            Allowance = 3_600M,
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

        private async void UpdateIncome_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new()
            {
                // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
                XamlRoot = this.XamlRoot,
                Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
                Title = "Update income",
                PrimaryButtonText = "Save",
                SecondaryButtonText = "Don't Save",
                CloseButtonText = "Cancel",
                DefaultButton = ContentDialogButton.Primary,
                Content = new UpdateIncomeContentDialog()
            };

            var result = await dialog.ShowAsync();

        }
    }
}
