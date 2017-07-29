import { Component, OnInit } from '@angular/core';

import { QuizService } from './../../../services/quiz.service';

import { QuizViewModel } from "../../../models/quizViewModel";

@Component({
    selector: 'my-quiz',
    templateUrl: './quiz.component.html',
    providers: [QuizService]
})
export class QuizComponent implements OnInit {
    public quizes: QuizViewModel[];

    public currentQuiz: QuizViewModel;
    public isQuizStarted: boolean = false;
    public currentQuizId: string;

    constructor(private quizService: QuizService)
    { }

    ngOnInit(): void {
        this.quizes = this.quizService.getAll();
    }

    get welcomeMessage(): string {
        return "Welcome to our cloud quiz application!";
    }

    get bananaTest(): string {
        return this.quizService.greeting;
    }

    public loadQuiz(currentQuizId: string): void {
        this.isQuizStarted = true;
        this.currentQuiz = this.quizes.find((q) => q.id === currentQuizId);
    }

    public parentEventPropagation(): void {
        alert()
    }
}
