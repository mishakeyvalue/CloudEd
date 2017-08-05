import { Injectable, Inject } from '@angular/core';
import { Http } from "@angular/http";

import { QuizViewModel } from './../models/quizViewModel';
import { QuestionViewModel } from './../models/questionViewModel'
import { AnswerViewModel } from './../models/answerViewModel'

@Injectable()
export class QuizService {

    constructor(private http: Http,
        @Inject('ORIGIN_URL') private originUrl: string ) { }

    public getAll(): Promise<QuizViewModel[]> {
        return this.http.get(this.originUrl + '/api/Quiz/LearningRoutine')
            .toPromise()
            .then(response => response.json() as QuizViewModel[])
    }
}