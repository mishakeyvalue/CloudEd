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
        newQuiz.questions = [this.defaultNewQuestion];
        return newQuiz;
    }


    get defaultNewQuestion(): QuestionEditModel {
        let newQuestion = new QuestionEditModel();
        newQuestion.id = this.helperService.undefinedId;
        newQuestion.title = 'What is the sense of our lives?';
        newQuestion.answers = this.defaultNewQuestionAnswers;
        return newQuestion;
    }

    private get defaultNewQuestionAnswers(): AnswerEditModel[] {
        let result: AnswerEditModel[] =
            [
                { id: this.helperService.undefinedId, body: '42',isCorrect: true },
                { id: this.helperService.undefinedId, body: 'Potato',isCorrect: false },
            ]
        return result;
    }

    constructor(private quizBackofficeService: QuizBackofficeService,
                private helperService: HelperService)
    { }

    ngOnInit(): void {
        this.quizesToEdit = [];
        this.quizBackofficeService.quizes.then((d => {
            d.push(this.quizToCreate);
            d.forEach(q => q.questions.push(this.defaultNewQuestion));
            this.quizesToEdit = d;            
        }));
        let newQuiz = this.quizToCreate;
        this.selectedQuiz = newQuiz;
        this.selectedQuizId = newQuiz.id;
        this.quizesToEdit.push(newQuiz);
    }

    public saveQuiz(quizId: string): void {
        let quiz = this.quizesToEdit.find(q => q.id == quizId);

        if (this.helperService.isNewEntity(quizId))
            this.quizBackofficeService.create(quiz);
        else
            this.quizBackofficeService.save(quiz);
    }

    public onQuestionCreated(newQuestion: QuestionEditModel) {
        console.log('Got answer from child! ' + JSON.stringify(newQuestion));
        this.quizToCreate.questions.push(newQuestion);
    }

    public loadQuiz(selectedQuizId: string): void {
        this.selectedQuiz = this.quizesToEdit.find(q => q.id === selectedQuizId);
    }
}
