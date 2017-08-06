import { Injectable, Inject } from '@angular/core';
import { Http } from "@angular/http";

import { QuizViewModel } from './../models/quizViewModel';
import { QuizWorkflowResultViewModel } from './../models/quizWorkflowResultViewModel';
import { QuestionViewModel } from './../models/questionViewModel'
import { AnswerViewModel } from './../models/answerViewModel'
import { LearningRoutineModel } from "../models/learningRoutine";

@Injectable()
export class QuizService {

    constructor(private http: Http,
        @Inject('ORIGIN_URL') private originUrl: string ) { }

    public getAll(): Promise<QuizViewModel[]> {
        return this.http.get(this.originUrl + '/api/Quiz/LearningRoutine')
            .toPromise()
            .then(response => response.json() as QuizViewModel[])
    }

    public submitQuiz(submitModel: LearningRoutineModel): Promise<QuizWorkflowResultViewModel> {
        return this.http.post(this.originUrl + '/api/Quiz/LearningRoutine', submitModel)
            .toPromise()
            .then(d => d.json() as QuizWorkflowResultViewModel);
    }
}