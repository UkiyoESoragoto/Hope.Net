using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;

namespace Hope.Model
{
    public class Process : ObservableObject
    {
        private readonly Guid _id;
        private string _name;
        private string _time;
        private int _percent;

        public Process(Guid id)
        {
            _id = id;
        }

        public Process()
        {
            _id = new Guid();
        }

        public Guid Id { get; }

        public string Name
        {
            get => _name;
            set { _name = value; RaisePropertyChanged(); }
        }

        public string Time
        {
            get => _time;
            set { _time = value; RaisePropertyChanged(); }
        }

        public int Percent
        {
            get => _percent;
            set { _percent = value; RaisePropertyChanged(); }
        }
    }
}
