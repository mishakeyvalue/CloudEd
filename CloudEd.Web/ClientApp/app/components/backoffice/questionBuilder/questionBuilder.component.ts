import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

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
    public answers: AnswerEditModel[];

    constructor(private helperService: HelperService) {
    }

    public addAnswer(): void {

    }

    public change(newValue): void {

    }
}