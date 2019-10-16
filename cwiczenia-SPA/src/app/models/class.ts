import { Teacher } from './teacher';
import { Student } from './student';

export interface Class {
    id: number;
    name: string;
    teacherId: number;
    teacher: Teacher;
    students: Student[];
}
