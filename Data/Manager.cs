using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Hope.Model;
using Hope.Util;

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
            LoadFromFile();
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

        public void Save2File()
        {
            var confFile = Helper.GetConfFile();
            var jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(_processes);
            File.WriteAllBytes(confFile, jsonUtf8Bytes);
        }

        public void LoadFromFile()
        {
            var confFile = Helper.GetConfFile();
            var jsonUtf8Bytes = File.ReadAllBytes(confFile);

            var readOnlySpan = new ReadOnlySpan<byte>(jsonUtf8Bytes);
            _processes = readOnlySpan.IsEmpty ? new List<Process> { new() } : JsonSerializer.Deserialize<List<Process>>(readOnlySpan);
        }
    }
}