using System.Windows;
using Hope.ViewModel;

namespace Hope
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new MainWindowViewModel();
            viewModel.Refresh();
            viewModel.RefreshBar();
            DataContext = viewModel;

            About.Text = "By UkiyoESoragoto\nAlpha version";
        }
    }
}