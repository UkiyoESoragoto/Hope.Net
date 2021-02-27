using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;

namespace Hope.Model
{
    public class Process : ObservableObject
    {
        private Guid _id;
        private string _name;
        private TimeSpan _timeStart;
        private TimeSpan _timeEnd;
        private double _percent = 50;
        private double _delta = 0;

        public Process(Guid id)
        {
            _id = id;
        }

        public Process()
        {
            _id = Guid.NewGuid();
        }

        public Guid Id
        {
            get => _id;
            set { _id = value; RaisePropertyChanged(); }
        }

        public string Name
        {
            get => _name;
            set { _name = value; RaisePropertyChanged(); }
        }

        public TimeSpan GetTimeStart => _timeStart;
        public TimeSpan GetTimeEnd => _timeEnd;

        public string TimeStart
        {
            get => _timeStart.ToString();
            set
            {
                try
                {
                    _timeStart = TimeSpan.Parse(value);
                    if (_timeStart > _timeEnd) return;
                    Delta = (_timeEnd - _timeStart).TotalSeconds;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e);
                    return;
                }
                RaisePropertyChanged();
            }
        }

        public string TimeEnd
        {
            get => _timeEnd.ToString();
            set
            {
                try
                {
                    _timeEnd = TimeSpan.Parse(value);
                    if (_timeStart > _timeEnd) return;
                    Delta = (_timeEnd - _timeStart).TotalSeconds;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e);
                    return;
                }
                RaisePropertyChanged();
            }
        }

        public double Percent
        {
            get => _percent;
            set { _percent = value >= 0 ? value : 0; RaisePropertyChanged(); }
        }

        public double Delta
        {
            get => _delta;
            set { _delta = value >= 0 ? value : 0; RaisePropertyChanged(); }
        }
    }
}
