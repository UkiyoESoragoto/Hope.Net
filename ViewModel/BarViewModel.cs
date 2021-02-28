using System;
using GalaSoft.MvvmLight;
using Hope.Model;

namespace Hope.ViewModel
{
    internal class BarViewModel : ViewModelBase
    {
        public BarViewModel(Process process)
        {
            process ??= new Process();
            Model = process;
        }

        public Process Model { get; }

        public void Save(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    Model.TimeStart = DateTime.Now.TimeOfDay.ToString();
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }
    }
}