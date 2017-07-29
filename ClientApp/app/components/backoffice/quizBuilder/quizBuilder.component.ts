import { Component, OnInit } from '@angular/core';

import { QuizService } from './../../../services/quiz.service';

import { QuizCreateModel } from "../../../models/quizCreateModel";
import { QuizCreateModel } from "../../../models/quizCreateModel";
import { QuizEditModel } from "../../../models/quizEditModel";

@Component({
    selector: 'my-quiz-builder',
    templateUrl: './quizBuilder.component.html',
    providers: [QuizService]
})
export class QuizBuilderComponent implements OnInit {
    public quizesToEdit: QuizEditModel[];

    public quizToCreate: QuizCreateModel = new QuizCreateModel();


    constructor(private quizService: QuizService)
    { }

    ngOnInit(): void {
        this.quizesToEdit = this.quizService.getAll();
    }

    get welcomeMessage(): string {
        return "It's your backoffice. Here you can manage your quizes!";
    }

}
