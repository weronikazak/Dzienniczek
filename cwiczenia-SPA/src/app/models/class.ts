import { Teacher } from './teacher';
import { Student } from './student';

export interface Class {
    id: number;
    className: string;
    year: number;
    teacherId: number;
    teacher: Teacher;
    students: Student[];
}
