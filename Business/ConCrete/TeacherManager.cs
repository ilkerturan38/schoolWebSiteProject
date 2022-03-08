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
    public class TeacherManager
    {
        GenericRepository<Teacher> repoTeacher = new GenericRepository<Teacher>();
        GenericRepository<StudentvsTeacher> repoStudentvsTeacher = new GenericRepository<StudentvsTeacher>();
        GenericRepository<Lesson> repoLesson = new GenericRepository<Lesson>();
        GenericRepository<Notes> repoNotes = new GenericRepository<Notes>();

        public List<Teacher> getAll()
        {
            return repoTeacher.getList();
        }

        public List<Lesson> GetTeacherByID(int id)
        {
            return repoLesson.ByList(x => x.teacherID == id);
        }

        public List<StudentvsTeacher> GetTeacherByID2(int id) // Öğretmen ID'ye göre, Öğrencileri Listeleme
        {
            return repoStudentvsTeacher.ByList(x => x.teacherID == id);
        }

        public List<Notes> GetTeacherByID3(int id) // Öğretmen ID'ye göre, Öğrencilerin Notlarını Listeleme
        {
            return repoNotes.ByList(x=>x.teacherID==id);
        }

        public void Add(Teacher p)
        {
            repoTeacher.Insert(p);
        }

        public void Update(Teacher p)
        {
            repoTeacher.Update(p);
        }

        public void Delete(int id)
        {
            var sorgu = repoTeacher.getByID(id);
            repoTeacher.Delete(sorgu);
        }

        public Teacher getByID(int id)
        {
            return repoTeacher.getByID(id);
        }

        public Teacher FindTeacher(string mail)
        {
            return repoTeacher.getByFind(x => x.userName == mail);
        }

    }
}
