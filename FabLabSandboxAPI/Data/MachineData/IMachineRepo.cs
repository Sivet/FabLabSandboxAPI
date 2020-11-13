using System.Collections.Generic;
using FabLabSandboxAPI.Models;
using System;

namespace FabLabSandboxAPI.Data.MachineData
{
    public interface IMachineRepo
    {
        bool SaveChanges();
        IEnumerable<Machine> GetAllMachines();
        Machine GetMachineById(Guid id);
        Machine GetMachineByName(string name);
        void CreateMachine(Machine space);
        void UpdateMachine(Machine space);
        void DeleteMachine(Machine space);
    }
}
