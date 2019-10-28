import { Teacher } from './teacher';

export interface Subjects {
    id: number;
    subjectName: string;
    teacherId?: number;
    teacher: Teacher;
}
