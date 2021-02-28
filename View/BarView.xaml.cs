using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Hope.Model;
using static System.Windows.Media.ColorConverter;

namespace Hope.View
{
    /// <summary>
    ///     Interaction logic for BarView.xaml
    /// </summary>
    public partial class BarView : Window
    {
        private readonly DispatcherTimer _timer = new() {Interval = TimeSpan.FromMilliseconds(1000 / 60.0)};

        public BarView(Process process)
        {
            if (process == null)
            {
                Close();
                return;
            }

            ;
            InitializeComponent();
            Process = process;
            DataContext = new {Model = process};
            SetUi();
            SetTimerTick();
        }

        public Process Process { get; }

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
            Bar.Foreground =
                new SolidColorBrush((Color?) ConvertFromString(Process.ForegroundSting) ??
                                    Color.FromRgb(255, 255, 255));
        }

        private void Refresh()
        {
            var now = DateTime.Now;
            var start = DateTime.Today + Process.GetTimeStart;
            var tmp = TimeSpan.Parse(Process.Delta).TotalSeconds;
            Process.Percent = tmp > 0 ? (now - start).TotalSeconds / tmp * 100 : 0;
        }

        private void SetTimerTick()
        {
            _timer.Tick += (sender, args) => Refresh();
        }

        public void Switch()
        {
            if (_timer.IsEnabled) _timer.Stop();
            else _timer.Start();
        }
    }
}