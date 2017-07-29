import { AnswerViewModel } from './answerViewModel';

export class QuestionViewModel {
    public id: string;
    public title: string;
    public answers: AnswerViewModel[];
    public selectedAnswer: AnswerViewModel;
}