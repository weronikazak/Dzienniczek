using System.Collections.Generic;
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
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int id);
        Task<IEnumerable<Subjects>> GetSubjects();
        Task<Subjects> GetSubject(int id);
        // Task<IEnumerable<Teacher>> GetTeachers();
        // Task<Teacher> GetTeacher(int id);
        Task<Class> GetClass(int id);
        Task<IEnumerable<Class>> GetClasses();
        Task<IEnumerable<Enrollments>> GetEnrollments(int studentId);
        Task<IEnumerable<Enrollments>> GetEnrollment();
    }
}