import { AnswerEditModel } from './answerEditModel';

export class QuestionEditModel {
    public id: string;
    public title: string;
    public answers: AnswerEditModel[];
    public correctAnswer: AnswerEditModel;
    public quizIds: string[];
}