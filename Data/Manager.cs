using System;
using System.Collections.Generic;
using System.Linq;
using Hope.Model;

namespace Hope.Data
{
    internal class Manager
    {
        private List<Process> _processes;

        public Manager()
        {
            Init();
        }

        private void Init()
        {
            _processes = new List<Process> {new()};
        }

        public List<Process> GetProcesses()
        {
            return _processes;
        }

        public void AddProcess(Process process)
        {
            if (_processes.Count >= 8) return;
            _processes.Add(process);
        }

        public void RemoveProcess(Process process)
        {
            _processes.Remove(process);
        }

        public List<Process> GetProcessesByName(string name)
        {
            return _processes.Where(q => q.Name.Contains(name)).ToList();
        }

        public Process GetProcessesById(Guid id)
        {
            return _processes.FirstOrDefault(obj => obj.Id == id);
        }

        public void DeleteProcessesById(Guid id)
        {
            var ret = _processes.FirstOrDefault(obj => obj.Id == id);
            _processes.Remove(ret);
        }
    }
}