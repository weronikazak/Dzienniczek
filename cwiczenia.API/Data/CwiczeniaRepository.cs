using System.Collections.Generic;
using System.Threading.Tasks;
using cwiczenia.API.Models;
using Microsoft.EntityFrameworkCore;

namespace cwiczenia.API.Data
{
    public class CwiczeniaRepository : ICwiczeniaRepository
    {
        private readonly DataContext _context;

        public CwiczeniaRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Class> GetClass(int id)
        {
            var clas = await _context.Classes.FirstOrDefaultAsync(c => c.Id == id);

            return clas;
        }

        public async Task<IEnumerable<Class>> GetClasses()
        {
            var classes = await _context.Classes.ToListAsync();

            return classes;
        }

        public async Task<IEnumerable<Enrollments>> GetEnrollments(int studentId)
        {

            var student = await _context.Students.Include(u => u.Enrollments)
                                .Include(u => u.Class).FirstOrDefaultAsync(u => u.Id == studentId);

            return student.Enrollments;
        }

        public async Task<IEnumerable<Enrollments>> GetEnrollment()
        {
            var enrollment = await _context.Enrollments.
                            Include(s => s.Subject).Include(u => u.Student).
                            ToListAsync();

            return enrollment;
        }

        public async Task<Student> GetStudent(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);

            return student;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            var students = await _context.Students.ToListAsync();

            return students;
        }

        public async Task<Subjects> GetSubject(int id)
        {
            var subject = await _context.Subjects.FirstOrDefaultAsync(s => s.Id == id);

            return subject;
        }

        public async Task<IEnumerable<Subjects>> GetSubjects()
        {
            var subjects = await _context.Subjects.ToListAsync();

            return subjects;
        }

        // public async Task<Teacher> GetTeacher(int id)
        // {
        //    var teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.Id == id);

        //    return teacher;
        // }

        // public async Task<IEnumerable<Teacher>> GetTeachers()
        // {
        //     var teachers = await _context.Teachers.ToListAsync();

        //     return teachers;
        // }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }
}