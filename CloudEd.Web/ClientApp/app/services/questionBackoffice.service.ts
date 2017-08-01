import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from "rxjs/Observable";
import 'rxjs/add/operator/toPromise';

import { HelperService } from "./helper.service";

import { QuestionEditModel } from './../models/questionEditModel';
import { AnswerEditModel } from './../models/answerEditModel';


@Injectable()
export class QuestionBackofficeService {

    public get questions(): Promise<QuestionEditModel[]> {
        return this.http.get(this.originUrl + '/api/Backoffice/Quiz')
            .toPromise()
            .then(response => response.json() as QuestionEditModel[])
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    }
   
    constructor(private http: Http,
        private helperService: HelperService,
        @Inject('ORIGIN_URL') private originUrl: string ) {
    }

    public save(question: QuestionEditModel): void {
        this.http.put(this.originUrl + '/api/Backoffice/Question', question).subscribe(res => console.log(res));
    };

    public create(question: QuestionEditModel): void {
        this.http.post(this.originUrl + '/api/Backoffice/Question', question).subscribe(res => console.log(res));
    }
}