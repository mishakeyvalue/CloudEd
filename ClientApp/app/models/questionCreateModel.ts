import { AnswerCreateModel } from './answerCreateModel';

export class QuestionCreateModel {
    public title: string;
    public answers: AnswerCreateModel[];
    public correctAnswer: AnswerCreateModel;
}