import { Component, Input, Output, EventEmitter } from '@angular/core';

import { QuestionViewModel } from './../../../models/questionViewModel';
import { AnswerViewModel } from './../../../models/answerViewModel';


@Component({
    selector: 'my-question-builder',
    templateUrl: './questionBuilder.component.html',
})
export class QuestionBuilderComponent {
    @Input() public question: QuestionViewModel;
    @Output() onAnswered = new EventEmitter<QuestionViewModel>();

    public doAnswer(answer: AnswerViewModel): void {
        this.deselectOthers(answer);
        this.question.selectedAnswer = answer;
        this.onAnswered.emit(this.question);
    }

    private deselectOthers(answer: AnswerViewModel): void {
        this.question.answers.forEach(el => {
            console.log('Trying to deselect ' + el.id + ' cause of ' + answer.id)
            if (el.id !== answer.id)
                el.isSelected = false;
        });
    }
}