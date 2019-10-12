using System.Threading.Tasks;
using cwiczenia.API.Models;

namespace cwiczenia.API.Data
{
    public class CwiczeniaRepository : ICwiczeniaRepository
    {
        public void Add<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<Grade> GetGrades()
        {
            throw new System.NotImplementedException();
        }

        public Task<Student> GetStudent(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Student> GetStudents()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Student> UpdateStudent(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}