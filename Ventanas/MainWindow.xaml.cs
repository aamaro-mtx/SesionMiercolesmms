using System.Windows;
using Ventanas.ViewModels;
using Ventanas.Views;

namespace Ventanas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new WindowViewModel();
            vm.CommandShowWindowExecuted += (sender, args) =>
            {
                var about = new Dialogo();
                about.ShowDialog();
            };
            DataContext = vm;
        }


    }
}
