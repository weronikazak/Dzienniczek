import { Class } from './class';
import { Subjects } from './subjects';

export interface Teacher {
    id: number;
    name: string;
    surname: string;
    fullName: string;
    photo: string;
    dateOfBirth: Date;
    classId?: number;
    class: Class;
    subject: Subjects[];
}
