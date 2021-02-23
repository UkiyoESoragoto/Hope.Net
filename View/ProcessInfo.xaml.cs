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

namespace Hope.View
{
    /// <summary>
    /// Interaction logic for ProcessInfo.xaml
    /// </summary>
    public partial class ProcessInfo : Window
    {
        public ProcessInfo(Process process)

        {
            process ??= new Process();
            InitializeComponent();
            DataContext = new { Model = process };
        }

        private void ButtonOkOnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void ButtonCancelOnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
