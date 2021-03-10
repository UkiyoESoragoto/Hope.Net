using System;
using GalaSoft.MvvmLight;
using static System.Windows.Media.ColorConverter;

namespace Hope.Model
{
    public class Process : ObservableObject
    {
        private TimeSpan _delta;
        private string _foreground = "#FFF";
        private Guid _id;
        private string _name;
        private double _percent;
        private TimeSpan _timeEnd;
        private TimeSpan _timeStart;

        public Process(Guid id)
        {
            _id = id;
            _name = "Task";
        }

        public Process()
        {
            _id = Guid.NewGuid();
            _name = "Task";
        }

        public Guid Id
        {
            get => _id;
            set
            {
                _id = value;
                RaisePropertyChanged();
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }

        public TimeSpan TimeStart
        {
            get => _timeStart;
            set
            {
                _timeStart = value;
                RaisePropertyChanged();
            }
        }

        public TimeSpan TimeEnd
        {
            get => _timeEnd;
            set
            {
                _timeEnd = value;
                RaisePropertyChanged();
            }
        }

        public double Percent
        {
            get => _percent;
            set
            {
                _percent = value >= 0 ? value : 0;
                RaisePropertyChanged();
            }
        }

        public double GetDelta => _delta.TotalSeconds;

        public string Delta
        {
            get => _delta.ToString();
            set
            {
                try
                {
                    if (_delta.ToString() == value) return;
                    _delta = TimeSpan.Parse(value);
                    var tmp = _timeStart + _delta;
                    if (_timeStart > tmp) return;
                    TimeEnd = tmp;
                }
                catch (Exception e) when (e is FormatException or OverflowException)
                {
                    Console.WriteLine(e);
                    return;
                }

                RaisePropertyChanged();
            }
        }

        public string ForegroundSting
        {
            get => _foreground;
            set
            {
                try
                {
                    if (ConvertFromString(value) == null) return;
                    _foreground = value;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e);
                    return;
                }

                RaisePropertyChanged();
            }
        }
    }
}