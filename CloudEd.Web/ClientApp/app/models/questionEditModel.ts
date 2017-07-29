import { AnswerEditModel } from './nswerEditModel';

export class QuestionEditModel {
    public id: string;
    public title: string;
    public answers: AnswerEditModel[];
    public correctAnswer: AnswerEditModel;
}