import { Component, Input } from '@angular/core';



import { QuizViewModel } from "../../../models/quizViewModel";
import { LearningRoutineModel, LearningBit } from "../../../models/learningRoutine";
import { QuizWorkflowResultViewModel } from "../../../models/quizWorkflowResultViewModel";

@Component({
    selector: 'my-quiz-result',
    templateUrl: './quizResult.component.html',
    providers: []
})
export class QuizResultComponent  {
    @Input() public result: QuizWorkflowResultViewModel = new QuizWorkflowResultViewModel();
    public totalQuestions: number;
    public correctQuestions: number; 

    constructor() {
    }
}
