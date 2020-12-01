using System;
using System.Collections.Generic;
using System.Linq;
using FabLabSandboxAPI.Models;

namespace FabLabSandboxAPI.Data
{
    public class SqlMakerSpaceRepo : IMakerSpaceRepo
    {
        private readonly MakerSpaceContext _context;

        public SqlMakerSpaceRepo(MakerSpaceContext context)
        {
            _context = context;
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
        public void CreateMakerSpace(MakerSpace space)
        {
            if (space == null)
            {
                throw new ArgumentNullException(nameof(space));
            }
            space.MakerSpaceId = Guid.NewGuid(); //maybe bad idea, db does it anyway.
            _context.Add(space);
        }

        public IEnumerable<MakerSpace> GetAllMakerSpaces()
        {
            return _context.MakerSpaces.ToList();
            //throw new System.NotImplementedException();
        }

        public MakerSpace GetMakerSpaceById(Guid id)
        {
            return _context.MakerSpaces.FirstOrDefault(p => p.MakerSpaceId == id);
            //throw new System.NotImplementedException();
        }

        public MakerSpace GetMakerSpaceByName(string name)
        {
            return _context.MakerSpaces.FirstOrDefault(p => p.MakerSpaceName == name);
            //throw new System.NotImplementedException();
        }
        public MakerSpace GetMakerSpaceByPostCode(string postCode)
        {
            return _context.MakerSpaces.FirstOrDefault(p => p.ZipCode == postCode);
            //throw new System.NotImplementedException();
        }

        public void UpdateMakerSpace(MakerSpace space)
        {
            _context.Update(space);

            //check optimistic concurrency!!!
            // if(space == null){
            //   throw new ArgumentNullException(nameof(space));
            // }
            // _context.Add(space);
            //   _context.Entry(space).OriginalValues["RowVersion"] = space.RowVersion;

        }

        public void DeleteMakerSpace(MakerSpace space)
        {
            if (space == null)
            {
                throw new ArgumentNullException(nameof(space));
            }
            _context.MakerSpaces.Remove(space);
        }
    }
}