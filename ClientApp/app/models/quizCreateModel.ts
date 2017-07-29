import { QuestionCreateModel } from './questionCreateModel';

export class QuizCreateModel {
    public title: string;
    public description: string;
    public questions: QuestionCreateModel[];
}