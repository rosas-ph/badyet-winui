using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badyet.App.Pages
{
    internal static class Settings
    {
        public const string FeatureName = "Badyet Setting";
        public static ElementTheme CurrentTheme = ElementTheme.Default;
    }

    public partial class MainPage : Page
    {
        private readonly List<Scenario> scenarios = new()
            {
                new Scenario() { Title = "Income", ClassName = typeof(IncomePage).FullName },
                new Scenario() { Title = "Expenses", ClassName = typeof(ExpensesPage).FullName },
            };
    }

    public class Scenario
    {
        public string Title { get; set; }
        public string ClassName { get; set; }
    }
}
