import { Answer } from './answer';

export class Question {
    public id: string;
    public title: string;
    public answers: Answer[];
    public selectedAnswer: Answer;
}