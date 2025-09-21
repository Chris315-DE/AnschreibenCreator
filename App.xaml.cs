using AnschreibenCreator.Lib.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace AnschreibenCreator.Lib
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            ShellView window = new ShellView();
            window.DataContext = new ShellViewModel(window);
            window.Show();
            base.OnStartup(e);

        }
    }

}
