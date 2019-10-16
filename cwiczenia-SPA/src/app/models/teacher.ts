import { Class } from './class';

export interface Teacher {
    id: number;
    name: string;
    surname: string;
    photo: number[];
    classId: number;
    class: Class;
}
