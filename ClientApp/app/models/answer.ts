import { Question } from './question';

export class Answer {
    public id: string;
    public body: string;
    public questionId: string;
    public isSelected: boolean = false;
}