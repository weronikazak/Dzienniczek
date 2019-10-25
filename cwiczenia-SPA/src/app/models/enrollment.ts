import { Student } from './student';
import { Subjects } from './subjects';

export interface Enrollment {
    id: number;
    studentId: number;
    student: Student;
    subjectId: number;
    subject: Subjects;
    grade: number;
}
