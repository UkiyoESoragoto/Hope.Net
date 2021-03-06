﻿using GalaSoft.MvvmLight;

namespace Hope.Model
{
    public class Option : ObservableObject
    {
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }
    }
}