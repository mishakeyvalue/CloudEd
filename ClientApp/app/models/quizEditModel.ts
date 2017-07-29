import { QuestionEditModel } from './questionEditModel';

export class QuizEditModel {
    public id: string;
    public title: string;
    public description: string;
    public questions: QuestionEditModel[];
}