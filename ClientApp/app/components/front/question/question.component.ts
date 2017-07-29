import { Component, Input } from '@angular/core';

import { Question } from './../../../models/question';
import { Answer } from './../../../models/answer';


@Component({
    selector: 'my-question',
    templateUrl: './question.component.html',
})
export class QuestionComponent {
    @Input() public question: Question;   
}