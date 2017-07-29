import { QuestionViewModel } from './questionViewModel';

export class QuizViewModel {
    public id: string;
    public title: string;
    public description: string;
    public questions: QuestionViewModel[];
}