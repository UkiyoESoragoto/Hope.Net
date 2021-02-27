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
            SetLocation();
            RefreshProcess();
        }

        private readonly Process _process;

        private void SetLocation()
        {
            var x = SystemParameters.WorkArea.Width;//得到屏幕工作区域宽度
            var y = SystemParameters.WorkArea.Height;//得到屏幕工作区域高度
            var x1 = SystemParameters.PrimaryScreenWidth;//得到屏幕整体宽度
            var y1 = SystemParameters.PrimaryScreenHeight;//得到屏幕整体高度
            Width = x;//设置窗体宽s度
            Height = 20;//设置窗体高度
            Bar.Width = x;
            Left = 0;
            Top = y1 - y;
        }

        private void RefreshProcess()
        {
            var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(100) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                _process.Percent += 0.1;
                if (_process.Percent > 100) _process.Percent = 0;
            };
        }
    }
}
