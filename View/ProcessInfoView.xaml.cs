using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Hope.Model;
using Hope.ViewModel;

namespace Hope.View
{
    /// <summary>
    /// Interaction logic for ProcessInfoView.xaml
    /// </summary>
    public partial class ProcessInfoView : Window
    {
        public ProcessInfoView(Process process)

        {
            InitializeComponent();
            _viewModel = new BarViewModel(process);
            DataContext = _viewModel;
        }

        private readonly BarViewModel _viewModel;

        private void ButtonOkOnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.Save(TabControl.SelectedIndex);
            DialogResult = true;
        }

        private void ButtonCancelOnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
