using System;
using GalaSoft.MvvmLight;
using Hope.Model;

namespace Hope.ViewModel
{
    public class ProcessViewModel : ViewModelBase
    {
        public ProcessViewModel(Process process)
        {
            process ??= new Process();
            Model = process;
        }

        public Process Model { get; }

        public TimeSpan GetTimeStart
        {
            get => Model.TimeStart;
            set
            {
                Model.TimeStart = value;
                RaisePropertyChanged();
            }
        }

        public TimeSpan GetTimeEnd
        {
            get => Model.TimeEnd;
            set
            {
                Model.TimeEnd = value;
                RaisePropertyChanged();
            }
        }

        public void Save(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    Model.TimeStart = DateTime.Now.TimeOfDay;
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }

        public string TimeStart
        {
            get => Model.TimeStart.ToString();
            set
            {
                try
                {
                    if (Model.TimeStart.ToString() == value) return;
                    Model.TimeStart = TimeSpan.Parse(value);
                    if (Model.TimeStart > Model.TimeEnd) return;
                    Model.Delta = (Model.TimeEnd - Model.TimeStart).ToString();
                }
                catch (Exception e) when (e is FormatException or OverflowException)
                {
                    Console.WriteLine(e);
                    return;
                }

                RaisePropertyChanged();
            }
        }

        public string TimeEnd
        {
            get => Model.TimeEnd.ToString();
            set
            {
                try
                {
                    if (Model.TimeEnd.ToString() == value) return;
                    Model.TimeEnd = TimeSpan.Parse(value);
                    if (Model.TimeStart > Model.TimeEnd) return;
                    Model.Delta = (Model.TimeEnd - Model.TimeStart).ToString();
                }
                catch (Exception e) when (e is FormatException or OverflowException)
                {
                    Console.WriteLine(e);
                    return;
                }

                RaisePropertyChanged();
            }
        }
    }
}