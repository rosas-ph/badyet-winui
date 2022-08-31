using Badyet.App.ControlPages;
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
        readonly string formattedBasicPay = $"{sampleIncome.BasicPay:C}";
        readonly string formattedAllowance = $"{sampleIncome.Allowance:C}";
        readonly string incomeType = sampleIncome.Type;
        readonly string incomeName = sampleIncome.Name;

        static readonly decimal dailyPay = sampleIncome.BasicPay / 30;
        static readonly decimal annualPay = sampleIncome.BasicPay * 12;

        readonly string formattedDailyPay = $"{dailyPay:C}";
        readonly string formattedAnnualPay = $"{annualPay:C}";

        static readonly decimal dailyAllowance = sampleIncome.Allowance / 30;
        static readonly decimal annualAllowance = sampleIncome.Allowance * 12;

        readonly string formattedDailyAllowance = $"{dailyAllowance:C}";
        readonly string formattedAnnualAllowance = $"{annualAllowance:C}";


        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog();

            dialog.XamlRoot = this.XamlRoot;
            dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
            dialog.Title = "Update basic pay?";
            dialog.PrimaryButtonText = "Save";
            dialog.CloseButtonText = "Cancel";
            dialog.DefaultButton = ContentDialogButton.Primary;
            dialog.Content = new UpdateContentDialog();

            var result = await dialog.ShowAsync();
        }
    }
}
