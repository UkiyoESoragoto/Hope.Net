using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Hope.Model;

namespace Hope.View
{
    /// <summary>
    /// Interaction logic for BarView.xaml
    /// </summary>
    public partial class BarView : Window
    {
        public BarView(Process process)
        {
            if (process == null)
            {
                Close();
                return;
            };
            InitializeComponent();
            _process = process;
            DataContext = new { Model = process };
            SetUi();
            SetTimerTick();
        }

        private readonly Process _process;
        private readonly DispatcherTimer _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1000 / 60.0) };

        public Process Process => _process;

        private void SetUi()
        {
            var workAreaWidth = SystemParameters.WorkArea.Width;
            var workAreaHeight = SystemParameters.WorkArea.Height;
            var primaryScreenWidth = SystemParameters.PrimaryScreenWidth;
            var primaryScreenHeight = SystemParameters.PrimaryScreenHeight;
            Width = workAreaWidth;
            Height = 20;
            Left = 0;
            Top = primaryScreenHeight - workAreaHeight;
            Bar.Width = workAreaWidth;
        }

        private void Refresh()
        {
            var now = DateTime.Now;
            var start = DateTime.Today + _process.GetTimeStart;
            _process.Percent = _process.Delta > 0 ? (now - start).TotalSeconds / _process.Delta * 100 : 0;
        }

        private void SetTimerTick()
        {
            _timer.Tick += (sender, args) => Refresh();
        }

        public void Switch()
        {
            if (_timer.IsEnabled) _timer.Stop(); else _timer.Start();
        }
    }
}
