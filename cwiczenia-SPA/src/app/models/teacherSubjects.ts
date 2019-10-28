import { Teacher } from './teacher';
import { Subjects } from './subjects';

export interface TeacherSubjects {
    id: number;
    teacherId: number;
    teacher: Teacher;
    subjectId: number;
    subject: Subjects;
}
