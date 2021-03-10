using System.Windows;
using Hope.Model;
using Hope.ViewModel;

namespace Hope.View
{
    /// <summary>
    ///     Interaction logic for ProcessInfoView.xaml
    /// </summary>
    public partial class ProcessInfoView : Window
    {
        private readonly ProcessViewModel _viewModel;

        public ProcessInfoView(Process process)

        {
            InitializeComponent();
            _viewModel = new ProcessViewModel(process);
            DataContext = _viewModel;
        }

        private void ButtonOkOnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.Save(TabControl.SelectedIndex);
            DialogResult = true;
        }

        private void ButtonCancelOnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ButtonColor_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}