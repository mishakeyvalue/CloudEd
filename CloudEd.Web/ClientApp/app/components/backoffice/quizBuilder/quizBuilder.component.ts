import { Component, OnInit } from '@angular/core';

import { QuizBackofficeService } from './../../../services/quizBackoffice.service';
import { HelperService } from "../../../services/helper.service";

import { QuizEditModel } from "../../../models/quizEditModel";
import { QuestionEditModel } from "../../../models/questionEditModel";
import { AnswerEditModel } from "../../../models/answerEditModel";

@Component({
    selector: 'my-quiz-builder',
    templateUrl: './quizBuilder.component.html',
    providers: [QuizBackofficeService, HelperService]
})
export class QuizBuilderComponent implements OnInit {
    public quizesToEdit: QuizEditModel[];
    public selectedQuizId: string;
    public selectedQuiz: QuizEditModel;

    get welcomeMessage(): string {
        return "It's your backoffice. Here you can manage your quizes!";
    }

    get quizToCreate(): QuizEditModel {
        let newQuiz: QuizEditModel = new QuizEditModel();
        newQuiz.title = 'Your very new quiz';
        newQuiz.id = this.helperService.undefinedId;
        return newQuiz;
    }


    get defaultNewQuestion(): QuestionEditModel {
        let newQuestion = new QuestionEditModel();
        newQuestion.title = 'What is the sense of our lives?';
        newQuestion.answers = this.defaultNewQuestionAnswers;
        return newQuestion;
    }

    private get defaultNewQuestionAnswers(): AnswerEditModel[] {
        let result: AnswerEditModel[] =
            [
                { id: this.helperService.undefinedId, body: '42' },
                { id: this.helperService.undefinedId, body: 'Potato' },
            ]
        return result;
    }

    constructor(private quizBackofficeService: QuizBackofficeService,
                private helperService: HelperService)
    { }

    ngOnInit(): void {
        this.quizesToEdit = this.quizBackofficeService.getAll();
        let newQuiz = this.quizToCreate;
        this.selectedQuiz = newQuiz;
        this.selectedQuizId = newQuiz.id;
        this.quizesToEdit.push(newQuiz);
    }

    public saveQuiz(quizId: string): void {
        let quiz = this.quizesToEdit.find(q => q.id == quizId);
        this.quizBackofficeService.save(quiz);
    }

    public loadQuiz(selectedQuizId: string): void {
        this.selectedQuiz = this.quizesToEdit.find(q => q.id === selectedQuizId);
    }
}
