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
    @Output() questionOnCreated: EventEmitter<QuestionEditModel>
        = new EventEmitter<QuestionEditModel>();

    public questionForm: FormGroup;

    constructor(
        private helperService: HelperService,
        private fb: FormBuilder,
        private questionBackofficeService: QuestionBackofficeService
    ) {}

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
        this.question = this.questionDeepCopy();
        this.deselectOthers(answerId);
        this.ngOnChanges();
    }

    public addAnswer(): void {
        let newAnswer = this.sampleAnswer;
        this.answers.push(this.fb.group(newAnswer));
    }

    public saveQuestion(): void {
        let question = this.questionDeepCopy();
        var promise = this.helperService.isNewEntity(question.id)
            ? this.questionBackofficeService.create(question)
            : this.questionBackofficeService.save(question);
        promise.then((res) => {
            console.log('Saved!');
            this.question = res;
            this.questionOnCreated.emit(this.question);
        })
    }

    private questionDeepCopy(): QuestionEditModel {
        const formModel = this.questionForm.value;
        const answersDeepCopy: AnswerEditModel[] = formModel.answers.map(
            (a: AnswerEditModel) => Object.assign({}, a)
        );
        const saveModel: QuestionEditModel = {
            id: this.question.id,
            title: formModel.title as string,
            answers: answersDeepCopy,
            correctAnswer: this.question.answers.find(a => a.isCorrect)
        }
        return saveModel;
    }

    private get sampleAnswer(): AnswerEditModel {
        return { id: this.helperService.undefinedId, body: 'Banana', isCorrect: false } as AnswerEditModel;
    }

    public change(newValue): void {

    }
}