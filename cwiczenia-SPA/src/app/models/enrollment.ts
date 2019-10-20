import { Student } from './student';
import { Subjects } from './subjects';
import { Grades } from './grades';

export interface Enrollment {
    studentId: number;
    student: Student;
    subjectId: number;
    subject: Subjects;
    grade: number;
}
