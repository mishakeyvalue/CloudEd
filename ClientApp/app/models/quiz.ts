import { Question } from './question';

export class Quiz {
    public id: number;
    public title: string;
    public description: string;
    public questions: Question[];
}