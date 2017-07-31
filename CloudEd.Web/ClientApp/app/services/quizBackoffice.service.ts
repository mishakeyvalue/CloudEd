import { Inject, Injectable, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from "rxjs/Observable";
import 'rxjs/add/operator/toPromise';

import { HelperService } from "./helper.service";

import { QuizEditModel } from './../models/quizEditModel';
import { QuestionEditModel } from './../models/questionEditModel';
import { AnswerEditModel } from './../models/answerEditModel';


@Injectable()
export class QuizBackofficeService {

    public get quizes(): Promise<QuizEditModel[]> {
        return this.http.get(this.originUrl + '/api/Backoffice/Quiz')
            .toPromise()
            .then(response => response.json() as QuizEditModel[])
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }

    private stubbedQuizez: QuizEditModel[] = [];
    public greeting: string = "Hello from my service!";

    constructor(private http: Http,
        private helperService: HelperService,
        @Inject('ORIGIN_URL') private originUrl: string ) {
        let newQuiz = new QuizEditModel();
        newQuiz.title = 'Sample Quiz';
        newQuiz.id = 'ij1234iji-asf;kdlj234-kmfasdw3';
        this.stubbedQuizez.push(newQuiz);

    }

    public getAll(): QuizEditModel[] {
        return [];
    }
    public save(quiz: QuizEditModel): void {
        this.http.put(this.originUrl + '/api/Backoffice/Quiz', quiz).subscribe(res => console.log(res));
    };

    public create(quiz: QuizEditModel): void {
        this.http.post(this.originUrl + '/api/Backoffice/Quiz', quiz).subscribe(res => console.log(res));
    }
}