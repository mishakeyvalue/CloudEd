import { Component, Input, Output, EventEmitter } from '@angular/core';

import { QuestionViewModel } from './../../../models/questionViewModel';
import { AnswerViewModel } from './../../../models/answerViewModel';
import { LearningBit, LearningRoutineModel } from "../../../models/learningRoutine";


@Component({
    selector: 'my-question',
    templateUrl: './question.component.html',
})
export class QuestionComponent {
    @Input() public question: QuestionViewModel;
    @Input() public resutl: LearningRoutineModel;
    @Output() onAnswered = new EventEmitter<LearningBit>();

    public doAnswer(answer: AnswerViewModel): void {
        this.deselectOthers(answer);
        this.question.selectedAnswer = answer;
        let learningBit = new LearningBit();
        learningBit.questionId = this.question.id;
        learningBit.answerId = answer.id;
        this.onAnswered.emit(learningBit);
    }

    private deselectOthers(answer: AnswerViewModel): void {
        this.question.answers.forEach(el => {
            console.log('Trying to deselect ' + el.id + ' cause of ' + answer.id)
            if (el.id !== answer.id)
                el.isSelected = false;
        });
    }
}