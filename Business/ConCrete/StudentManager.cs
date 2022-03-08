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
    public class StudentManager
    {
        GenericRepository<Student> repoStudent = new GenericRepository<Student>();
        GenericRepository<Lesson> repoLesson = new GenericRepository<Lesson>();
        GenericRepository<Notes> repoNotes = new GenericRepository<Notes>();

        public List<Student> getAll()
        {
            return repoStudent.getList();
        }
        public List<Lesson> GetStudentByID(int id) // ÖğrenciID'ye göre,Öğrencinin Girdiği Dersleri Listeleme
        {
            return repoLesson.ByList(x => x.StudentID == id);
        }
        public List<Notes> GetStudentByID2(int id) // ÖğrenciID'ye göre,Öğrencinin Aldığı Notları Listeleme
        {
            return repoNotes.ByList(x=>x.studentID==id);
        }
        public void Add(Student p)
        {
            repoStudent.Insert(p);
        }

        public void Update(Student p)
        {
            repoStudent.Update(p);
        }

        public void Delete(int id)
        {
            var sorgu = repoStudent.getByID(id);
            repoStudent.Delete(sorgu);
        }

        public Student getByID(int id)
        {
            return repoStudent.getByID(id);
        }

        public Student FindStudent(string mail)
        {
            return repoStudent.getByFind(x => x.userName == mail);
        }

        

    }
}
