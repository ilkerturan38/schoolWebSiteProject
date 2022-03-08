using DataAccess.ConCrete;
using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ConCrete
{
    public class LessonManager
    {
        GenericRepository<Lesson> repoLesson = new GenericRepository<Lesson>();

        public List<Lesson> getAll()
        {
            return repoLesson.getList();
        }

        public void Add(Lesson p)
        {
            repoLesson.Insert(p);
        }
        public void Update(Lesson p)
        {
            repoLesson.Update(p);
        }
        public void Delete(int id)
        {
            var sorgu = repoLesson.getByID(id);
            repoLesson.Delete(sorgu);
        }

        public Lesson getByID(int id)
        {
            return repoLesson.getByID(id);
        }

       
    }
}
