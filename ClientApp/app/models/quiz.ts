import { Question } from './question';

export class Quiz {
    public id: string;
    public title: string;
    public description: string;
    public questions: Question[];
}