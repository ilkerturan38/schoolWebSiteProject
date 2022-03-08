using DataAccess.ConCrete;
using Entity;
using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ConCrete
{
    public class NotesManager
    {
        GenericRepository<Notes> repoNotes = new GenericRepository<Notes>();

        public List<Notes> getAll()
        {
            return repoNotes.getList();
        }
        public void Add(Notes p)
        {
            repoNotes.Insert(p);
        }
        public void Update(Notes p)
        {
            repoNotes.Update(p);
        }
        public void Delete(int id)
        {
            var sorgu = repoNotes.getByID(id);
            repoNotes.Delete(sorgu);
        }

        public Notes getByID(int id)
        {
            return repoNotes.getByID(id);
        }
    }
}
