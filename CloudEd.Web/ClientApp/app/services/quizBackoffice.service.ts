import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { HelperService } from "./helper.service";

import { QuizEditModel } from './../models/quizEditModel';
import { QuestionEditModel } from './../models/questionEditModel';
import { AnswerEditModel } from './../models/answerEditModel';

@Injectable()
export class QuizBackofficeService {
    private stubbedQuizez: QuizEditModel[] = [];
    public greeting: string = "Hello from my service!";

    constructor(private http: Http,
        private helperService: HelperService,
        @Inject('ORIGIN_URL') private originUrl: string, )
    {
        let newQuiz = new QuizEditModel();
        newQuiz.title = 'Sample Quiz';
        newQuiz.id = 'ij1234iji-asf;kdlj234-kmfasdw3';
        this.stubbedQuizez.push(newQuiz);
    }

    public getAll(): QuizEditModel[] {
        return this.stubbedQuizez;
    }

    public save(quiz: QuizEditModel): void {
        this.http.post(this.originUrl + '/api/QuizBackoffice/Quiz', quiz).subscribe(res => console.log(res));
    };
}