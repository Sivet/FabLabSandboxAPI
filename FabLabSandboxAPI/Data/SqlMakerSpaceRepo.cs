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
        public IEnumerable<MakerSpace> GetAllMakerSpaces()
        {
            return _context.MakerSpaces.ToList();
            //throw new System.NotImplementedException();
        }

        public MakerSpace GetMakerSpaceById(int id)
        {
            return _context.MakerSpaces.FirstOrDefault(p => p.Id == id);
            //throw new System.NotImplementedException();
        }

        public MakerSpace GetMakerSpaceByName(string name)
        {
            return _context.MakerSpaces.FirstOrDefault(p => p.name == name);
            //throw new System.NotImplementedException();
        }
    }
}