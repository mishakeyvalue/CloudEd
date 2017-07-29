import { Component, OnInit } from '@angular/core';

import { QuizService } from './../../../services/quiz.service';

import { Quiz } from './../../../models/quiz'

@Component({
    selector: 'my-question',
    templateUrl: './quiz.component.html',
    providers: [QuizService]
})
export class QuizComponent implements OnInit {

    public quiz: Quiz;

    

    constructor(private quizService: QuizService) { }

    ngOnInit(): void {
        this.quiz = this.quizService.getAll()[0]
    }

    get bananaTest(): string {
        return this.quizService.greeting;
    }
}