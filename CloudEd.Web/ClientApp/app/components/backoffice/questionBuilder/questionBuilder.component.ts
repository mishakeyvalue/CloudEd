import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';

import { HelperService } from "../../../services/helper.service";

import { QuestionEditModel } from './../../../models/questionEditModel';
import { AnswerEditModel } from './../../../models/answerEditModel';

@Component({
    selector: 'my-question-builder',
    templateUrl: './questionBuilder.component.html',
    providers: [HelperService]
})
export class QuestionBuilderComponent implements OnInit {
    ngOnInit(): void {
        this.answers = this.question.answers;

        }

    @Input() public question: QuestionEditModel;
    @Output() questionChange = new EventEmitter<QuestionEditModel>();
    public answers: AnswerEditModel[];

    constructor(private helperService: HelperService) {
    }

    public addAnswer(): void {
        console.log(this.question);
        let newAnswer = new AnswerEditModel();
        newAnswer.body = 'Banana';
        newAnswer.id = this.helperService.undefinedId;
        this.question.answers.push(newAnswer);
        this.questionChange.emit(this.question);
        console.log(this.question)
    }

    public change(newValue): void {
        alert(newValue)
        this.questionChange.emit(this.question);
    }
}