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
        private int _delta = 0;

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

        public TimeSpan TimeStart
        {
            get => _timeStart;
            set { _timeStart = value; RaisePropertyChanged(); }
        }

        public int TimeStartHour
        {
            get => _timeStart.Hours;
            set
            {
                _timeStart = new TimeSpan(value, _timeStart.Minutes, _timeStart.Seconds);
                RaisePropertyChanged();
            }
        }

        public int TimeStartMin
        {
            get => _timeStart.Minutes;
            set
            {
                _timeStart = new TimeSpan(_timeStart.Hours, value, _timeStart.Seconds);
                RaisePropertyChanged();
            }
        }

        public int TimeStartSec
        {
            get => _timeStart.Seconds;
            set
            {
                _timeStart = new TimeSpan(_timeStart.Hours, _timeStart.Minutes, value);
                RaisePropertyChanged();
            }
        }

        public TimeSpan TimeEnd
        {
            get => _timeEnd;
            set { _timeEnd = value; RaisePropertyChanged(); }
        }

        public int TimeEndHour
        {
            get => _timeEnd.Hours;
            set
            {
                _timeEnd = new TimeSpan(value, _timeEnd.Minutes, _timeEnd.Seconds);
                RaisePropertyChanged();
            }
        }

        public int TimEndtMin
        {
            get => _timeEnd.Minutes;
            set
            {
                _timeEnd = new TimeSpan(_timeEnd.Hours, value, _timeEnd.Seconds);
                RaisePropertyChanged();
            }
        }

        public int TimEndtSec
        {
            get => _timeEnd.Seconds;
            set
            {
                _timeEnd = new TimeSpan(_timeEnd.Hours, _timeEnd.Minutes, value);
                RaisePropertyChanged();
            }
        }

        public double Percent
        {
            get => _percent;
            set { _percent = value >= 0 ? value : 0; RaisePropertyChanged(); }
        }

        public int Delta
        {
            get => _delta;
            set { _delta = value >= 0 ? value : 0; RaisePropertyChanged(); }
        }
    }
}
