import { Answer } from './answer';

export class Question {
    public id: number;
    public title: string;
    public answers: Answer[];
    public selectedAnswer: Answer;
}