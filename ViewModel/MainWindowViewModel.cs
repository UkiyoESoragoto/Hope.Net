using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Documents;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Hope.Model;
using Hope.Data;
using Hope.View;
using Hope.Util;

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
            CreateCmd = new RelayCommand(CreateProcess);
        }

        private Option _option;
        private Manager _manager;
        private ObservableCollection<Process> tmp;

        public ObservableCollection<Process> ProcessCollection
        {
            get => tmp;
            set { tmp = value; RaisePropertyChanged(); }
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

        public void Refresh()
        {
            var processesData = _manager.GetProcesses();
            tmp = new ObservableCollection<Process>();
            processesData?.ForEach(arg => tmp.Add(arg));
            ProcessCollection = tmp;
        }

        public RelayCommand<Guid> UpdateCmd { get; set; }
        public RelayCommand<Guid> DeleteCmd { get; set; }
        public RelayCommand CreateCmd { get; set; }

        public void UpdateById(Guid id)
        {
            var obj = _manager.GetProcessesById(id);
            if (obj == null) return;
            var ret = Tool.JsonDeepCopy(obj);

            var win = new ProcessInfo(ret);
            var dialog = win.ShowDialog();
            if (!(dialog ?? false)) return;
            _manager.DeleteProcessesById(id);
            _manager.AddProcess(ret);
            Refresh();
        }

        public void DeleteById(Guid id)
        {
            var obj = _manager.GetProcessesById(id);
            if (obj == null) return;
            var ret = MessageBox.Show($"Delete{obj.Name}", "Confirm Option", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (ret != MessageBoxResult.OK) return;
            _manager.DeleteProcessesById(id);
            Refresh();
        }

        public void CreateProcess()
        {
            var ret = new Process();
            var win = new ProcessInfo(ret);
            var dialog = win.ShowDialog();
            if (!(dialog ?? false)) return;
            _manager.AddProcess(ret);
            Refresh();
        }
    }
}
