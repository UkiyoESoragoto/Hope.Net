using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using Hope.Model;
using Microsoft.Win32;

namespace Hope.ViewModel
{
    class BarViewModel : ViewModelBase
    {
        public BarViewModel(Process process)
        {
            process ??= new Process();
            _model = process;
        }

        private readonly Process _model;

        public Process Model => _model;

        public void Save(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    _model.TimeStart = DateTime.Now.TimeOfDay.ToString();
                    break;
                case 1:
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }
    }
}
