import { Component, Input, Output, EventEmitter } from '@angular/core';

import { Question } from './../../../models/question';
import { Answer } from './../../../models/answer';


@Component({
    selector: 'my-question',
    templateUrl: './question.component.html',
})
export class QuestionComponent {
    @Input() public question: Question;
    @Output() onAnswered = new EventEmitter<Question>();

    public doAnswer(answer: Answer): void {
        this.deselectOthers(answer);
        this.question.selectedAnswer = answer;
        this.onAnswered.emit(this.question);
    }

    private deselectOthers(answer: Answer): void {
        this.question.answers.forEach(el => {
            console.log('Trying to deselect ' + el.id + ' cause of ' + answer.id)
            if (el.id !== answer.id)
                el.isSelected = false;
        });
    }
}