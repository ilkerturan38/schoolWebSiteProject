using DataAccess.ConCrete;
using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ConCrete
{
    public class EpisodeManager
    {
        GenericRepository<Episode> repoEpisode = new GenericRepository<Episode>();

        public List<Episode> getAll()
        {
            return repoEpisode.getList();
        }

        public void Add(Episode p)
        {
           repoEpisode.Insert(p);
        }

        public void Update(Episode p)
        {
            repoEpisode.Update(p);
        }

        public void Delete(int id)
        {
            var sorgu = repoEpisode.getByID(id);
            repoEpisode.Delete(sorgu);
        }

        public Episode getByID(int id)
        {
            return repoEpisode.getByID(id);
        }

    }
}
