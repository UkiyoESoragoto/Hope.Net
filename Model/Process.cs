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
        private double _percent = 50;
        private int _order = 0;

        public Process(Guid id)
        {
            _id = id;
        }

        public Process()
        {
            _id = Guid.NewGuid();
        }

        public Guid Id => _id;

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

        public double Percent
        {
            get => _percent;
            set { _percent = value >= 0 ? value : 0; RaisePropertyChanged(); }
        }

        public int Order
        {
            get => _order;
            set { _order = value >= 0 ? value : 0; RaisePropertyChanged(); }
        }
    }
}
