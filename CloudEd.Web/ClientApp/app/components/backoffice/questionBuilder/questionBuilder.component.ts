import { Component, Input, Output, EventEmitter, OnInit, OnChanges } from '@angular/core';
import { FormControl, FormGroup, FormBuilder } from '@angular/forms';

import { HelperService } from "../../../services/helper.service";

import { QuestionEditModel } from './../../../models/questionEditModel';
import { AnswerEditModel } from './../../../models/answerEditModel';

@Component({
    selector: 'my-question-builder',
    templateUrl: './questionBuilder.component.html',
    providers: [HelperService]
})
export class QuestionBuilderComponent implements OnInit, OnChanges {
    ngOnChanges(): void {
        this.questionForm.reset({
            title: this.question.title
        })
    }

    ngOnInit(): void {
    }


    @Input() public question: QuestionEditModel;
    public questionForm: FormGroup;

    constructor(private helperService: HelperService,
        private fb: FormBuilder) {
        this.createForm();
    }

    public addAnswer(): void {

    }

    public change(newValue): void {

    }

    private createForm(): void {
        this.questionForm = this.fb.group({
            title: this.question.title,
        });
    }
}