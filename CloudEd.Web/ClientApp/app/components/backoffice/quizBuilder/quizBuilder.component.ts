import { Component, OnInit } from '@angular/core';

import { QuizBackofficeService } from './../../../services/quizBackoffice.service';

import { QuizEditModel } from "../../../models/quizEditModel";

@Component({
    selector: 'my-quiz-builder',
    templateUrl: './quizBuilder.component.html',
    providers: [QuizBackofficeService]
})
export class QuizBuilderComponent implements OnInit {
    public quizesToEdit: QuizEditModel[];
    public selectedQuizId: string;
    public selectedQuiz: QuizEditModel;

    private get nillId(): string {
        return '_undefinded';
    }


    constructor(private quizBackofficeService: QuizBackofficeService)
    { }

    ngOnInit(): void {
        this.quizesToEdit = this.quizBackofficeService.getAll();
        let newQuiz = this.quizToCreate;
        this.selectedQuiz = newQuiz;
        this.selectedQuizId = newQuiz.id;
        this.quizesToEdit.push(newQuiz);
    }

    get welcomeMessage(): string {
        return "It's your backoffice. Here you can manage your quizes!";
    }

    public saveQuiz(quizId: string): void {
        let quiz = this.quizesToEdit.find(q => q.id == quizId);
        this.quizBackofficeService.save(quiz);
    }

    public loadQuiz(selectedQuizId: string): void {
        console.log(selectedQuizId);
        this.selectedQuiz = this.quizesToEdit.find(q => q.id === selectedQuizId);
    }

    get quizToCreate(): QuizEditModel {
        let newQuiz: QuizEditModel = new QuizEditModel();
        newQuiz.title = 'Your very new quiz';
        newQuiz.id = this.nillId;
        return newQuiz;
    }

    private isNewQuiz(quizId: string): boolean {
        return quizId == 'undefined';
    }
}
