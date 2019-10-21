import { Student } from './student';
import { Subjects } from './subjects';

export interface Enrollment {
    studentId: number;
    student: Student;
    subjectId: number;
    subject: Subjects;
    grade: number;
}
