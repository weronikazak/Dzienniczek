using System.Collections.Generic;
using System.Threading.Tasks;
using cwiczenia.API.Models;
using System.Linq;
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
            var classes = await _context.Classes.OrderBy(u => u.ClassName).ToListAsync();

            return classes;
        }

        public async Task<IEnumerable<Enrollments>> GetEnrollments(int studentId)
        {
            var enrollments = await _context.Enrollments.Include(u => u.Student)
                                        .Include(u => u.Subject).Where(u => u.StudentId == studentId).ToListAsync();
            return enrollments;
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
            var students = await _context.Students.OrderBy(u => u.Surname).ToListAsync();

            return students;
        }

        public async Task<IEnumerable<Student>> GetStudentsForClass(int id)
        {
            var students = await _context.Students.Include(u => u.Class)
            .Where(u => u.ClassId == id).OrderBy(u => u.Surname).ToListAsync();

            return students;
        }

        // public async Task<IEnumerable<TeacherSubjects>> GetStudentClass() {
        //     var ts = await _context.TeacherSubjects.Include(u => u.Subject).Include(u => u.Teacher)
        //         .Where(u => u.TeacherId == teacherId && u.SubjectId == subjectId).ToListAsync();
        // }
        public async Task<IEnumerable<TeacherSubjects>> GetTeacherSubjects() {
            var ts = await _context.TeacherSubjects.Include(u => u.Subject).Include(u => u.Teacher)
                .OrderBy(u => u.Teacher.Surname).ToListAsync();

            return ts;
        }



        public async Task<Subjects> GetSubject(int id)
        {
            var subject = await _context.Subjects.Include(t => t.TeacherSubjects).FirstOrDefaultAsync(s => s.Id == id);

            return subject;
        }

        public async Task<IEnumerable<Subjects>> GetSubjects()
        {
            var subjects = await _context.Subjects.OrderBy(u => u.SubjectName).ToListAsync();

            return subjects;
        }

        public async Task<Teacher> GetTeacher(int id)
        {
           var teacher = await _context.Teachers.Include(t => t.TeacherSubjects).FirstOrDefaultAsync(t => t.Id == id);

           return teacher;
        }

        public async Task<IEnumerable<Teacher>> GetTeachers()
        {
            var teachers = await _context.Teachers.Include(t => t.TeacherSubjects).OrderBy(u => u.Surname).ToListAsync();

            return teachers;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }
}