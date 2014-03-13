using PryDelegateCommand.ViewModels;
using System.Windows;

namespace PryDelegateCommand
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new ViewModel();
            vm.ComandoCerrarAplicacionEjecutado += (s, e) => Close();
            DataContext = vm;
        }
    }
}
