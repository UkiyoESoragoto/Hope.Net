using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Documents;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Hope.Model;
using Hope.Data;
using Hope.View;

namespace Hope.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {

        public MainWindowViewModel()
        {
            _option = new Option() { Name = "abc" };
            _manager = new Manager();
            UpdateCmd = new RelayCommand<Guid>(UpdateById);
            DeleteCmd = new RelayCommand<Guid>(DeleteById);
        }

        private Option _option;
        private Manager _manager;
        private ObservableCollection<Process> _processCollection;

        public ObservableCollection<Process> ProcessCollection
        {
            get => _processCollection;
            set { _processCollection = value; RaisePropertyChanged(); }
        }

        public Option Option
        {
            get => _option; 
            set { _option = value; RaisePropertyChanged(); }
        }

        public Manager Manager
        {
            get => _manager;
            set { _manager = value; RaisePropertyChanged(); }
        }

        public void Query()
        {
            var processesData = _manager.GetProcesses();
            _processCollection = new ObservableCollection<Process>();
            processesData?.ForEach(arg => _processCollection.Add(arg));
        }

        public RelayCommand<Guid> UpdateCmd { get; set; }
        public RelayCommand<Guid> DeleteCmd { get; set; }

        public void UpdateById(Guid id)
        {
            var obj = _manager.GetProcessesById(id);
            if (obj == null) return;
            var win = new ProcessInfo(obj);
            var dialog = win.ShowDialog();
            if (!(dialog ?? false)) return;
            var ret = _processCollection.FirstOrDefault(arg => arg.Id == obj.Id);
            ret.Name = obj.Name;
        }

        public void DeleteById(Guid id)
        {
            var obj = _manager.GetProcessesById(id);
            if (obj == null) return;
            var ret = MessageBox.Show($"Delete{obj.Name}", "Confirm Option", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (ret == MessageBoxResult.OK)
            {

            }
        }
    }
}
