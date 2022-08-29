using Microsoft.UI.Xaml;

namespace Badyet.App
{ 
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            //Window window = App.MainWindow;
            this.ExtendsContentIntoTitleBar = true;
            this.SetTitleBar(AppTitleBar);  // this line is optional as by it is null by default
        }
    }
}
