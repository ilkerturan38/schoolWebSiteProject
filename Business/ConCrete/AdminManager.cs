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
    public class AdminManager
    {
        GenericRepository<Admin> repoAdmin = new GenericRepository<Admin>();
        GenericRepository<Teacher> repoTeacher = new GenericRepository<Teacher>();
        GenericRepository<Student> repoStudent = new GenericRepository<Student>();
        GenericRepository<Lesson> repoLesson = new GenericRepository<Lesson>();
        GenericRepository<Episode> repoEpisode = new GenericRepository<Episode>();
        GenericRepository<Notes> repoNotes = new GenericRepository<Notes>();

        public List<Admin> adminList()
        {
            return repoAdmin.getList();
        }

        public List<Teacher> teacherList()
        {
            return repoTeacher.getList();
        }
        public List<Student> studentList()
        {
            return repoStudent.getList();
        }
        public List<Lesson> lessonList()
        {
            return repoLesson.getList();
        }
        public List<Episode> episodeList()
        {
            return repoEpisode.getList();
        }
        public List<Notes> notesList()
        {
            return repoNotes.getList();
        }

        public void Add(Admin p)
        {
            repoAdmin.Insert(p);
        }

        public void Update(Admin p)
        {
            repoAdmin.Update(p);
        }

        public void Delete(int id)
        {
            var sorgu = repoAdmin.getByID(id);
            repoAdmin.Delete(sorgu);
        }

        public Admin getByID(int id)
        {
            return repoAdmin.getByID(id);
        }
        public Admin FindAdmin(string mail)
        {
            return repoAdmin.getByFind(x => x.userName == mail);
        }



    }
}
