import { Component, Input, Output, EventEmitter, OnInit, OnChanges } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, FormArray } from '@angular/forms';

import { HelperService } from "../../../services/helper.service";

import { QuestionEditModel } from './../../../models/questionEditModel';
import { AnswerEditModel } from './../../../models/answerEditModel';

@Component({
    selector: 'my-question-builder',
    templateUrl: './questionBuilder.component.html',
    providers: [HelperService, FormBuilder]
})
export class QuestionBuilderComponent implements OnInit, OnChanges {
    private readonly answersControlKey: string = 'answers';

    public isRestDataLoaded: boolean;

    @Input() public question: QuestionEditModel;

    public questionForm: FormGroup;

    constructor(private helperService: HelperService,
        private fb: FormBuilder) {
    }

    ngOnChanges(): void {
        if (this.isRestDataLoaded) {
            this.questionForm.reset({
                title: this.question.title,
            });
            this.setAnswers(this.question.answers);
            console.log('Changes occurred!');
            console.log(this.question.answers);
            console.log('------')
        }
    }

    ngOnInit(): void {
        this.createForm();
        this.isRestDataLoaded = true;
        this.ngOnChanges();
    }

    public doAnswer(answerIndex: number): void {
        this.deselectOthers(answerIndex);
        this.ngOnChanges();
    }

    private deselectOthers(answerIndex: number): void {

        let arr = this.questionForm.value.answers;
        arr.forEach((a, i) => {
            if (i != answerIndex)
                a.isCorrect = false;
        });
    }

    private createForm(): void {
        this.questionForm = this.fb.group({
            title: this.question.title,
            answers: this.fb.array([])
        });
    }

    private setAnswers(answers: AnswerEditModel[]): void {
        const answerFGs = answers.map(a => this.fb.group(a));
        const answerFormArray = this.fb.array(answerFGs);
        this.questionForm.setControl(this.answersControlKey, answerFormArray);
    }

    public get answers(): FormArray {
        let result = this.questionForm.get(this.answersControlKey) as FormArray;
        return result;
    }

    public addAnswer(): void {
        this.answers.push(this.fb.group(this.sampleAnswer));
    }

    private get sampleAnswer(): AnswerEditModel {
        return { id: this.helperService.undefinedId, body: 'Banana', isCorrect: false } as AnswerEditModel;
    }

    public change(newValue): void {

    }
}