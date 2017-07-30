import { Injectable } from '@angular/core';

import { QuizEditModel } from './../models/quizEditModel';
import { QuestionEditModel } from './../models/questionEditModel';
import { AnswerEditModel } from './../models/answerEditModel';

@Injectable()
export class QuizBackofficeService {
    private stubbedQuizez: QuizEditModel[] = [];
    public greeting: string = "Hello from my service!";

    constructor() {
        let newQuiz = new QuizEditModel();
        newQuiz.title = 'Sample Quiz';
        newQuiz.id = 'ij1234iji-asf;kdlj234-kmfasdw3';
        this.stubbedQuizez.push(newQuiz);
    }

    public getAll(): QuizEditModel[] {
        return this.stubbedQuizez;
    }

    public save(quiz: QuizEditModel): void {
        this.stubbedQuizez.push(quiz);
    };
}