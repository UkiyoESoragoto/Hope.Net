using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Hope.Data;
using Hope.Model;
using Hope.Util;
using Hope.View;

namespace Hope.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private List<BarView> _barCollection;
        private Manager _manager;
        private Option _option;
        private ObservableCollection<Process> _processCollection;

        private string _search = string.Empty;

        public MainWindowViewModel()
        {
            _option = new Option();
            _manager = new Manager();
            UpdateCmd = new RelayCommand<Guid>(UpdateById);
            DeleteCmd = new RelayCommand<Guid>(DeleteById);
            SwitchCmd = new RelayCommand<Guid>(Switch);
            CreateCmd = new RelayCommand(CreateProcess);
            RefreshCmd = new RelayCommand(Refresh);
            ApplyCmd = new RelayCommand(RefreshBar);
            CancelCmd = new RelayCommand(RefreshBar);
        }

        public string Search
        {
            get => _search;
            set
            {
                _search = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Process> ProcessCollection
        {
            get => _processCollection;
            set
            {
                _processCollection = value;
                RaisePropertyChanged();
            }
        }

        public List<BarView> BarCollection
        {
            get => _barCollection;
            set
            {
                _barCollection = value;
                RaisePropertyChanged();
            }
        }

        public Option Option
        {
            get => _option;
            set
            {
                _option = value;
                RaisePropertyChanged();
            }
        }

        public Manager Manager
        {
            get => _manager;
            set
            {
                _manager = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand<Guid> UpdateCmd { get; set; }
        public RelayCommand<Guid> DeleteCmd { get; set; }
        public RelayCommand<Guid> SwitchCmd { get; set; }
        public RelayCommand CreateCmd { get; set; }
        public RelayCommand RefreshCmd { get; set; }
        public RelayCommand ApplyCmd { get; set; }
        public RelayCommand CancelCmd { get; set; }

        public void Refresh()
        {
            var processesData = _manager.GetProcessesByName(_search);
            ProcessCollection = new ObservableCollection<Process>();
            processesData?.ForEach(arg => _processCollection.Add(arg));
        }

        public void UpdateById(Guid id)
        {
            var obj = _manager.GetProcessesById(id);
            if (obj == null) return;
            var ret = Helper.JsonDeepCopy(obj);

            var win = new ProcessInfoView(ret);
            var dialog = win.ShowDialog();
            if (!(dialog ?? false)) return;
            Helper.PropertiesTransfer(ret, obj);
            Refresh();
        }

        public void DeleteById(Guid id)
        {
            var obj = _manager.GetProcessesById(id);
            if (obj == null) return;
            var ret = MessageBox.Show($"Delete {obj.Name}?", "Confirm Option", MessageBoxButton.OKCancel,
                MessageBoxImage.Question);
            if (ret != MessageBoxResult.OK) return;
            _manager.DeleteProcessesById(id);
            Refresh();
        }

        public void CreateProcess()
        {
            var ret = new Process();
            var win = new ProcessInfoView(ret);
            var dialog = win.ShowDialog();
            if (!(dialog ?? false)) return;
            _manager.AddProcess(ret);
            Refresh();
        }

        public void RefreshBar()
        {
            var processesData = _manager.GetProcessesByName(string.Empty).OrderBy(arg => arg.GetDelta).ToList();
            if (BarCollection != null)
            {
                BarCollection.ForEach(arg => arg.Close());
                BarCollection.Clear();
            }
            else
            {
                BarCollection = new List<BarView>();
            }

            processesData?.ForEach(arg =>
            {
                var b = new BarView(arg);
                b.Switch();
                b.Show();
                BarCollection.Add(b);
            });
        }

        public void Switch(Guid id)
        {
            // Todo
        }
    }
}