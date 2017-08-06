import { QuestionViewModel } from './questionViewModel';
import { QuizViewModel } from './quizViewModel';

export class QuizWorkflowResultViewModel {
    public submittedQuestions: QuestionResultViewModel[];
}
export class QuestionResultViewModel extends QuestionViewModel {
    public isAnsweredCorrectly: boolean;
    public takenAnswerId: string;
    public correctAnswerId: string;
}
