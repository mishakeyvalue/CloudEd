import { Component, Input, Output, EventEmitter, OnInit, OnChanges } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, FormArray } from '@angular/forms';

import { HelperService } from "../../../services/helper.service";
import { QuestionBackofficeService } from "../../../services/questionBackoffice.service";

import { QuestionEditModel } from './../../../models/questionEditModel';
import { AnswerEditModel } from './../../../models/answerEditModel';

@Component({
    selector: 'my-question-builder',
    templateUrl: './questionBuilder.component.html',
    providers: [HelperService, FormBuilder, QuestionBackofficeService]
})
export class QuestionBuilderComponent implements OnInit, OnChanges {
    private readonly answersControlKey: string = 'answers';

    public isRestDataLoaded: boolean;

    @Input() public question: QuestionEditModel;

    public questionForm: FormGroup;

    constructor(
        private helperService: HelperService,
        private fb: FormBuilder,
        private questionBackofficeService: QuestionBackofficeService
    ) {
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

    private deselectOthers(answerIndex: number): void {
        let arr = this.question.answers;
        arr.forEach((a, i) => {
            if (i != answerIndex) {
                a.isCorrect = false;
                console.log('beakon')
            }
            else {
                a.isCorrect = true;
                console.log('banana')
            }
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

    public doAnswer(answerId: number): void {
        this.deselectOthers(answerId);
        this.ngOnChanges();
    }

    public addAnswer(): void {
        let newAnswer = this.sampleAnswer;
        this.question.answers.push(newAnswer);
        this.ngOnChanges();
    }

    public saveQuestion(): void {
        console.log(this.question)
        this.helperService.isNewEntity(this.question.id)
            ? this.questionBackofficeService.create(this.question)
            : this.questionBackofficeService.save(this.question);
    }

    private get sampleAnswer(): AnswerEditModel {
        return { id: this.helperService.undefinedId, body: 'Banana', isCorrect: false } as AnswerEditModel;
    }

    public change(newValue): void {

    }
}