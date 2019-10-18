import { Class } from './class';

export interface Teacher {
    id: number;
    name: string;
    surname: string;
    photo: string;
    classId: number;
    class: Class;
}
