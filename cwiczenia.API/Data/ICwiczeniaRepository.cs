using System.Threading.Tasks;
using cwiczenia.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace cwiczenia.API.Data
{
    public interface ICwiczeniaRepository
    {
        Task<bool> SaveAll();
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<Student> GetStudents();
        Task<Student> GetStudent(int id);
        Task<Student> UpdateStudent(int id);
        Task<Grade> GetGrades();
    }
}