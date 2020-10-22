using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FabLabSandboxAPI.Models;

namespace FabLabSandboxAPI.Data.MachineData
{
    public class SqlMachineRepo : IMachineRepo
    {
        private readonly MakerSpaceContext _context;

        public SqlMachineRepo(MakerSpaceContext context)
        {
            _context = context;
        }
         public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
        public void CreateMachine(Machine space)
        {
            if(space == null){
                throw new ArgumentNullException(nameof(space));
            }
            _context.Add(space);
        }

        public IEnumerable<Machine> GetAllMachines()
        {

            return _context.Machines.ToList();
            //throw new System.NotImplementedException();
        }

        public Machine GetMachineById(int id)
        {
            return _context.Machines.FirstOrDefault(p => p.MachineId == id);
            //throw new System.NotImplementedException();
        }

        public Machine GetMachineByName(string name)
        {
            return _context.Machines.FirstOrDefault(p => p.MachineName == name);
            //throw new System.NotImplementedException();
        }

        public void UpdateMachine(Machine space)
        {

            
            //check optimistic concurrency!!!
           // if(space == null){
             //   throw new ArgumentNullException(nameof(space));
           // }
           // _context.Add(space);
             //   _context.Entry(space).OriginalValues["RowVersion"] = space.RowVersion;

        }

        public void DeleteMachine(Machine space)
        {
             if (space==null)
            {
                throw new ArgumentNullException(nameof(space));
            }
            _context.Machines.Remove(space);
        }
    }
}