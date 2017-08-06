import { Component, Input, Output, EventEmitter } from '@angular/core';

import { QuestionViewModel } from './../../../models/questionViewModel';
import { AnswerViewModel } from './../../../models/answerViewModel';
import { LearningBit, LearningRoutineModel } from "../../../models/learningRoutine";
import { QuestionResultViewModel } from "../../../models/quizWorkflowResultViewModel";


@Component({
    selector: 'my-question-result',
    templateUrl: './questionResult.component.html',
})
export class QuestionResultComponent {
    @Input() public question: QuestionResultViewModel;
    public get cssClass(): string {
        let css: string = "alert ";
        css += this.question.isAnsweredCorrectly ? "alert-success" : "alert-danger"
        return css;
    }
}