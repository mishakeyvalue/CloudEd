import { QuestionViewModel } from './questionViewModel';
import { QuizViewModel } from './quizViewModel';

export class QuizWorkflowResultViewModel extends QuizViewModel {
    public submittedQuestions: QuestionResultViewModel[];
}
export class QuestionResultViewModel extends QuestionViewModel {
    public isCorrect: boolean;
    public takenAnswerId: string;
    public correctAnswerId: string;
}
